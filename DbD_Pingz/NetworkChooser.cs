using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class NetworkChooser : Form
    {
        public LivePacketDevice SelectedLivePacketDevice { get; private set; } = null;
        public bool RememberDecision { get; private set; } = false;

        public NetworkChooser()
        {
            InitializeComponent();
            SetList(LivePacketDevice.AllLocalMachine);
        }

        public NetworkChooser(string deviceID)
        {
            InitializeComponent();
            SetList(LivePacketDevice.AllLocalMachine);
            SelectedLivePacketDevice = TryGetDevice(deviceID);
        }

        public void SetList(IList<LivePacketDevice> devices)
        {
            Console.WriteLine("Device amount:" + devices.Count);
            if (devices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                MessageBox.Show("No interfaces found! Make sure WinPcap is installed.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine("device " + i + "; Name:" + devices[i].Name + " Desc:" + devices[i].Description + "\n");
                networkAdapters.Items.Add(devices[i].Description);
            }
            networkAdapters.SelectedIndex = 0;
        }

        public static LivePacketDevice TryGetDevice(string deviceID)
        {
            if (deviceID != null)
            {
                foreach (LivePacketDevice device in LivePacketDevice.AllLocalMachine)
                {
                    if (device.Name.Equals(deviceID))
                    {
                        return device;
                    }
                }
            }
            return null;
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

        private void rememberDecisionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            this.RememberDecision = checkBox.Checked;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x84: //WM_NCHITTEST
                    HitTest hit = (HitTest)m.Result.ToInt32();
                    switch (hit)
                    {
                        case HitTest.Top:
                            m.Result = new IntPtr((int)HitTest.Caption);
                            break;
                        case HitTest.Bottom:
                            m.Result = new IntPtr((int)HitTest.Client);
                            break;
                        case HitTest.TopLeft:
                            m.Result = new IntPtr((int)HitTest.Left);
                            break;
                        case HitTest.BottomLeft:
                            m.Result = new IntPtr((int)HitTest.Left);
                            break;
                        case HitTest.TopRight:
                            m.Result = new IntPtr((int)HitTest.Right);
                            break;
                        case HitTest.BottomRight:
                            m.Result = new IntPtr((int)HitTest.Right);
                            break;
                    }
                    break;
            }
        }

        enum HitTest
        {
            Client = 1,
            Caption = 2,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
        }

    }
}
