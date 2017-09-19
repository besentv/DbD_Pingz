namespace DbD_Pingz
{
    partial class PingInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.list = new System.Windows.Forms.DataGridView();
            this.ipColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipRightKlickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisIp = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDbDPingzTopmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.survivorModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingHistoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataTicker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.ipRightKlickMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingHistoryChart)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.AllowUserToResizeColumns = false;
            this.list.AllowUserToResizeRows = false;
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipColumn,
            this.PingColumn});
            this.list.Location = new System.Drawing.Point(12, 27);
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list.Size = new System.Drawing.Size(503, 122);
            this.list.TabIndex = 0;
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
            // 
            // ipColumn
            // 
            this.ipColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ipColumn.HeaderText = "IP";
            this.ipColumn.Name = "ipColumn";
            this.ipColumn.ReadOnly = true;
            // 
            // PingColumn
            // 
            this.PingColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PingColumn.HeaderText = "Ping";
            this.PingColumn.Name = "PingColumn";
            this.PingColumn.ReadOnly = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(527, 24);
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
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            // pingHistoryChart
            // 
            this.pingHistoryChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IntervalOffset = 1D;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.ScaleView.MinSize = 20D;
            chartArea2.AxisX.ScaleView.Position = 0D;
            chartArea2.AxisX.ScaleView.Size = 20D;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScrollBar.Enabled = false;
            chartArea2.AxisY.Interval = 25D;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IsMarginVisible = false;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.ScaleView.Size = 200D;
            chartArea2.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.ScrollBar.Enabled = false;
            chartArea2.AxisY.Title = "Ping";
            chartArea2.Name = "pingChartArea";
            this.pingHistoryChart.ChartAreas.Add(chartArea2);
            legend2.IsTextAutoFit = false;
            legend2.MaximumAutoSize = 30F;
            legend2.Name = "Legend1";
            this.pingHistoryChart.Legends.Add(legend2);
            this.pingHistoryChart.Location = new System.Drawing.Point(13, 155);
            this.pingHistoryChart.Margin = new System.Windows.Forms.Padding(0);
            this.pingHistoryChart.Name = "pingHistoryChart";
            this.pingHistoryChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.pingHistoryChart.Size = new System.Drawing.Size(502, 290);
            this.pingHistoryChart.TabIndex = 3;
            this.pingHistoryChart.Text = "chart1";
            // 
            // dataTicker
            // 
            this.dataTicker.Interval = 1000;
            this.dataTicker.Tick += new System.EventHandler(this.updateControls);
            // 
            // PingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 457);
            this.Controls.Add(this.pingHistoryChart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.list);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "PingInfo";
            this.Text = "DbD pingz";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ipRightKlickMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingHistoryChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.ContextMenuStrip ipRightKlickMenu;
        private System.Windows.Forms.ToolStripMenuItem whoisIp;
        private System.Windows.Forms.ToolStripMenuItem resetTableToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDbDPingzTopmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem survivorModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart pingHistoryChart;
        private System.Windows.Forms.Timer dataTicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingColumn;
    }
}