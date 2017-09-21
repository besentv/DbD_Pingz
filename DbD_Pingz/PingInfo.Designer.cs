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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pingInfoList = new System.Windows.Forms.DataGridView();
            this.ipRightKlickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisIp = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDbDPingzTopmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingInfoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataTicker = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ipColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoList)).BeginInit();
            this.ipRightKlickMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pingInfoList
            // 
            this.pingInfoList.AllowUserToAddRows = false;
            this.pingInfoList.AllowUserToDeleteRows = false;
            this.pingInfoList.AllowUserToResizeRows = false;
            this.pingInfoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pingInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pingInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipColumn,
            this.PingColumn});
            this.pingInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pingInfoList.Location = new System.Drawing.Point(0, 0);
            this.pingInfoList.Name = "pingInfoList";
            this.pingInfoList.ReadOnly = true;
            this.pingInfoList.RowHeadersVisible = false;
            this.pingInfoList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pingInfoList.Size = new System.Drawing.Size(471, 131);
            this.pingInfoList.TabIndex = 0;
            this.pingInfoList.TabStop = false;
            this.pingInfoList.SelectionChanged += new System.EventHandler(this.pingInfoList_SelectionChanged);
            this.pingInfoList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
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
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(475, 24);
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
            // pingInfoChart
            // 
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.IntervalOffset = 1D;
            chartArea3.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.ScaleView.MinSize = 20D;
            chartArea3.AxisX.ScaleView.Position = 0D;
            chartArea3.AxisX.ScaleView.Size = 20D;
            chartArea3.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.ScrollBar.Enabled = false;
            chartArea3.AxisX.Title = "Time";
            chartArea3.AxisY.Interval = 25D;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.IsMarginVisible = false;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.ScaleView.Size = 250D;
            chartArea3.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.ScrollBar.Enabled = false;
            chartArea3.AxisY.Title = "Ping";
            chartArea3.Name = "pingChartArea";
            this.pingInfoChart.ChartAreas.Add(chartArea3);
            this.pingInfoChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.IsTextAutoFit = false;
            legend3.MaximumAutoSize = 30F;
            legend3.Name = "Legend1";
            this.pingInfoChart.Legends.Add(legend3);
            this.pingInfoChart.Location = new System.Drawing.Point(0, 0);
            this.pingInfoChart.Margin = new System.Windows.Forms.Padding(0);
            this.pingInfoChart.Name = "pingInfoChart";
            this.pingInfoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.pingInfoChart.Size = new System.Drawing.Size(471, 290);
            this.pingInfoChart.TabIndex = 3;
            this.pingInfoChart.Text = "chart1";
            // 
            // dataTicker
            // 
            this.dataTicker.Interval = 1000;
            this.dataTicker.Tick += new System.EventHandler(this.callPingInfoSubscribers);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pingInfoList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pingInfoChart);
            this.splitContainer1.Size = new System.Drawing.Size(475, 433);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 4;
            // 
            // ipColumn
            // 
            this.ipColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ipColumn.HeaderText = "IP";
            this.ipColumn.Name = "ipColumn";
            this.ipColumn.ReadOnly = true;
            this.ipColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PingColumn
            // 
            this.PingColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PingColumn.HeaderText = "Ping";
            this.PingColumn.Name = "PingColumn";
            this.PingColumn.ReadOnly = true;
            this.PingColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 457);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "PingInfo";
            this.Text = "DbD pingz";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoList)).EndInit();
            this.ipRightKlickMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView pingInfoList;
        private System.Windows.Forms.ContextMenuStrip ipRightKlickMenu;
        private System.Windows.Forms.ToolStripMenuItem whoisIp;
        private System.Windows.Forms.ToolStripMenuItem resetTableToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDbDPingzTopmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart pingInfoChart;
        private System.Windows.Forms.Timer dataTicker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingColumn;
    }
}