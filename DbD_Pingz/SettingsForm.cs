using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class SettingsForm : Form
    {
        public Settings ProgramSettings { get; private set; } = null;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.ProgramSettings = settings;
            this.maxGoodPingNumericUpDown.Value = settings.MaximumGoodPing;
            this.secondsToTimeoutNumericUpDown.Value = settings.SecondsUntilIPTimeout;
            this.chooseBadPingColorButton.BackColor = settings.BadPingColor;
            this.chooseGoodPingColorButton.BackColor = settings.GoodPingColor;
            this.timeoutedIpRemoveNumericUpDown.Value = settings.SecondsUntilTimeoutedIpRemoved;
        }

        private void ChooseGoodPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ProgramSettings.GoodPingColor;
            colorDialog1.ShowDialog();
            ProgramSettings.SetGoodPingColor(colorDialog1.Color);
            this.chooseGoodPingColorButton.BackColor = ProgramSettings.GoodPingColor;
        }

        private void ChooseBadPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ProgramSettings.BadPingColor;
            colorDialog1.ShowDialog();
            ProgramSettings.SetBadPingColor(colorDialog1.Color);
            this.chooseBadPingColorButton.BackColor = ProgramSettings.BadPingColor;
        }

        private void MaximumGoodPingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ProgramSettings.MaximumGoodPing = (Convert.ToInt32(num.Value));
        }

        private void SecondsToTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ProgramSettings.SecondsUntilIPTimeout = (Convert.ToInt32(num.Value));
        }

        private void timeoutedIpRemoveNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ProgramSettings.SecondsUntilTimeoutedIpRemoved = (Convert.ToInt32(num.Value));
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.WriteSettingsToXML(DbDPingz.saveXMLFileName, ProgramSettings);
        }
    }
}
