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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingInfo));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pingInfoList = new System.Windows.Forms.DataGridView();
            this.ipColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipRightKlickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisIp = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDbDPingzTopmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNetworkAdapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingInfoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataTicker = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelNoAdapter1 = new System.Windows.Forms.Label();
            this.labelNoAdapter2 = new System.Windows.Forms.Label();
            this.networkingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.previousPingInfoList = new System.Windows.Forms.DataGridView();
            this.Ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastConnectionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewImageColumn();
            this.IsValveISP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.previousPingInfoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisThisIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoList)).BeginInit();
            this.ipRightKlickMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previousPingInfoList)).BeginInit();
            this.previousPingInfoContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pingInfoList
            // 
            this.pingInfoList.AllowUserToAddRows = false;
            this.pingInfoList.AllowUserToDeleteRows = false;
            this.pingInfoList.AllowUserToResizeRows = false;
            this.pingInfoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.pingInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pingInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipColumn,
            this.PingColumn,
            this.DataLoss});
            this.pingInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pingInfoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.pingInfoList.Location = new System.Drawing.Point(0, 0);
            this.pingInfoList.MultiSelect = false;
            this.pingInfoList.Name = "pingInfoList";
            this.pingInfoList.ReadOnly = true;
            this.pingInfoList.RowHeadersVisible = false;
            this.pingInfoList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pingInfoList.Size = new System.Drawing.Size(467, 138);
            this.pingInfoList.TabIndex = 0;
            this.pingInfoList.TabStop = false;
            this.pingInfoList.SelectionChanged += new System.EventHandler(this.PingInfoList_SelectionChanged);
            this.pingInfoList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.List_MouseClick);
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
            // DataLoss
            // 
            this.DataLoss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataLoss.HeaderText = "PacketsLost (Experimental)";
            this.DataLoss.Name = "DataLoss";
            this.DataLoss.ReadOnly = true;
            this.DataLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ipRightKlickMenu
            // 
            this.ipRightKlickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoisIp,
            this.resetTableToolStripMenuItem});
            this.ipRightKlickMenu.Name = "contextMenuStrip1";
            this.ipRightKlickMenu.Size = new System.Drawing.Size(179, 48);
            this.ipRightKlickMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.IpRightKlickMenu_ItemClicked);
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
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "porgramMenuStrip";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeDbDPingzTopmostToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.changeNetworkAdapterToolStripMenuItem,
            this.reportBugToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // makeDbDPingzTopmostToolStripMenuItem
            // 
            this.makeDbDPingzTopmostToolStripMenuItem.CheckOnClick = true;
            this.makeDbDPingzTopmostToolStripMenuItem.Name = "makeDbDPingzTopmostToolStripMenuItem";
            this.makeDbDPingzTopmostToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.makeDbDPingzTopmostToolStripMenuItem.Text = "DbD Pingz Is Topmost";
            this.makeDbDPingzTopmostToolStripMenuItem.Click += new System.EventHandler(this.MakeDbDPingzTopmostToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // changeNetworkAdapterToolStripMenuItem
            // 
            this.changeNetworkAdapterToolStripMenuItem.Name = "changeNetworkAdapterToolStripMenuItem";
            this.changeNetworkAdapterToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.changeNetworkAdapterToolStripMenuItem.Text = "Change Network Adapter";
            this.changeNetworkAdapterToolStripMenuItem.Click += new System.EventHandler(this.ChangeNetworkAdapterToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportBugToolStripMenuItem.Image")));
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.reportBugToolStripMenuItem.Text = "Report An Issue On GitHub";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pingInfoChart
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IntervalOffset = 1D;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.ScaleView.MinSize = 20D;
            chartArea2.AxisX.ScaleView.Position = 0D;
            chartArea2.AxisX.ScaleView.Size = 20D;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScrollBar.Enabled = false;
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.Interval = 25D;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsMarginVisible = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.ScaleView.Size = 250D;
            chartArea2.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.ScrollBar.Enabled = false;
            chartArea2.AxisY.Title = "Ping";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea2.BorderWidth = 0;
            chartArea2.Name = "pingChartArea";
            this.pingInfoChart.ChartAreas.Add(chartArea2);
            this.pingInfoChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pingInfoChart.IsSoftShadows = false;
            legend2.IsTextAutoFit = false;
            legend2.MaximumAutoSize = 30F;
            legend2.Name = "Legend1";
            this.pingInfoChart.Legends.Add(legend2);
            this.pingInfoChart.Location = new System.Drawing.Point(0, 40);
            this.pingInfoChart.Margin = new System.Windows.Forms.Padding(0);
            this.pingInfoChart.Name = "pingInfoChart";
            this.pingInfoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.pingInfoChart.Size = new System.Drawing.Size(467, 316);
            this.pingInfoChart.TabIndex = 3;
            this.pingInfoChart.Text = "chart1";
            this.pingInfoChart.MouseEnter += new System.EventHandler(this.PingInfoChart_MouseEnter);
            this.pingInfoChart.MouseLeave += new System.EventHandler(this.PingInfoChart_MouseLeave);
            // 
            // dataTicker
            // 
            this.dataTicker.Enabled = true;
            this.dataTicker.Interval = 1000;
            this.dataTicker.Tick += new System.EventHandler(this.CallPingInfoSubscribers);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelNoAdapter1);
            this.splitContainer1.Panel1.Controls.Add(this.pingInfoList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pingInfoChart);
            this.splitContainer1.Panel2.Controls.Add(this.labelNoAdapter2);
            this.splitContainer1.Size = new System.Drawing.Size(471, 506);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 4;
            // 
            // labelNoAdapter1
            // 
            this.labelNoAdapter1.AutoSize = true;
            this.labelNoAdapter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNoAdapter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoAdapter1.ForeColor = System.Drawing.Color.Crimson;
            this.labelNoAdapter1.Location = new System.Drawing.Point(0, 0);
            this.labelNoAdapter1.Name = "labelNoAdapter1";
            this.labelNoAdapter1.Size = new System.Drawing.Size(485, 40);
            this.labelNoAdapter1.TabIndex = 1;
            this.labelNoAdapter1.Text = "No network adapter selected!";
            // 
            // labelNoAdapter2
            // 
            this.labelNoAdapter2.AutoSize = true;
            this.labelNoAdapter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNoAdapter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoAdapter2.ForeColor = System.Drawing.Color.Crimson;
            this.labelNoAdapter2.Location = new System.Drawing.Point(0, 0);
            this.labelNoAdapter2.Name = "labelNoAdapter2";
            this.labelNoAdapter2.Size = new System.Drawing.Size(485, 40);
            this.labelNoAdapter2.TabIndex = 2;
            this.labelNoAdapter2.Text = "No network adapter selected!";
            // 
            // networkingBackgroundWorker
            // 
            this.networkingBackgroundWorker.WorkerSupportsCancellation = true;
            this.networkingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NetworkingBackgroundWorker_DoWork);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.previousPingInfoList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(814, 506);
            this.splitContainer2.SplitterDistance = 339;
            this.splitContainer2.TabIndex = 5;
            // 
            // previousPingInfoList
            // 
            this.previousPingInfoList.AllowUserToAddRows = false;
            this.previousPingInfoList.AllowUserToDeleteRows = false;
            this.previousPingInfoList.AllowUserToResizeRows = false;
            this.previousPingInfoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.previousPingInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.previousPingInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ip,
            this.lastConnectionTime,
            this.Country,
            this.IsValveISP});
            this.previousPingInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousPingInfoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.previousPingInfoList.Location = new System.Drawing.Point(0, 0);
            this.previousPingInfoList.MultiSelect = false;
            this.previousPingInfoList.Name = "previousPingInfoList";
            this.previousPingInfoList.ReadOnly = true;
            this.previousPingInfoList.RowHeadersVisible = false;
            this.previousPingInfoList.Size = new System.Drawing.Size(339, 506);
            this.previousPingInfoList.TabIndex = 0;
            this.previousPingInfoList.SelectionChanged += new System.EventHandler(this.PreviousPingInfoList_SelectionChanged);
            this.previousPingInfoList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PreviousPingInfoList_MouseClick);
            // 
            // Ip
            // 
            this.Ip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ip.HeaderText = "IP";
            this.Ip.Name = "Ip";
            this.Ip.ReadOnly = true;
            this.Ip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lastConnectionTime
            // 
            this.lastConnectionTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastConnectionTime.HeaderText = "Last time connected at";
            this.lastConnectionTime.Name = "lastConnectionTime";
            this.lastConnectionTime.ReadOnly = true;
            this.lastConnectionTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // IsValveISP
            // 
            this.IsValveISP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsValveISP.HeaderText = "Valve ISP";
            this.IsValveISP.Name = "IsValveISP";
            this.IsValveISP.ReadOnly = true;
            // 
            // previousPingInfoContextMenu
            // 
            this.previousPingInfoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoisThisIPToolStripMenuItem,
            this.resetTableToolStripMenuItem1,
            this.killToolStripMenuItem});
            this.previousPingInfoContextMenu.Name = "previousPingInfoContextMenu";
            this.previousPingInfoContextMenu.Size = new System.Drawing.Size(315, 70);
            this.previousPingInfoContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PreviousPingInfoContextMenu_ItemClicked);
            // 
            // whoisThisIPToolStripMenuItem
            // 
            this.whoisThisIPToolStripMenuItem.Name = "whoisThisIPToolStripMenuItem";
            this.whoisThisIPToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.whoisThisIPToolStripMenuItem.Text = "Whois this IP";
            // 
            // resetTableToolStripMenuItem1
            // 
            this.resetTableToolStripMenuItem1.Name = "resetTableToolStripMenuItem1";
            this.resetTableToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            this.resetTableToolStripMenuItem1.Text = "Reset Table";
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.killToolStripMenuItem.Text = ":( (Needs elevated privileges)";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 530);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "PingInfo";
            this.Text = "DbD pingz";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PingInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoList)).EndInit();
            this.ipRightKlickMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingInfoChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previousPingInfoList)).EndInit();
            this.previousPingInfoContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem changeNetworkAdapterToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker networkingBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label labelNoAdapter1;
        private System.Windows.Forms.Label labelNoAdapter2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView previousPingInfoList;
        private System.Windows.Forms.ContextMenuStrip previousPingInfoContextMenu;
        private System.Windows.Forms.ToolStripMenuItem whoisThisIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTableToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastConnectionTime;
        private System.Windows.Forms.DataGridViewImageColumn Country;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsValveISP;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataLoss;
    }
}