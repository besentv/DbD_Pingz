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
            this.ipRightKlickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisIp = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDbDPingzTopmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.survivorModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.ipRightKlickMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.AllowUserToResizeColumns = false;
            this.list.AllowUserToResizeRows = false;
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.Ping});
            this.list.Location = new System.Drawing.Point(12, 27);
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list.Size = new System.Drawing.Size(331, 250);
            this.list.TabIndex = 0;
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
            // 
            // ip
            // 
            this.ip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // Ping
            // 
            this.Ping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ping.HeaderText = "Ping";
            this.Ping.Name = "Ping";
            this.Ping.ReadOnly = true;
            // 
            // ipRightKlickMenu
            // 
            this.ipRightKlickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoisIp,
            this.resetTableToolStripMenuItem});
            this.ipRightKlickMenu.Name = "contextMenuStrip1";
            this.ipRightKlickMenu.Size = new System.Drawing.Size(179, 48);
            this.ipRightKlickMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ipRightKlickMenu_ItemClicked);
            // 
            // whoisIp
            // 
            this.whoisIp.Name = "whoisIp";
            this.whoisIp.Size = new System.Drawing.Size(178, 22);
            this.whoisIp.Text = "Whois this IP";
            // 
            // resetTableToolStripMenuItem
            // 
            this.resetTableToolStripMenuItem.Name = "resetTableToolStripMenuItem";
            this.resetTableToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.resetTableToolStripMenuItem.Text = "Reset table";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(355, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "porgramMenuStrip";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeDbDPingzTopmostToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // makeDbDPingzTopmostToolStripMenuItem
            // 
            this.makeDbDPingzTopmostToolStripMenuItem.CheckOnClick = true;
            this.makeDbDPingzTopmostToolStripMenuItem.Name = "makeDbDPingzTopmostToolStripMenuItem";
            this.makeDbDPingzTopmostToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.makeDbDPingzTopmostToolStripMenuItem.Text = "DbD Pingz Is Topmost";
            this.makeDbDPingzTopmostToolStripMenuItem.Click += new System.EventHandler(this.makeDbDPingzTopmostToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killerModeToolStripMenuItem,
            this.survivorModeToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // killerModeToolStripMenuItem
            // 
            this.killerModeToolStripMenuItem.Checked = true;
            this.killerModeToolStripMenuItem.CheckOnClick = true;
            this.killerModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.killerModeToolStripMenuItem.Enabled = false;
            this.killerModeToolStripMenuItem.Name = "killerModeToolStripMenuItem";
            this.killerModeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.killerModeToolStripMenuItem.Text = "Killer Mode";
            this.killerModeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.killerModeToolStripMenuItem_CheckedChanged);
            // 
            // survivorModeToolStripMenuItem
            // 
            this.survivorModeToolStripMenuItem.CheckOnClick = true;
            this.survivorModeToolStripMenuItem.Name = "survivorModeToolStripMenuItem";
            this.survivorModeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.survivorModeToolStripMenuItem.Text = "Survivor Mode";
            this.survivorModeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.survivorModeToolStripMenuItem_CheckedChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // PingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 289);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "PingList";
            this.Text = "DbD pingz";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ipRightKlickMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.ContextMenuStrip ipRightKlickMenu;
        private System.Windows.Forms.ToolStripMenuItem whoisIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ping;
        private System.Windows.Forms.ToolStripMenuItem resetTableToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDbDPingzTopmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem survivorModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}