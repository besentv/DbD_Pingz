﻿using System;
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
            this.maxGoodPingNumericUpDown.Value = settings.maxGoodPing;
            this.secondsToTimeoutNumericUpDown.Value = settings.SecondsUntilIPTimeout;
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

        private void maxGoodPingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.maxGoodPing = Convert.ToInt32(num.Value);
        }

        private void secondsToTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            settings.SecondsUntilIPTimeout = Convert.ToInt32(num.Value);
        }
    }
}
