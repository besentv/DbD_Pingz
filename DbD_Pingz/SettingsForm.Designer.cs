namespace DbD_Pingz
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label2 = new System.Windows.Forms.Label();
            this.maxGoodPingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseGoodPingColorButton = new System.Windows.Forms.Button();
            this.chooseBadPingColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.secondsToTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.timeoutedIpRemoveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.chartPaletteSelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.useAveragePingCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pingInfoChartWidthUpdown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsToTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutedIpRemoveNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChartWidthUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max. good ping:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // maxGoodPingNumericUpDown
            // 
            this.maxGoodPingNumericUpDown.Location = new System.Drawing.Point(227, 61);
            this.maxGoodPingNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxGoodPingNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxGoodPingNumericUpDown.Name = "maxGoodPingNumericUpDown";
            this.maxGoodPingNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.maxGoodPingNumericUpDown.TabIndex = 3;
            this.maxGoodPingNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxGoodPingNumericUpDown.ValueChanged += new System.EventHandler(this.MaximumGoodPingNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Good ping color:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chooseGoodPingColorButton
            // 
            this.chooseGoodPingColorButton.Location = new System.Drawing.Point(192, 87);
            this.chooseGoodPingColorButton.Name = "chooseGoodPingColorButton";
            this.chooseGoodPingColorButton.Size = new System.Drawing.Size(120, 33);
            this.chooseGoodPingColorButton.TabIndex = 4;
            this.chooseGoodPingColorButton.UseVisualStyleBackColor = true;
            this.chooseGoodPingColorButton.Click += new System.EventHandler(this.ChooseGoodPingColorButton_Click);
            // 
            // chooseBadPingColorButton
            // 
            this.chooseBadPingColorButton.Location = new System.Drawing.Point(192, 126);
            this.chooseBadPingColorButton.Name = "chooseBadPingColorButton";
            this.chooseBadPingColorButton.Size = new System.Drawing.Size(120, 33);
            this.chooseBadPingColorButton.TabIndex = 5;
            this.chooseBadPingColorButton.UseVisualStyleBackColor = true;
            this.chooseBadPingColorButton.Click += new System.EventHandler(this.ChooseBadPingColorButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bad ping color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seconds until timeout:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // secondsToTimeoutNumericUpDown
            // 
            this.secondsToTimeoutNumericUpDown.Location = new System.Drawing.Point(227, 9);
            this.secondsToTimeoutNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondsToTimeoutNumericUpDown.Name = "secondsToTimeoutNumericUpDown";
            this.secondsToTimeoutNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.secondsToTimeoutNumericUpDown.TabIndex = 1;
            this.secondsToTimeoutNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondsToTimeoutNumericUpDown.ValueChanged += new System.EventHandler(this.SecondsToTimeoutNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Seconds until timeouted ip remove:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timeoutedIpRemoveNumericUpDown
            // 
            this.timeoutedIpRemoveNumericUpDown.Location = new System.Drawing.Point(227, 35);
            this.timeoutedIpRemoveNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutedIpRemoveNumericUpDown.Name = "timeoutedIpRemoveNumericUpDown";
            this.timeoutedIpRemoveNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.timeoutedIpRemoveNumericUpDown.TabIndex = 2;
            this.timeoutedIpRemoveNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutedIpRemoveNumericUpDown.ValueChanged += new System.EventHandler(this.timeoutedIpRemoveNumericUpDown_ValueChanged);
            // 
            // chartPaletteSelect
            // 
            this.chartPaletteSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chartPaletteSelect.FormattingEnabled = true;
            this.chartPaletteSelect.Items.AddRange(new object[] {
            "None",
            "Bright",
            "Grayscale",
            "Excel",
            "Light",
            "Pastel",
            "EarthTones",
            "SemiTransparent",
            "Berry",
            "Chocolate",
            "Fire",
            "SeaGreen",
            "BrightPastel"});
            this.chartPaletteSelect.Location = new System.Drawing.Point(192, 165);
            this.chartPaletteSelect.Name = "chartPaletteSelect";
            this.chartPaletteSelect.Size = new System.Drawing.Size(120, 21);
            this.chartPaletteSelect.TabIndex = 6;
            this.chartPaletteSelect.SelectedIndexChanged += new System.EventHandler(this.chartPaletteSelect_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ping info chart color palette:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Use average ping:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // useAveragePingCheckBox
            // 
            this.useAveragePingCheckBox.AutoSize = true;
            this.useAveragePingCheckBox.Location = new System.Drawing.Point(192, 192);
            this.useAveragePingCheckBox.Name = "useAveragePingCheckBox";
            this.useAveragePingCheckBox.Size = new System.Drawing.Size(15, 14);
            this.useAveragePingCheckBox.TabIndex = 7;
            this.useAveragePingCheckBox.UseVisualStyleBackColor = true;
            this.useAveragePingCheckBox.CheckedChanged += new System.EventHandler(this.useAveragePingCheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ping info chart width:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pingInfoChartWidthUpdown
            // 
            this.pingInfoChartWidthUpdown.Location = new System.Drawing.Point(227, 212);
            this.pingInfoChartWidthUpdown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.pingInfoChartWidthUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pingInfoChartWidthUpdown.Name = "pingInfoChartWidthUpdown";
            this.pingInfoChartWidthUpdown.Size = new System.Drawing.Size(85, 20);
            this.pingInfoChartWidthUpdown.TabIndex = 8;
            this.pingInfoChartWidthUpdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pingInfoChartWidthUpdown.ValueChanged += new System.EventHandler(this.pingInfoChartWidthUpdown_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(320, 246);
            this.Controls.Add(this.pingInfoChartWidthUpdown);
            this.Controls.Add(this.useAveragePingCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chartPaletteSelect);
            this.Controls.Add(this.timeoutedIpRemoveNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.secondsToTimeoutNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chooseBadPingColorButton);
            this.Controls.Add(this.chooseGoodPingColorButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxGoodPingNumericUpDown);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsToTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutedIpRemoveNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChartWidthUpdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxGoodPingNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseGoodPingColorButton;
        private System.Windows.Forms.Button chooseBadPingColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown secondsToTimeoutNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown timeoutedIpRemoveNumericUpDown;
        private System.Windows.Forms.ComboBox chartPaletteSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox useAveragePingCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown pingInfoChartWidthUpdown;
    }
}