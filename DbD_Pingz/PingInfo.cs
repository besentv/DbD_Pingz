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

namespace DbD_Pingz
{
    public partial class PingInfo : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private DataGridView.HitTestInfo lastHitItem;

        private const string saveXMLFileName = "DbD_PingTestSave.xml";
        private Settings settings;
        PingReciever pingReciever;

        private delegate void accessPingInfoControlsSafely(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime);
        private ConcurrentDictionary<IpV4Address, Ping> pingList = new ConcurrentDictionary<IpV4Address, Ping>();
        private List<accessPingInfoControlsSafely> pingInformationSubscriberList = new List<accessPingInfoControlsSafely>();
        int chartCounter = 0;

        public PingInfo(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                if (args[0].Contains("console"))
                {
                    AllocConsole();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }

            settings = Settings.LoadSettingsFromXML(saveXMLFileName);
            if (settings == null)
            {
                settings = new Settings();
                Settings.WriteSettingsToXML(saveXMLFileName, settings);
            }

            this.splitContainer1.SplitterDistance = settings.MainWindowSplitterDistance;
            this.TopMost = settings.DbDPingzIsTopmost;
            this.pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size = settings.PingInfoChartSize;
            this.pingInfoChart.ChartAreas[0].AxisY.Interval = (pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size / 10);
            pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(chartCounter);
            this.makeDbDPingzTopmostToolStripMenuItem.Checked = settings.DbDPingzIsTopmost;



            this.pingInfoChart.MouseWheel += new MouseEventHandler(pingInfoChart_MouseWheel);

            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.PingInfoChartSetPings));
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.PingInfoListSetPings));

            pingReciever = new PingReciever();
            pingReciever.CalculatedPingEvent += new CalculatedPingEventHandler(this.GetPings);

            ChangeNetworkAdapter();
        }

        public void ChangeNetworkAdapter()
        {
            pingReciever.TryStopPingReciever();
            NetworkChooser networkChooser = new NetworkChooser();
            do
            {
                networkChooser.ShowDialog(this);
            } while ((networkChooser.SelectedLivePacketDevice == null) || (networkingBackgroundWorker.IsBusy));
            networkingBackgroundWorker.RunWorkerAsync(networkChooser.SelectedLivePacketDevice);

        }

        public void Sniff(object sender, DoWorkEventArgs e)
        {
            pingReciever.StartPingReciever((LivePacketDevice)e.Argument);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            settings.PingInfoChartSize = (int)pingInfoChart.ChartAreas[0].AxisY.ScaleView.Size;
            settings.DbDPingzIsTopmost = this.TopMost;
            Settings.WriteSettingsToXML(saveXMLFileName, settings);
            networkingBackgroundWorker.CancelAsync();
        }

        #region Ping info controls management
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
                if (timeSinceLastRecievedPackage.Seconds > settings.SecondsUntilIPTimeout)
                {
                    if (pingList.TryRemove(ip, out Ping ignored))
                    {
                        Console.WriteLine("Ip:" + ip.ToString() + " timed out!");
                    }
                }
            }
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
                                    if (timeSincePacketRecieve.Seconds > (settings.SecondsUntilIPTimeout))
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

        private void PingInfoList_SelectionChanged(object sender, EventArgs e)
        {
            pingInfoList.ClearSelection();

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
                            if (timeSincePacketRecieve.Seconds > settings.SecondsUntilIPTimeout)
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
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SplitContainer splitContainer = (SplitContainer)sender;
            settings.MainWindowSplitterDistance = splitContainer.SplitterDistance;
        }

        private void ipRightKlickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Whois this IP")
            {
                new WhoisInfo(pingInfoList[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString()).ShowDialog(this);
            }
            if (e.ClickedItem.Text == "Reset table")
            {
                pingInfoList.Rows.Clear();
            }
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
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

        private void makeDbDPingzTopmostToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(settings).ShowDialog(this);
            Settings.WriteSettingsToXML(saveXMLFileName, settings);
        }

        private void pingInfoChart_MouseWheel(object sender, MouseEventArgs e)
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

        private void pingInfoChart_MouseEnter(object sender, EventArgs e)
        {
            pingInfoChart.Focus();
        }

        private void pingInfoChart_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        #endregion

        private void changeNetworkAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeNetworkAdapter();
        }
    }
}

