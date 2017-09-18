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




        private ConcurrentDictionary<IpV4Address, TimeSpan> pingList = new ConcurrentDictionary<IpV4Address, TimeSpan>();
        private List<Action> pingInformationSubscriberList = new List<Action>();
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
            pingInformationSubscriberList.Add(new Action(this.setPing));
            //    pingInformationSubscriberList.Add(new Action(this.addPingToChart));
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

        public void setPing()
        {
            if (list.InvokeRequired)
            {
                Action caller = new Action(setPing);
                this.Invoke(caller);
            }

            else
            {
                if (pingList.Count > 0)
                {
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
                                list[1, i].Value = pingList[address].Milliseconds.ToString() + "ms";
                                listHasEntry = true;
                                if (pingList[address].Milliseconds >= settings.maxGoodPing)
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
                            if (settings.programMode == DbDPingzMode.Killer)
                            {
                                if (list.Rows.Count > settings.killerMaxListEntries)
                                {
                                    list.Rows.Clear();
                                }
                            }
                            else if (settings.programMode == DbDPingzMode.Surivivor)
                            {
                                if (list.Rows.Count > settings.survivorMaxListEntries)
                                {
                                    list.Rows.Clear();
                                }
                            }
                            string[] row = new string[2];
                            row[0] = address.ToString();
                            row[1] = pingList[address].Milliseconds.ToString() + "ms";
                            int rowNum;
                            rowNum = list.Rows.Add(row);
                            if (pingList[address].Milliseconds >= settings.maxGoodPing)
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

        private void addPingToChart()
        {
            if (pingHistoryChart.InvokeRequired)
            {
                Action caller = new Action(addPingToChart);
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
                            pingHistoryChart.Series[address.ToString()].BorderWidth = 4;

                        }
                        if (pingList[address].Milliseconds > 0)
                        {
                            pingHistoryChart.Series[address.ToString()].Points.AddXY(chartCounter, pingList[address].Milliseconds);
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
            foreach (Series s in pingHistoryChart.Series)
            {
                pingHistoryChart.Series[s.Name].Points.Clear();
            }
            chartCounter = 0;
            pingHistoryChart.Series.Clear();
            pingHistoryChart.ChartAreas[0].AxisX.ScaleView.Scroll(chartCounter);
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












        public void getPings(object sender, CalculatedPingEventArgs args)
        {
            this.fillPingList(args.remoteIpV4Address, args.ping);
        }

        private void updateControls(object sender, EventArgs e)
        {
            callPingInfoSubscribers();
        }

        private void fillPingList(IpV4Address ip, TimeSpan timeSpan)
        {
            if (!pingList.ContainsKey(ip))
            {
                if (settings.killerMaxListEntries < (pingList.Count + 1) && settings.programMode == DbDPingzMode.Killer)
                {
                    pingList.Clear();
                }
                else if (settings.survivorMaxListEntries < (pingList.Count + 1) && settings.programMode == DbDPingzMode.Surivivor)
                {
                    pingList.Clear();
                }
                pingList.TryAdd(ip, timeSpan);
            }
            else if (pingList.ContainsKey(ip))
            {
                pingList[ip] = timeSpan;
            }
        }
        private void callPingInfoSubscribers()
        {
            foreach (Action subscriber in pingInformationSubscriberList)
            {
                this.Invoke(subscriber);
            }
            pingList.Clear();
        }
    }
}
