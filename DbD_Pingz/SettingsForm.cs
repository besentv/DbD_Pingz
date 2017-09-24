using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class SettingsForm : Form
    {
        private Settings settings = null;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            this.maxGoodPingNumericUpDown.Value = settings.MaximumGoodPing;
            this.secondsToTimeoutNumericUpDown.Value = settings.SecondsUntilIPTimeout;
            this.chooseBadPingColorButton.BackColor = settings.BadPingColor;
            this.chooseGoodPingColorButton.BackColor = settings.GoodPingColor;      
        }

        private void ChooseGoodPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            settings.SetGoodPingColor(colorDialog1.Color);
            this.chooseGoodPingColorButton.BackColor = settings.GoodPingColor;
        }

        private void ChooseBadPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            settings.SetBadPingColor(colorDialog1.Color);
            this.chooseBadPingColorButton.BackColor = settings.BadPingColor;
        }

        private void MaximumGoodPingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.MaximumGoodPing = Convert.ToInt32(num.Value);
        }

        private void SecondsToTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.SecondsUntilIPTimeout = Convert.ToInt32(num.Value);
        }
    }
}
