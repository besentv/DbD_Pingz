using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class NetworkChooser : Form
    {
        PingList parent;
        public NetworkChooser(PingList parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public void setLists(IList<LivePacketDevice> devices)
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }
            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine("device " + i + "; Name:" + devices[i].Name + " Desc:" + devices[i].Description + "\n");
                networkAdapters.Items.Add(devices[i].Description);


            }
        }

        private void networkAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.selectedNetworkAdapter = networkAdapters.SelectedIndex;
            //if (parent.selectedLocalIp >= 0 && parent.selectedNetworkAdapter >= 0)
            //{
            //    this.Close();
            //}
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
