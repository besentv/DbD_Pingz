using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class NetworkChooser : Form
    {
        public LivePacketDevice SelectedLivePacketDevice { get; private set; } = null;

        public NetworkChooser()
        {
            InitializeComponent();
            SetList(LivePacketDevice.AllLocalMachine);
        }

        public void SetList(IList<LivePacketDevice> devices)
        {
            Console.WriteLine("Device amount:" + devices.Count);
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

        private void NetworkAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedLivePacketDevice = LivePacketDevice.AllLocalMachine[networkAdapters.SelectedIndex];
            Console.WriteLine("Selected device:" + SelectedLivePacketDevice.Name);
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
