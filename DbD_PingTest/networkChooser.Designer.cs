namespace DbD_Pingz
{
    partial class NetworkChooser
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
            this.networkAdapters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPs = new System.Windows.Forms.ComboBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // networkAdapters
            // 
            this.networkAdapters.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.networkAdapters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkAdapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkAdapters.FormattingEnabled = true;
            this.networkAdapters.Location = new System.Drawing.Point(12, 25);
            this.networkAdapters.Name = "networkAdapters";
            this.networkAdapters.Size = new System.Drawing.Size(332, 21);
            this.networkAdapters.TabIndex = 1;
            this.networkAdapters.SelectedIndexChanged += new System.EventHandler(this.networkAdapters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a network adapter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose your local IP:";
            // 
            // IPs
            // 
            this.IPs.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.IPs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IPs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IPs.FormattingEnabled = true;
            this.IPs.Location = new System.Drawing.Point(12, 65);
            this.IPs.Name = "IPs";
            this.IPs.Size = new System.Drawing.Size(332, 21);
            this.IPs.TabIndex = 3;
            this.IPs.SelectedIndexChanged += new System.EventHandler(this.IPs_SelectedIndexChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.Location = new System.Drawing.Point(269, 92);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 4;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // NetworkChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 121);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.IPs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkAdapters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NetworkChooser";
            this.Text = "DbD Pingz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox networkAdapters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox IPs;
        private System.Windows.Forms.Button buttonDone;
    }
}