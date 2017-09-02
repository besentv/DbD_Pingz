namespace DbD_Pingz
{
    partial class PingList
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
            this.components = new System.ComponentModel.Container();
            this.list = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetButton = new System.Windows.Forms.Button();
            this.ipRightKlickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisIp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.ipRightKlickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.AllowUserToResizeRows = false;
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.Ping});
            this.list.Location = new System.Drawing.Point(13, 13);
            this.list.Name = "list";
            this.list.RowHeadersVisible = false;
            this.list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list.Size = new System.Drawing.Size(405, 228);
            this.list.TabIndex = 0;
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
            // 
            // ip
            // 
            this.ip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            // 
            // Ping
            // 
            this.Ping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ping.HeaderText = "Ping";
            this.Ping.Name = "Ping";
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(12, 247);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(406, 33);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // ipRightKlickMenu
            // 
            this.ipRightKlickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoisIp});
            this.ipRightKlickMenu.Name = "contextMenuStrip1";
            this.ipRightKlickMenu.Size = new System.Drawing.Size(179, 26);
            this.ipRightKlickMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ipRightKlickMenu_ItemClicked);
            // 
            // whoisIp
            // 
            this.whoisIp.Name = "whoisIp";
            this.whoisIp.Size = new System.Drawing.Size(178, 22);
            this.whoisIp.Text = "Whois this IP";
            // 
            // PingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 282);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "PingList";
            this.Text = "DbD pingz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ipRightKlickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ContextMenuStrip ipRightKlickMenu;
        private System.Windows.Forms.ToolStripMenuItem whoisIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ping;
    }
}