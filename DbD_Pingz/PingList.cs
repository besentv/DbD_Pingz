using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;

namespace DbD_Pingz
{
    public partial class PingList : Form
    {
        public int selectedNetworkAdapter = -1;
        private NetworkChooser adapterChooser;
        private BackgroundWorker networkingBackgroundWorker;
        private Dictionary<IpV4Address, DateTime> lastResponse = new Dictionary<IpV4Address, DateTime>();
        private delegate void setPingSafeDelegate(IpV4Address ip, TimeSpan ping);
        private delegate void removePingSafeDelegate(IpV4Address ip);
        private IpV4Address ownIp;
        private DataGridView.HitTestInfo lastHitItem;
        private Settings settings;
        private const string saveXMLFileName = "DbD_PingTestSave.xml";

        public PingList()
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
        }

        private void NetworkingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Environment.Exit(1);
        }

        public void sniff(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            waitingForResponse = new Dictionary<IpV4Address, DateTime>();
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
            string internet = "Internet ";
            string ownIpString;
            foreach (DeviceAddress address in selectedDevice.Addresses)
            {
                Console.WriteLine("Local IP:" + address.Address);
                if (address.Address.Family == SocketAddressFamily.Internet)
                {
                    if (address.Address != null)
                    {
                        ownIpString = address.Address.ToString();
                        ownIpString = ownIpString.Replace(internet, "");
                        Console.WriteLine("Trying to parse IP string: '" + ownIpString + "'");
                        if (IpV4Address.TryParse(ownIpString, out ownIp) == false)
                        {
                            Console.WriteLine("ERROR - Couln't parse ownIpString! aborting...");
                            return;
                        }
                    }
                    else return;
                }
            }
            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                Console.WriteLine("Listening on device:" + selectedDevice.Description + "...");
                communicator.ReceivePackets(0, RecieveCallback);
                communicator.SetFilter("ip and udp");
            }
        }


        private Dictionary<IpV4Address, DateTime> waitingForResponse;

        private void RecieveCallback(Packet packet)
        {

            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (waitingForResponse.ContainsKey(ip.Source))
            {
                if (udp.Payload.Length == 68 && ip.Destination == ownIp && udp.Payload[0] == 0x01)//STUN Reply from OTHER Ip! First payload byte for a STUN response is 1. 
                {
                    DateTime requestTime;
                    waitingForResponse.TryGetValue(ip.Source, out requestTime);
                    TimeSpan timeElapsed = packet.Timestamp - requestTime;
                    //Console.WriteLine("First 5 bytes:\t" + udp.Payload[0] + "," + udp.Payload[1] + "," + udp.Payload[2] + "," + udp.Payload[3] + "," + udp.Payload[4]);
                    //Console.WriteLine("Ip:" + ip.Source + " Ping:" + timeElapsed.Milliseconds + "ms");
                    waitingForResponse.Remove(ip.Source);
                    setPing(ip.Source, timeElapsed);
                }
            }
            else
            {
                if (udp.Payload.Length == 56 && ip.Source == ownIp && udp.Payload[0] == 0x00) //STUN Request from OWN Ip! 
                {
                    if (!waitingForResponse.ContainsKey(ip.Destination))
                    {
                        waitingForResponse.Add(ip.Destination, packet.Timestamp);
                    }
                }
            }
        }

        public void setPing(IpV4Address ip, TimeSpan ping)
        {
            if (list.InvokeRequired)
            {
                setPingSafeDelegate caller = new setPingSafeDelegate(setPing);
                this.Invoke(caller, new object[] { ip, ping });
            }

            else
            {
                bool listHasEntry = false;
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    if (0 == String.Compare(list["IP", i].Value.ToString(), ip.ToString()))
                    {
                        list["Ping", i].Value = ping.Milliseconds.ToString() + "ms";
                        listHasEntry = true;
                        if (ping.Milliseconds >= settings.maxGoodPing)
                        {
                            list["Ping", i].Style.BackColor = settings.badPingColor;
                        }
                        else
                        {
                            list["Ping", i].Style.BackColor = settings.goodPingColor;
                        }
                    }
                }
                if (!listHasEntry)
                {
                    if (settings.programMode == DbDPingzMode.Killer)
                    {
                        if (list.Rows.Count >= settings.killerMaxListEntries)
                        {
                            list.Rows.Clear();
                        }
                    }
                    else if (settings.programMode == DbDPingzMode.Surivivor)
                    {
                        if (list.Rows.Count >= settings.survivorMaxListEntries)
                        {
                            list.Rows.Clear();
                        }
                    }
                    string[] row = new string[2];
                    row[0] = ip.ToString();
                    row[1] = ping.Milliseconds.ToString() + "ms";
                    int rowNum;
                    rowNum = list.Rows.Add(row);
                    if (ping.Milliseconds >= settings.maxGoodPing)
                    {
                        list["Ping", rowNum].Style.BackColor = settings.badPingColor;
                    }
                    else
                    {
                        list["Ping", rowNum].Style.BackColor = settings.goodPingColor;
                    }
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
                if (String.Compare(row.Cells["IP"].Value.ToString(), ip.ToString()) == 0)
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
    }
}
