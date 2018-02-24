using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PcapDotNet.Core;
using PcapDotNet.Packets.IpV4;
using System.Runtime.InteropServices;
using System.Reflection;

namespace DbD_Pingz
{
    public partial class PingInfo : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private DataGridView.HitTestInfo lastHitItem;
        private StripLine maxGoodPingLine = new StripLine();

        private const string saveXMLFileName = "DbD_PingTestSave.xml";
        private Settings settings;

        private PingReciever pingReciever = new PingReciever();
        private delegate void accessPingInfoControlsSafely(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime);
        private ConcurrentDictionary<IpV4Address, Ping> pingList = new ConcurrentDictionary<IpV4Address, Ping>();
        private Dictionary<String, IpWhois> ipWhoisList = new Dictionary<String, IpWhois>();
        private List<accessPingInfoControlsSafely> pingInformationSubscriberList = new List<accessPingInfoControlsSafely>();
        private int chartCounter = 0;

        public PingInfo(string[] args)
        {
            InitializeComponent();                                                                      //Init Form
            this.Text = "DbD Pingz - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();  //Set form name (part of init)
            if (args.Length > 0)
            {
                if (args[0].Contains("console"))
                {
                    AllocConsole();                                                                     //Use console if desired by argument "-console"
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }

            LoadSettings(); //ALWAYS LOAD SETTINGS BEFORE YOU ACCESS ANYTING ELSE !!!

            maxGoodPingLine.BackColor = Color.HotPink;
            maxGoodPingLine.Interval = 0;
            maxGoodPingLine.StripWidth = 1;
            previousPingInfoList.Columns[2].DefaultCellStyle.NullValue = null;
            //maxGoodPingLine.Text = "Max. Good Ping";

            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.PingInfoChartSetPings));
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.PingInfoListSetPings));
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.PreviousPingInfoList_SetPings));

            pingReciever.CalculatedPingEvent += new CalculatedPingEventHandler(this.GetPings);
            pingInfoChart.MouseWheel += new MouseEventHandler(PingInfoChart_MouseWheel);
            pingInfoChart.ChartAreas[0].AxisY.StripLines.Add(maxGoodPingLine);

            ChangeNetworkAdapter(false);                                                                //Load previous network adapter
        }

        private void LoadSettings()
        {
            settings = Settings.LoadSettingsFromXML(saveXMLFileName);
            if (settings == null)
            {
                Console.WriteLine("Settings null... writing new.");
                settings = new Settings();
                Settings.WriteSettingsToXML(saveXMLFileName, settings);
            }

            this.Size = settings.PingInfoFormSize;
            Console.WriteLine("Splitter1 distance:" + settings.MainWindowSplitter1Distance);
            Console.WriteLine("Splitter2 distance:" + settings.MainWindowSplitter2Distance);
            this.splitContainer2.SplitterDistance = settings.MainWindowSplitter2Distance;
            this.splitContainer1.SplitterDistance = settings.MainWindowSplitter1Distance;

            this.TopMost = settings.DbDPingzIsTopmost;
            this.makeDbDPingzTopmostToolStripMenuItem.Checked = settings.DbDPingzIsTopmost;

            this.pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size = settings.PingInfoChartScale;
            this.pingInfoChart.ChartAreas[0].AxisY.Interval = (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size / 10);
            this.pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(chartCounter);
            this.maxGoodPingLine.IntervalOffset = settings.MaximumGoodPing;
        }

        private void SaveSettings()
        {
            settings.PingInfoChartScale = (int)pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size;
            settings.DbDPingzIsTopmost = this.TopMost;
            settings.PingInfoFormSize = this.Size;
            settings.MainWindowSplitter1Distance = splitContainer1.SplitterDistance;
            settings.MainWindowSplitter2Distance = splitContainer2.SplitterDistance;
            if (!(pingReciever.SniffingDevice == null))
            {
                settings.LastNetworkAdapterName = pingReciever.SniffingDevice.Name;
            }
            Settings.WriteSettingsToXML(saveXMLFileName, settings);
        }

        private void ChangeNetworkAdapter(bool forceChange)
        {
            NetworkChooser networkChooser = null;
            pingReciever.TryStopPingReciever();
            LivePacketDevice livePacketDevice = NetworkChooser.TryGetDevice(settings.LastNetworkAdapterName);
            if (livePacketDevice == null || forceChange)
            {
                do
                {
                    networkChooser = new NetworkChooser();
                    networkChooser.ShowDialog(this);
                    if (networkChooser.DialogResult == DialogResult.Cancel)
                    {
                        Console.WriteLine("No network adapter selected!");
                        pingInfoChart.Hide();
                        pingInfoList.Hide();
                        labelNoAdapter1.Show();
                        labelNoAdapter2.Show();
                        dataTicker.Enabled = false;
                        return;
                    }
                } while ((networkChooser.SelectedLivePacketDevice == null) || (networkingBackgroundWorker.IsBusy));
                livePacketDevice = networkChooser.SelectedLivePacketDevice;
                if (networkChooser.RememberDecision)
                {
                    settings.LastNetworkAdapterName = livePacketDevice.Name;
                }
                else
                {
                    settings.LastNetworkAdapterName = null;
                }
            }
            pingInfoChart.Show();
            pingInfoList.Show();
            labelNoAdapter1.Hide();
            labelNoAdapter2.Hide();
            dataTicker.Enabled = true;

            networkingBackgroundWorker.RunWorkerAsync(livePacketDevice);
            Console.WriteLine("Set network adapter to device:" + livePacketDevice.Name);
        }

        #region Ping Info Controls Management
        public void GetPings(object sender, Ping ping)
        {
            this.FillPingList(ping);
        }

        private void CallPingInfoSubscribers(object sender, EventArgs e)
        {
            ConcurrentDictionary<IpV4Address, Ping> pingListCopy = pingList;
            foreach (accessPingInfoControlsSafely subscriber in pingInformationSubscriberList)
            {
                this.Invoke(subscriber, new object[] { pingListCopy, DateTime.Now });
            }
            ValidatePingList(pingList);
        }

        private void FillPingList(Ping ping)
        {
            if (!pingList.ContainsKey(ping.Ip))
            {
                pingList.TryAdd(ping.Ip, ping);
            }
            else if (pingList.ContainsKey(ping.Ip))
            {
                pingList[ping.Ip] = ping;
            }
        }

        private void ValidatePingList(ConcurrentDictionary<IpV4Address, Ping> validateList)
        {
            foreach (IpV4Address ip in pingList.Keys)
            {
                TimeSpan timeSinceLastRecievedPackage = DateTime.Now - pingList[ip].RecievedPacketTime;
                if (timeSinceLastRecievedPackage.Seconds >= settings.SecondsUntilIPTimeout)
                {
                    Console.WriteLine("Ip:" + ip.ToString() + " timed out! Will be removed in:" + ((settings.SecondsUntilIPTimeout + settings.SecondsUntilTimeoutedIpRemoved) - timeSinceLastRecievedPackage.Seconds) + "seconds.");
                    if (timeSinceLastRecievedPackage.Seconds >= (settings.SecondsUntilIPTimeout + settings.SecondsUntilTimeoutedIpRemoved))
                    {
                        if (pingList.TryRemove(ip, out Ping ignored))
                        {
                            Console.WriteLine("Ip:" + ip.ToString() + " was removed from pinglist!");
                        }
                    }
                }
            }
        }

        private void PreviousPingInfoList_SetPings(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            foreach (IpV4Address address in pingList.Keys)
            {
                bool containsKey = false;
                foreach (DataGridViewRow row in previousPingInfoList.Rows)
                {
                    String rowIpString = row.Cells[0].Value.ToString();
                    if (row.Cells[2].Value == null)
                        if (ipWhoisList.ContainsKey(rowIpString))
                            if (ipWhoisList[rowIpString].isJsonParsed)
                            {
                                if (ipWhoisList[rowIpString].CountryFlag != null)
                                {
                                    row.Cells[2].Value = ipWhoisList[rowIpString].CountryFlag;
                                }
                                if (ipWhoisList[rowIpString].ipWhoisInfo.Org.ToLower().Contains("valve"))
                                {
                                    row.Cells[3].Value = true;
                                    Console.WriteLine("ISP OF " + rowIpString + " IS VALVE!");
                                }
                                ipWhoisList.Remove(rowIpString);
                            }
                    if (row.Cells[0].Value.ToString().Contains(address.ToString()))
                    {
                        row.Cells[1].Value = accessTime.ToString("HH:mm:ss");
                        containsKey = true;
                    }
                }
                if (!containsKey)
                {
                    previousPingInfoList.Rows.Add(new object[] { address.ToString(), accessTime.ToString("HH:mm:ss"), null });
                    ipWhoisList.Add(address.ToString(), new IpWhois(address.ToString()));
                }
            }
            previousPingInfoList.Sort(previousPingInfoList.Columns[1], ListSortDirection.Descending);
        }

        private void PingInfoListSetPings(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            if (pingInfoList.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(PingInfoListSetPings);
                this.Invoke(caller, new object[] { pingList, accessTime });
            }
            else
            {
                if (!pingList.IsEmpty)
                {
                    List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                    foreach (IpV4Address ip in pingList.Keys)
                    {
                        bool timedOut = false;
                        TimeSpan timeSincePacketRecieve = accessTime - pingList[ip].RecievedPacketTime;
                        if (timeSincePacketRecieve.Seconds >= settings.SecondsUntilIPTimeout)
                        {
                            timedOut = true;
                        }
                        bool containsKey = false;
                        foreach (DataGridViewRow row in pingInfoList.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Contains(ip.ToString()))
                            {
                                if (timedOut)
                                {
                                    if (timeSincePacketRecieve.Seconds >= (settings.SecondsUntilIPTimeout + settings.SecondsUntilTimeoutedIpRemoved))
                                    {
                                        rowsToDelete.Add(row);
                                    }
                                    else
                                    {
                                        row.Cells[1].Value = "Timed Out!";
                                    }
                                }
                                else
                                {
                                    if (GetPingInfoChartSeriesColor(ip, out Color chartColor))
                                    {
                                        row.Cells[0].Style.BackColor = chartColor;
                                    }
                                    row.Cells[1].Value = pingList[ip].TimeElapsed.Milliseconds + "ms";
                                    if (pingList[ip].TimeElapsed.Milliseconds > settings.MaximumGoodPing)
                                        row.Cells[1].Style.BackColor = settings.BadPingColor;
                                    else row.Cells[1].Style.BackColor = settings.GoodPingColor;
                                }
                                containsKey = true;
                            }
                        }
                        if (!containsKey && !timedOut)
                        {
                            int rowNumber;
                            rowNumber = pingInfoList.Rows.Add(new object[] { ip.ToString(), pingList[ip].TimeElapsed.Milliseconds + "ms" });
                            if (GetPingInfoChartSeriesColor(ip, out Color chartColor))
                            {
                                pingInfoList.Rows[rowNumber].Cells[0].Style.BackColor = chartColor;
                            }

                            if (pingList[ip].TimeElapsed.Milliseconds > settings.MaximumGoodPing)
                                pingInfoList.Rows[rowNumber].Cells[1].Style.BackColor = settings.BadPingColor;
                            else
                                pingInfoList.Rows[rowNumber].Cells[1].Style.BackColor = settings.GoodPingColor;
                        }
                    }
                    foreach (DataGridViewRow deleteRow in rowsToDelete)
                    {
                        Console.WriteLine("Removing:" + deleteRow.Cells[0].Value + " from pingInfoList.");
                        pingInfoList.Rows.Remove(deleteRow);
                    }
                }
                else
                {
                    pingInfoList.Rows.Clear();
                }
            }
        }

        private void PingInfoChartSetPings(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            if (pingInfoChart.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(PingInfoChartSetPings);
                this.Invoke(caller, new object[] { pingList, accessTime });
            }
            else
            {
                if (!pingList.IsEmpty)
                {
                    pingInfoChart.Series.SuspendUpdates();
                    List<Series> seriesToDelete = new List<Series>();
                    if (chartCounter >= Int32.MaxValue)
                    {
                        foreach (Series series in pingInfoChart.Series) if (!seriesToDelete.Contains(series)) seriesToDelete.Add(series);
                        pingInfoChart.ChartAreas[0].AxisX.ScaleView.Position = 20;
                        chartCounter = -1;
                    }
                    if (chartCounter >= 0)
                    {
                        foreach (IpV4Address ip in pingList.Keys)
                        {
                            bool timedOut = false;
                            TimeSpan timeSincePacketRecieve = accessTime - pingList[ip].RecievedPacketTime;
                            if (timeSincePacketRecieve.Seconds >= (settings.SecondsUntilIPTimeout + settings.SecondsUntilTimeoutedIpRemoved))
                            {
                                timedOut = true;
                            }
                            bool containsKey = false;
                            foreach (Series series in pingInfoChart.Series)
                            {
                                List<DataPoint> pointsOutOfView = new List<DataPoint>();
                                if (series.Name.Contains(ip.ToString()))
                                {
                                    if (timedOut)
                                    {
                                        if (!seriesToDelete.Contains(series))
                                        {
                                            seriesToDelete.Add(series);
                                        }
                                    }
                                    series.Points.AddXY(chartCounter, pingList[ip].TimeElapsed.Milliseconds);
                                    containsKey = true;
                                }
                                foreach (DataPoint point in series.Points)
                                {
                                    if (point.XValue <= (pingInfoChart.ChartAreas[0].AxisX.ScaleView.ViewMinimum - 1))
                                    {
                                        pointsOutOfView.Add(point);
                                    }
                                }
                                foreach (DataPoint point in pointsOutOfView) series.Points.Remove(point);
                            }
                            if (!containsKey)
                            {
                                Series series;
                                series = pingInfoChart.Series.Add(ip.ToString());
                                series.ChartType = SeriesChartType.FastLine;
                                series.XValueType = ChartValueType.Int32;
                                series.YValueType = ChartValueType.Int32;
                                series.IsVisibleInLegend = false;
                                series.BorderWidth = 2;
                                series.Points.AddXY(chartCounter, pingList[ip].TimeElapsed.Milliseconds);
                            }
                        }
                    }
                    foreach (Series series in seriesToDelete)
                    {
                        Console.WriteLine("Removing series:" + series.Name + " from pingInfoChart.");
                        series.Points.Clear();
                        pingInfoChart.Series.Remove(series);
                    }
                    if (pingInfoChart.ChartAreas[0].AxisX.Maximum > pingInfoChart.ChartAreas[0].AxisX.ScaleView.ViewMaximum)
                    {
                        pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(pingInfoChart.ChartAreas[0].AxisX.Maximum);
                    }
                    pingInfoChart.Series.ResumeUpdates();
                    chartCounter++;
                }
            }
        }
        private bool GetPingInfoChartSeriesColor(IpV4Address ip, out Color color)
        {
            pingInfoChart.ApplyPaletteColors();
            if (!pingInfoChart.Series.IsUniqueName(ip.ToString()))
            {
                color = pingInfoChart.Series[ip.ToString()].Color;
                return true;
            }
            color = new Color();
            return false;
        }
        #endregion

        #region Listeners

        private void IpRightKlickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Whois this IP")
            {
                if (pingInfoList.Rows.Count > lastHitItem.RowIndex)
                {
                    new WhoisInfo(pingInfoList[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString()).Show(this);
                }
            }
            if (e.ClickedItem.Text == "Reset table")
            {
                pingInfoList.Rows.Clear();
            }
        }

        private void List_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = pingInfoList.HitTest(e.X, e.Y);
                lastHitItem = hit;
                if (hit.ColumnIndex == 0 && hit.RowIndex >= 0)
                {
                    ipRightKlickMenu.Items[0].Visible = true;
                    pingInfoList.ClearSelection();
                    pingInfoList[hit.ColumnIndex, hit.RowIndex].Selected = true;
                    ipRightKlickMenu.Show(pingInfoList, e.Location);
                }
                else
                {
                    ipRightKlickMenu.Items[0].Visible = false;
                    ipRightKlickMenu.Show(pingInfoList, e.Location);
                }
            }
        }

        private void MakeDbDPingzTopmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked == true)
            {
                this.TopMost = true;
            }
            else if (item.Checked == false)
            {
                this.TopMost = false;
            }
            Console.WriteLine("Program is topmost:" + this.TopMost);
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(settings);
            settingsForm.ShowDialog(this);
            Settings.WriteSettingsToXML(saveXMLFileName, settingsForm.Settings);
        }

        private void PingInfoChart_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                if (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size >= 20)
                {
                    pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size -= 10;
                    pingInfoChart.ChartAreas[0].AxisY.Interval = (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size / 10);
                }
            }
            else if (e.Delta < 0)
            {
                if (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size <= 490)
                {
                    pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size += 10;
                    pingInfoChart.ChartAreas[0].AxisY.Interval = (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size / 10);
                }
            }
        }

        private void PingInfoChart_MouseEnter(object sender, EventArgs e)
        {
            pingInfoChart.Focus();
        }

        private void PingInfoChart_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void ChangeNetworkAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeNetworkAdapter(true);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About(DbDPingz.buildtype).ShowDialog(this);
        }

        private void NetworkingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            pingReciever.StartPingReciever((LivePacketDevice)e.Argument);
        }

        private void PingInfoList_SelectionChanged(object sender, EventArgs e)
        {
            pingInfoList.ClearSelection();

        }

        private void PreviousPingInfoList_SelectionChanged(object sender, EventArgs e)
        {
            previousPingInfoList.ClearSelection();
        }

        private void PreviousPingInfoList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = previousPingInfoList.HitTest(e.X, e.Y);
                lastHitItem = hit;
                Console.WriteLine("Row index:" + hit.RowIndex + " ColumnIndex:" + hit.ColumnIndex);
                if (hit.ColumnIndex == 0 && hit.RowIndex >= 0)
                {
                    previousPingInfoContextMenu.Items[0].Visible = true;
                    previousPingInfoList.ClearSelection();
                    previousPingInfoList[hit.ColumnIndex, hit.RowIndex].Selected = true;
                    previousPingInfoContextMenu.Show(previousPingInfoList, e.Location);
                }
                else
                {
                    previousPingInfoContextMenu.Items[0].Visible = false;
                    previousPingInfoContextMenu.Show(previousPingInfoList, e.Location);
                }
            }
        }

        private void PreviousPingInfoContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == whoisThisIPToolStripMenuItem)
            {
                if (previousPingInfoList.Rows.Count > lastHitItem.RowIndex)
                {
                    new WhoisInfo(previousPingInfoList[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString()).Show(this);
                }
            }
            else if (e.ClickedItem == resetTableToolStripMenuItem1)
            {
                previousPingInfoList.Rows.Clear();
            }
        }

        private void PingInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            networkingBackgroundWorker.CancelAsync();
            SaveSettings();
        }
        #endregion
    }
}
