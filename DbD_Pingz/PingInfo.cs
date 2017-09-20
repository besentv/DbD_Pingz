using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PcapDotNet.Core;
using System.Drawing;

namespace DbD_Pingz
{
    public partial class PingInfo : Form
    {
        public int selectedNetworkAdapter = -1;
        private NetworkChooser adapterChooser;
        private BackgroundWorker networkingBackgroundWorker;
        private delegate void removePingSafeDelegate(IpV4Address ip);

        private DataGridView.HitTestInfo lastHitItem;
        private Settings settings;
        private const string saveXMLFileName = "DbD_PingTestSave.xml";
        private PingReciever pingReciever = new PingReciever();



        private delegate void accessPingInfoControlsSafely(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime);
        private ConcurrentDictionary<IpV4Address, Ping> pingList = new ConcurrentDictionary<IpV4Address, Ping>();
        private List<accessPingInfoControlsSafely> pingInformationSubscriberList = new List<accessPingInfoControlsSafely>();
        int chartCounter = 0;

        public PingInfo()
        {
            InitializeComponent();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Title = this.Text;
            settings = Settings.loadSettingsFromXML(saveXMLFileName);
            if (settings == null)
            {
                settings = new Settings();
                Settings.writeSettingsToXML(saveXMLFileName, settings);
            }
            this.FormBorderStyle = FormBorderStyle.Sizable;
            networkingBackgroundWorker = new BackgroundWorker();
            networkingBackgroundWorker.DoWork += sniff;
            networkingBackgroundWorker.WorkerSupportsCancellation = true;
            networkingBackgroundWorker.RunWorkerCompleted += NetworkingBackgroundWorker_RunWorkerCompleted;
            networkingBackgroundWorker.RunWorkerAsync();
            dataTicker.Enabled = true;
            pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(chartCounter);
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.addPingToChart));
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.pingInfoListSetPings));

        }

        private void NetworkingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Environment.Exit(1);
        }

        public void sniff(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            pingReciever.CalculatedPingEvent += new CalculatedPingEventHandler(this.getPings);
            IList<LivePacketDevice> devices = LivePacketDevice.AllLocalMachine;

            Console.WriteLine("Device amount:" + devices.Count);
            if (devices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }
            adapterChooser = new NetworkChooser(this);
            adapterChooser.setLists(devices);
            do
            {
                adapterChooser.ShowDialog(this);
                Console.WriteLine("NetworkChooser dialog result:" + adapterChooser.DialogResult.ToString());

            } while ((selectedNetworkAdapter < 0 || selectedNetworkAdapter > (devices.Count - 1)));
            LivePacketDevice selectedDevice = devices[selectedNetworkAdapter];
            Console.WriteLine("Selected device:" + selectedDevice.Name);
            devices = null;
            pingReciever.startPingReciever(selectedDevice);
        }

        private void onFormClosed(object sender, FormClosedEventArgs e)
        {
            networkingBackgroundWorker.CancelAsync();
        }

        private void ipRightKlickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Whois this IP")
            {
                //Console.WriteLine(whoisIpMethod("http://ipinfo.io/" + list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString() + "/json"));
                // new WhoisInfo(whoisIpMethod("http://ipinfo.io/" + list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString() + "/json")).ShowDialog();
                BackgroundWorker whoisLookupWorker = new BackgroundWorker();
                whoisLookupWorker.DoWork += new DoWorkEventHandler(whoisAndShowForm);
                whoisLookupWorker.RunWorkerAsync(pingInfoList[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString());
            }
            if (e.ClickedItem.Text == "Reset table")
            {
                pingInfoList.Rows.Clear();
                resetPingHistoryChart();
            }
        }
        private void whoisAndShowForm(object sender, DoWorkEventArgs e)
        {
            string ip = (string)e.Argument;
            new WhoisInfo(ip).ShowDialog();
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

        private void killerModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked == true)
            {
                item.Enabled = false;
                item.Checked = true;
                survivorModeToolStripMenuItem.Enabled = true;
                survivorModeToolStripMenuItem.Checked = false;
                settings.programMode = DbDPingzMode.Killer;
                Console.WriteLine("Program mode set to Killer.");
            }
        }

        private void survivorModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked == true)
            {
                item.Enabled = false;
                item.Checked = true;
                this.killerModeToolStripMenuItem.Enabled = true;
                this.killerModeToolStripMenuItem.Checked = false;
                settings.programMode = DbDPingzMode.Surivivor;
                Console.WriteLine("Program mode set to Survivor.");
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
            Settings.writeSettingsToXML(saveXMLFileName, settings);
        }

        private void addPingToChart(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            if (pingInfoChart.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(addPingToChart);
                this.Invoke(caller, new object[] { pingList, accessTime });
            }
            else
            {
                if ((settings.programMode == DbDPingzMode.Killer) && (pingInfoChart.Series.Count > settings.killerMaxListEntries))
                {
                    resetPingHistoryChart();
                }
                else if ((settings.programMode == DbDPingzMode.Surivivor) && (pingInfoChart.Series.Count > settings.survivorMaxListEntries))
                {
                    resetPingHistoryChart();
                }
                if (pingList.Count > 0)
                {

                    foreach (IpV4Address address in pingList.Keys)
                    {
                        if (pingInfoChart.Series.IsUniqueName(address.ToString()))
                        {
                            pingInfoChart.Series.Add(address.ToString());
                            pingInfoChart.Series[address.ToString()].ChartType = SeriesChartType.Line;
                            pingInfoChart.Series[address.ToString()].XValueType = ChartValueType.Int32;
                            pingInfoChart.Series[address.ToString()].YValueType = ChartValueType.Int32;
                            pingInfoChart.Series[address.ToString()].BorderWidth = 2;

                        }
                        if (pingList[address].ping.Milliseconds > 0)
                        {
                            pingInfoChart.Series[address.ToString()].Points.AddXY(chartCounter, pingList[address].ping.Milliseconds);

                        }
                    }

                    if (pingInfoChart.ChartAreas[0].AxisX.Maximum > pingInfoChart.ChartAreas[0].AxisX.ScaleView.Size)
                    {
                        pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(pingInfoChart.ChartAreas[0].AxisX.Maximum);
                    }
                    chartCounter++;
                }
            }
        }

        private void resetPingHistoryChart()
        {

            if (pingInfoChart.InvokeRequired)
            {
                Action caller = new Action(resetPingHistoryChart);
                this.Invoke(caller, new object[] { });
            }
            else
            {
                pingInfoChart.ChartAreas[0].AxisX.ScaleView.Scroll(pingInfoChart.ChartAreas[0].AxisX.Maximum);
                foreach (Series s in pingInfoChart.Series)
                {
                    pingInfoChart.Series[s.Name].Points.Clear();
                }
                chartCounter = 0;
                pingInfoChart.Series.Clear();
            }
        }

        private bool getPingHistoryChartColor(IpV4Address ip, out Color color)
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












        public void getPings(object sender, Ping ping)
        {
            this.fillPingList(ping);
        }

        private void callPingInfoSubscribers(object sender, EventArgs e)
        {
            ConcurrentDictionary<IpV4Address, Ping> pingListCopy = pingList;
            foreach (accessPingInfoControlsSafely subscriber in pingInformationSubscriberList)
            {
                this.Invoke(subscriber, new object[] { pingListCopy, DateTime.Now });
            }
            validatePingList(pingList);
        }

        private void fillPingList(Ping ping)
        {
            if (!pingList.ContainsKey(ping.ip))
            {
                pingList.TryAdd(ping.ip, ping);
            }
            else if (pingList.ContainsKey(ping.ip))
            {
                pingList[ping.ip] = ping;
            }
        }

        private void validatePingList(ConcurrentDictionary<IpV4Address, Ping> validateList)
        {
            foreach (IpV4Address ip in pingList.Keys)
            {
                TimeSpan s = DateTime.Now - pingList[ip].recievedPacketTime;
                Ping ignored;
                if (s.Seconds > 10)
                {
                    if (pingList.TryRemove(ip, out ignored))
                    {
                        Console.WriteLine("Ip:" + ip.ToString() + " timed out!");
                    }
                }
            }
        }

        private void pingInfoListSetPings(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            if (pingInfoList.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(pingInfoListSetPings);
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
                        TimeSpan timeSincePacketRecieve = accessTime - pingList[ip].recievedPacketTime;
                        if (timeSincePacketRecieve.Seconds > 10)
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
                                    rowsToDelete.Add(row);
                                }
                                else
                                {
                                    row.Cells[1].Value = pingList[ip].ping.Milliseconds + "ms";
                                    if (pingList[ip].ping.Milliseconds > settings.maxGoodPing)
                                        row.Cells[1].Style.BackColor = settings.badPingColor;
                                    else row.Cells[1].Style.BackColor = settings.goodPingColor;
                                }
                                containsKey = true;
                            }
                        }
                        if (!containsKey && !timedOut)
                        {
                            int rowNumber;
                            Color chartColor;
                            rowNumber = pingInfoList.Rows.Add(new object[] { ip.ToString(), pingList[ip].ping.Milliseconds + "ms" });
                            if (getPingHistoryChartColor(ip, out chartColor))
                            {
                                pingInfoList.Rows[rowNumber].Cells[0].Style.BackColor = chartColor;
                            }

                            if (pingList[ip].ping.Milliseconds > settings.maxGoodPing)
                                pingInfoList.Rows[rowNumber].Cells[1].Style.BackColor = settings.badPingColor;
                            else
                                pingInfoList.Rows[rowNumber].Cells[1].Style.BackColor = settings.goodPingColor;
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

        private void pingInfoList_SelectionChanged(object sender, EventArgs e)
        {
            pingInfoList.ClearSelection();
            
        }

        private void pingInfoChartSetPings(ConcurrentDictionary<IpV4Address, Ping> pingList, DateTime accessTime)
        {
            if (pingInfoChart.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(addPingToChart);
                this.Invoke(caller, new object[] { pingList ,accessTime });
            }
            else
            {
                if (!pingList.IsEmpty)
                {
                    List<Series> seriesToDelete = new List<Series>();
                    foreach(IpV4Address ip in pingList.Keys)
                    {
                        bool timedOut = false;
                        TimeSpan timeSincePacketRecieve = accessTime - pingList[ip].recievedPacketTime;
                        if (timeSincePacketRecieve.Seconds > 10)
                        {
                            timedOut = true;
                        }
                        bool containsKey = false;
                        foreach (Series series in pingInfoChart.Series)
                        {
                            if (timedOut)
                            {
                                seriesToDelete.Add(series);
                            }
                            if (series.Name.Contains(ip.ToString()))
                            {
                                series.Points.AddXY(0, pingList[ip].ping.Milliseconds);
                                containsKey = true;
                            }
                        }
                        if (!containsKey)
                        {
                            Series series;
                            series = pingInfoChart.Series.Add(ip.ToString());
                            series.ChartType = SeriesChartType.Line;
                            series.XValueType = ChartValueType.Int32;
                            series.YValueType = ChartValueType.Int32;
                        }
                      //  pingInfoChart.Series[address.ToString()].Points.AddXY(chartCounter, pingList[address].ping.Milliseconds);
                    }
                    foreach(Series series in seriesToDelete)
                    {
                        Console.WriteLine("Removing series:" + series.Name+ " from pingInfoChart.");
                        series.Points.Clear();
                        pingInfoChart.Series.Remove(series);
                    }
                }
            }
        }
    }
}
