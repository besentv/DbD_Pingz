using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

namespace DbD_Pingz
{
    public partial class SettingsForm : Form
    {
        private Settings settings = null;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            this.maxGoodPingNumericUpDown.Value = settings.maxGoodPing;
            this.killerMaxListNumericUpDown.Value = settings.killerMaxListEntries;
            this.survivorMaxListNumericUpDown.Value = settings.survivorMaxListEntries;
            this.chooseBadPingColorButton.BackColor = settings.badPingColor;
            this.chooseGoodPingColorButton.BackColor = settings.goodPingColor;      
        }

        private void chooseGoodPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            settings.setGoodPingColor(colorDialog1.Color);
            this.chooseGoodPingColorButton.BackColor = settings.goodPingColor;
        }

        private void chooseBadPingColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            settings.setBadPingColor(colorDialog1.Color);
            this.chooseBadPingColorButton.BackColor = settings.badPingColor;
        }

        private void killerMaxListNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.killerMaxListEntries = Convert.ToInt32(num.Value);
        }

        private void maxGoodPingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.maxGoodPing = Convert.ToInt32(num.Value);
        }

        private void survivorMaxListNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.survivorMaxListEntries = Convert.ToInt32(num.Value);
        }
    }
}
