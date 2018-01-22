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
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsToTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutedIpRemoveNumericUpDown)).BeginInit();
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
            this.label5.TabIndex = 0;
            this.label5.Text = "Seconds until timeouted ip remove:";
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
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(320, 167);
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
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsToTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutedIpRemoveNumericUpDown)).EndInit();
            this.ResumeLayout(false);

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
    }
}