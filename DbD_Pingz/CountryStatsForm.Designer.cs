namespace DbD_Pingz
{
    partial class CountryStatsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryStatsForm));
            this.countryStatsDataGridView = new System.Windows.Forms.DataGridView();
            this.countrycode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryFlag = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.countryStatsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // countryStatsDataGridView
            // 
            this.countryStatsDataGridView.AllowUserToAddRows = false;
            this.countryStatsDataGridView.AllowUserToDeleteRows = false;
            this.countryStatsDataGridView.AllowUserToOrderColumns = true;
            this.countryStatsDataGridView.AllowUserToResizeRows = false;
            this.countryStatsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.countryStatsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countrycode,
            this.Amount,
            this.CountryFlag});
            this.countryStatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countryStatsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.countryStatsDataGridView.Name = "countryStatsDataGridView";
            this.countryStatsDataGridView.ReadOnly = true;
            this.countryStatsDataGridView.RowHeadersVisible = false;
            this.countryStatsDataGridView.Size = new System.Drawing.Size(516, 328);
            this.countryStatsDataGridView.TabIndex = 0;
            this.countryStatsDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.countryStatsDataGridView_RowsAdded);
            // 
            // countrycode
            // 
            this.countrycode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countrycode.DataPropertyName = "countrycode";
            this.countrycode.HeaderText = "Country Code";
            this.countrycode.Name = "countrycode";
            this.countrycode.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // CountryFlag
            // 
            this.CountryFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CountryFlag.HeaderText = "Country Flag";
            this.CountryFlag.Name = "CountryFlag";
            this.CountryFlag.ReadOnly = true;
            // 
            // CountryStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 328);
            this.Controls.Add(this.countryStatsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CountryStatsForm";
            this.Text = "Country Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.countryStatsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView countryStatsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn countrycode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn CountryFlag;
    }
}