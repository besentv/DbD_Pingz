using PcapDotNet.Packets.IpV4;
using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;
using System.IO;

namespace DbD_Pingz
{
    public partial class PingList : Form
    {
        private bool formIsUsed = false;
        public int selectedNetworkAdapter = -1;
        private NetworkChooser adapterChooser;
        private BackgroundWorker networkingBackgroundWorker;
        private Dictionary<IpV4Address, DateTime> lastResponse = new Dictionary<IpV4Address, DateTime>();
        private delegate void setPingSafeDelegate(IpV4Address ip, TimeSpan ping);
        private IList<IPAddress> ownIpAdresses;
        public int selectedLocalIp = -1;
        private DataGridView.HitTestInfo lastHitItem;

        public PingList()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            networkingBackgroundWorker = new BackgroundWorker();
            networkingBackgroundWorker.DoWork += sniff;
            networkingBackgroundWorker.WorkerSupportsCancellation = true;
            networkingBackgroundWorker.RunWorkerAsync();
            ownIpAdresses = GetLocalIPv4Addresses();
        }

        private Dictionary<IpV4Address, DateTime> waitingForResponse;

        public void sniff(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            waitingForResponse = new Dictionary<IpV4Address, DateTime>();
            IList<LivePacketDevice> devices = LivePacketDevice.AllLocalMachine;

            Console.WriteLine("Device amount:" + devices.Count);
            if (devices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                networkingBackgroundWorker.CancelAsync();
            }
            adapterChooser = new NetworkChooser(this);
            adapterChooser.setLists(devices, ownIpAdresses);
            Console.WriteLine("Amount of local IP adresses:" + ownIpAdresses.Count);
            do
            {
                adapterChooser.ShowDialog();
            } while ((selectedNetworkAdapter < 0 || selectedNetworkAdapter > (devices.Count - 1)) || (selectedLocalIp < 0 || selectedLocalIp > (ownIpAdresses.Count - 1)));
            PacketDevice selectedDevice = devices[selectedNetworkAdapter];
            devices = null;

            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {

                Console.WriteLine("Listening on device:" + selectedDevice.Description + "...");
                communicator.ReceivePackets(0, RecieveCallback);
                communicator.SetFilter("ip and udp");
            }
        }
        private void RecieveCallback(Packet packet)
        {
            IpV4Address ownIp;
            IpV4Address.TryParse(ownIpAdresses[selectedLocalIp].ToString(), out ownIp);
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (waitingForResponse.ContainsKey(ip.Source))
            {
                if (udp.Payload.Length == 68 && ip.Destination == ownIp && udp.Payload[0] == 0x01)//STUN Reply from OTHER Ip! First payload byte for a STUN response is 1. 
                {
                    DateTime requestTime;
                    waitingForResponse.TryGetValue(ip.Source, out requestTime);
                    TimeSpan timeElapsed = packet.Timestamp - requestTime;
                    Console.WriteLine("First 5 bytes:"+ udp.Payload[0] + "," + udp.Payload[1] + "," + udp.Payload[2] + "," + udp.Payload[3] + "," + udp.Payload[4]);
                    Console.WriteLine("Ip:" + ip.Source + " Ping:" + timeElapsed.Milliseconds + "ms");
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
                    }
                }
                if (!listHasEntry)
                {
                    string[] row = new string[2];
                    row[0] = ip.ToString();
                    row[1] = ping.Milliseconds.ToString() + "ms";
                    list.Rows.Add(row);
                }
            }
        }

        public void removePing(IpV4Address ip)
        {
            if (!formIsUsed)
            {
                foreach (DataGridViewRow row in list.Rows)
                {
                    if (String.Compare(row.Cells["IP"].Value.ToString(), ip.ToString()) == 0)
                    {
                        list.Rows.Remove(row);
                    }
                }
            }
        }

        private void onFormClosed(object sender, FormClosedEventArgs e)
        {
            networkingBackgroundWorker.CancelAsync();
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            if (!formIsUsed)
            {
                list.Rows.Clear();
            }
        }

        public static List<IPAddress> GetLocalIPv4Addresses()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            List<IPAddress> adresses = new List<IPAddress>();
            foreach (IPAddress adr in host.AddressList)
            {
                if (adr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    adresses.Add(adr);
                }
            }
            return adresses;
        }

        private void ipRightKlickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Whois this IP")
            {
                //Console.WriteLine("LOL2");
                //Console.WriteLine(whoisIpMethod("http://ipinfo.io/" + list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString() + "/json"));
                // new WhoisInfo(whoisIpMethod("http://ipinfo.io/" + list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString() + "/json")).ShowDialog();
                BackgroundWorker whoisLookupWorker = new BackgroundWorker();
                whoisLookupWorker.DoWork += new DoWorkEventHandler(whoisAndShowForm);
                whoisLookupWorker.RunWorkerAsync(list[lastHitItem.ColumnIndex, lastHitItem.RowIndex].Value.ToString());
            }
        }
        private void whoisAndShowForm(object sender, DoWorkEventArgs e)
        {
            string ip = (string)e.Argument;
            string jsonString;
            if ((jsonString = whoisIpMethod("http://ipinfo.io/" + ip + "/json")) != null)
            {
                new WhoisInfo(jsonString).ShowDialog(this);
            }
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = list.HitTest(e.X, e.Y);
                lastHitItem = hit;
                if (hit.ColumnIndex == 0 && hit.RowIndex >= 0)
                {
                    //Console.WriteLine("LOL_" + hit.ColumnIndex);
                    list.ClearSelection();
                    list[hit.ColumnIndex, hit.RowIndex].Selected = true;
                    ipRightKlickMenu.Show(list, e.Location);

                }
            }
        }

        private string whoisIpMethod(string requestUrl)
        {
            WebRequest wr = WebRequest.Create(requestUrl);
            wr.Method = "GET";
            WebResponse response = wr.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return content;
        }
    }
}
