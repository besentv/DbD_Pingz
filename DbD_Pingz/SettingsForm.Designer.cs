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
            this.label1 = new System.Windows.Forms.Label();
            this.killerMaxListNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.maxGoodPingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseGoodPingColorButton = new System.Windows.Forms.Button();
            this.chooseBadPingColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.survivorMaxListNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.killerMaxListNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.survivorMaxListNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Killer max. list entries:";
            // 
            // killerMaxListNumericUpDown
            // 
            this.killerMaxListNumericUpDown.Location = new System.Drawing.Point(172, 12);
            this.killerMaxListNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.killerMaxListNumericUpDown.Name = "killerMaxListNumericUpDown";
            this.killerMaxListNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.killerMaxListNumericUpDown.TabIndex = 2;
            this.killerMaxListNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.killerMaxListNumericUpDown.ValueChanged += new System.EventHandler(this.killerMaxListNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max. good ping:";
            // 
            // maxGoodPingNumericUpDown
            // 
            this.maxGoodPingNumericUpDown.Location = new System.Drawing.Point(172, 64);
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
            this.maxGoodPingNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxGoodPingNumericUpDown.TabIndex = 4;
            this.maxGoodPingNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxGoodPingNumericUpDown.ValueChanged += new System.EventHandler(this.maxGoodPingNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Good ping color:";
            // 
            // chooseGoodPingColorButton
            // 
            this.chooseGoodPingColorButton.Location = new System.Drawing.Point(172, 90);
            this.chooseGoodPingColorButton.Name = "chooseGoodPingColorButton";
            this.chooseGoodPingColorButton.Size = new System.Drawing.Size(120, 33);
            this.chooseGoodPingColorButton.TabIndex = 6;
            this.chooseGoodPingColorButton.UseVisualStyleBackColor = true;
            this.chooseGoodPingColorButton.Click += new System.EventHandler(this.chooseGoodPingColorButton_Click);
            // 
            // chooseBadPingColorButton
            // 
            this.chooseBadPingColorButton.Location = new System.Drawing.Point(172, 129);
            this.chooseBadPingColorButton.Name = "chooseBadPingColorButton";
            this.chooseBadPingColorButton.Size = new System.Drawing.Size(120, 33);
            this.chooseBadPingColorButton.TabIndex = 7;
            this.chooseBadPingColorButton.UseVisualStyleBackColor = true;
            this.chooseBadPingColorButton.Click += new System.EventHandler(this.chooseBadPingColorButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bad ping color:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Survivor max. list entries:";
            // 
            // survivorMaxListNumericUpDown
            // 
            this.survivorMaxListNumericUpDown.Location = new System.Drawing.Point(172, 38);
            this.survivorMaxListNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.survivorMaxListNumericUpDown.Name = "survivorMaxListNumericUpDown";
            this.survivorMaxListNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.survivorMaxListNumericUpDown.TabIndex = 10;
            this.survivorMaxListNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.survivorMaxListNumericUpDown.ValueChanged += new System.EventHandler(this.survivorMaxListNumericUpDown_ValueChanged);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(302, 178);
            this.Controls.Add(this.survivorMaxListNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chooseBadPingColorButton);
            this.Controls.Add(this.chooseGoodPingColorButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxGoodPingNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.killerMaxListNumericUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.killerMaxListNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGoodPingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.survivorMaxListNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown killerMaxListNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxGoodPingNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseGoodPingColorButton;
        private System.Windows.Forms.Button chooseBadPingColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown survivorMaxListNumericUpDown;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}