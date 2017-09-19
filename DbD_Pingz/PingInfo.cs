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



        private delegate void accessPingInfoControlsSafely(ConcurrentDictionary<IpV4Address, Ping> pingList);
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
            pingHistoryChart.ChartAreas[0].AxisX.ScaleView.Scroll(chartCounter);
            pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.setPing));
             pingInformationSubscriberList.Add(new accessPingInfoControlsSafely(this.addPingToChart));
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

        public bool pingInfoFind(ConcurrentDictionary<IpV4Address, Ping> pingList)
        {
            for (int i = 0; i < list.Rows.Count; i++)
            {
               // if (0 == String.Compare(list[0, i].Value.ToString(), ip.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void setPing(ConcurrentDictionary<IpV4Address, Ping> pingList)
        {
            if (list.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(setPing);
                this.Invoke(caller);
            }

            else
            {
                if (pingList.Count > 0)
                {
                    if ((settings.programMode == DbDPingzMode.Killer) && (pingHistoryChart.Series.Count > settings.killerMaxListEntries))
                    {
                        list.Rows.Clear();
                    }
                    else if ((settings.programMode == DbDPingzMode.Surivivor) && (pingHistoryChart.Series.Count > settings.survivorMaxListEntries))
                    {
                        list.Rows.Clear();
                    }
                    foreach (IpV4Address address in pingList.Keys)
                    {
                        bool listHasEntry = false;
                        for (int i = 0; i < list.Rows.Count; i++)
                        {
                            if (0 == String.Compare(list[0, i].Value.ToString(), address.ToString()))
                            {
                                Color c;
                                if (getPingHistoryChartColor(address, out c))
                                {
                                    list[0, i].Style.BackColor = c;
                                }
                                list[1, i].Value = pingList[address].ping.Milliseconds.ToString() + "ms";
                                listHasEntry = true;
                                if (pingList[address].ping.Milliseconds >= settings.maxGoodPing)
                                {
                                    list[1, i].Style.BackColor = settings.badPingColor;
                                }
                                else
                                {
                                    list[1, i].Style.BackColor = settings.goodPingColor;
                                }
                            }
                        }
                        if (!listHasEntry)
                        {

                            string[] row = new string[2];
                            row[0] = address.ToString();
                            row[1] = pingList[address].ping.Milliseconds.ToString() + "ms";
                            int rowNum;
                            rowNum = list.Rows.Add(row);
                            if (pingList[address].ping.Milliseconds >= settings.maxGoodPing)
                            {
                                list[1, rowNum].Style.BackColor = settings.badPingColor;
                            }
                            else
                            {
                                list[1, rowNum].Style.BackColor = settings.goodPingColor;
                            }
                        }
                    }
                    list.ClearSelection();
                }
            }
        }

        public void removePing(IpV4Address ip)
        {
            if (list.InvokeRequired)
            {
                removePingSafeDelegate caller = new removePingSafeDelegate(removePing);
                this.Invoke(caller, new object[] { ip });
            }
            foreach (DataGridViewRow row in list.Rows)
            {
                if (String.Compare(row.Cells[0].Value.ToString(), ip.ToString()) == 0)
                {
                    list.Rows.Remove(row);
                }
            }
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
                whoisLookupWorker.RunWorkerAsync(list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString());
            }
            if (e.ClickedItem.Text == "Reset table")
            {
                list.Rows.Clear();
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

                DataGridView.HitTestInfo hit = list.HitTest(e.X, e.Y);
                lastHitItem = hit;
                if (hit.ColumnIndex == 0 && hit.RowIndex >= 0)
                {
                    ipRightKlickMenu.Items[0].Visible = true;
                    list.ClearSelection();
                    list[hit.ColumnIndex, hit.RowIndex].Selected = true;
                    ipRightKlickMenu.Show(list, e.Location);

                }
                else
                {
                    ipRightKlickMenu.Items[0].Visible = false;
                    ipRightKlickMenu.Show(list, e.Location);
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

        private void addPingToChart(ConcurrentDictionary<IpV4Address, Ping> pingList)
        {
            if (pingHistoryChart.InvokeRequired)
            {
                accessPingInfoControlsSafely caller = new accessPingInfoControlsSafely(addPingToChart);
                this.Invoke(caller, new object[] { });
            }
            else
            {
                if ((settings.programMode == DbDPingzMode.Killer) && (pingHistoryChart.Series.Count > settings.killerMaxListEntries))
                {
                    resetPingHistoryChart();
                }
                else if ((settings.programMode == DbDPingzMode.Surivivor) && (pingHistoryChart.Series.Count > settings.survivorMaxListEntries))
                {
                    resetPingHistoryChart();
                }
                if (pingList.Count > 0)
                {

                    foreach (IpV4Address address in pingList.Keys)
                    {
                        if (pingHistoryChart.Series.IsUniqueName(address.ToString()))
                        {
                            pingHistoryChart.Series.Add(address.ToString());
                            pingHistoryChart.Series[address.ToString()].ChartType = SeriesChartType.Line;
                            pingHistoryChart.Series[address.ToString()].XValueType = ChartValueType.Int32;
                            pingHistoryChart.Series[address.ToString()].YValueType = ChartValueType.Int32;
                            pingHistoryChart.Series[address.ToString()].BorderWidth = 2;

                        }
                        if (pingList[address].ping.Milliseconds > 0)
                        {
                            pingHistoryChart.Series[address.ToString()].Points.AddXY(chartCounter, pingList[address].ping.Milliseconds);
                            
                        }
                    }

                    if (pingHistoryChart.ChartAreas[0].AxisX.Maximum > pingHistoryChart.ChartAreas[0].AxisX.ScaleView.Size)
                    {
                        pingHistoryChart.ChartAreas[0].AxisX.ScaleView.Scroll(pingHistoryChart.ChartAreas[0].AxisX.Maximum);
                    }
                    chartCounter++;
                }
            }
        }

        private void resetPingHistoryChart()
        {

            if (pingHistoryChart.InvokeRequired)
            {
                Action caller = new Action(resetPingHistoryChart);
                this.Invoke(caller, new object[] { });
            }
            else
            {
                pingHistoryChart.ChartAreas[0].AxisX.ScaleView.Scroll(pingHistoryChart.ChartAreas[0].AxisX.Maximum);
                foreach (Series s in pingHistoryChart.Series)
                {
                    pingHistoryChart.Series[s.Name].Points.Clear();
                }
                chartCounter = 0;
                pingHistoryChart.Series.Clear();
            }
        }

        private bool getPingHistoryChartColor(IpV4Address ip, out Color color)
        {
            pingHistoryChart.ApplyPaletteColors();
            if (!pingHistoryChart.Series.IsUniqueName(ip.ToString()))
            {
                color = pingHistoryChart.Series[ip.ToString()].Color;
                return true;
            }
            color = new Color();
            return false;
        }












        public void getPings(object sender, Ping ping)
        {
            this.fillPingList(ping);
        }

        private void updateControls(object sender, EventArgs e)
        {
            callPingInfoSubscribers();
        }

        private void fillPingList(Ping ping)
        {
            if (!pingList.ContainsKey(ping.ip))
            {
                if (settings.killerMaxListEntries < (pingList.Count + 1) && settings.programMode == DbDPingzMode.Killer)
                {
                    pingList.Clear();
                }
                else if (settings.survivorMaxListEntries < (pingList.Count + 1) && settings.programMode == DbDPingzMode.Surivivor)
                {
                    pingList.Clear();
                }
                pingList.TryAdd(ping.ip, ping);
            }
            else if (pingList.ContainsKey(ping.ip))
            {
                pingList[ping.ip] = ping;
            }
        }
        private void validatePingList(ConcurrentDictionary<IpV4Address, Ping> validateList)
        {
            foreach(IpV4Address ip in pingList.Keys)
            {
                TimeSpan s = DateTime.Now - pingList[ip].recievedPacketTime;
                Ping ignored;
                if(s.Seconds > 10)
                {
                    if(pingList.TryRemove(ip, out ignored))
                    {
                        Console.WriteLine("Ip:" + ip.ToString() + " timed out!");
                        removePing(ip);
                    }
                }
            }
        }

        private void callPingInfoSubscribers()
        {
            foreach (accessPingInfoControlsSafely subscriber in pingInformationSubscriberList)
            {
                this.Invoke(subscriber,new object[] {pingList});
            }
            validatePingList(pingList);
        }
    }
}
