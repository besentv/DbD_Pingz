using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class SettingsForm : Form
    {
        public Settings Settings { get; private set; } = null;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.Settings = settings;
            this.maxGoodPingNumericUpDown.Value = settings.MaximumGoodPing;
            this.secondsToTimeoutNumericUpDown.Value = settings.SecondsUntilIPTimeout;
            this.chooseBadPingColorButton.BackColor = settings.BadPingColor;
            this.chooseGoodPingColorButton.BackColor = settings.GoodPingColor;
            this.timeoutedIpRemoveNumericUpDown.Value = settings.SecondsUntilTimeoutedIpRemoved;
        }

        private void ChooseGoodPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.GoodPingColor;
            colorDialog1.ShowDialog();
            Settings.SetGoodPingColor(colorDialog1.Color);
            this.chooseGoodPingColorButton.BackColor = Settings.GoodPingColor;
        }

        private void ChooseBadPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.BadPingColor;
            colorDialog1.ShowDialog();
            Settings.SetBadPingColor(colorDialog1.Color);
            this.chooseBadPingColorButton.BackColor = Settings.BadPingColor;
        }

        private void MaximumGoodPingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            Settings.MaximumGoodPing = Convert.ToInt32(num.Value);
        }

        private void SecondsToTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            Settings.SecondsUntilIPTimeout = Convert.ToInt32(num.Value);
        }

        private void timeoutedIpRemoveNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            Settings.SecondsUntilTimeoutedIpRemoved = Convert.ToInt32(num.Value);
        }
    }
}
