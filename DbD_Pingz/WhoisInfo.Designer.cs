namespace DbD_Pingz
{
    partial class WhoisInfo
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
            this.whoisText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // whoisText
            // 
            this.whoisText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whoisText.Font = new System.Drawing.Font("DejaVu Sans Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whoisText.Location = new System.Drawing.Point(0, 0);
            this.whoisText.MinimumSize = new System.Drawing.Size(100, 100);
            this.whoisText.Name = "whoisText";
            this.whoisText.ReadOnly = true;
            this.whoisText.Size = new System.Drawing.Size(386, 324);
            this.whoisText.TabIndex = 0;
            this.whoisText.TabStop = false;
            this.whoisText.Text = "";
            // 
            // WhoisInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 324);
            this.Controls.Add(this.whoisText);
            this.MinimumSize = new System.Drawing.Size(90, 90);
            this.Name = "WhoisInfo";
            this.Text = "WhoisInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox whoisText;
    }
}