namespace FileManager.Presentation.WinSite
{
    partial class frmAirports
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
            this.originCbo = new System.Windows.Forms.ComboBox();
            this.destinationCbo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // originCbo
            // 
            this.originCbo.FormattingEnabled = true;
            this.originCbo.Location = new System.Drawing.Point(94, 69);
            this.originCbo.Name = "originCbo";
            this.originCbo.Size = new System.Drawing.Size(185, 21);
            this.originCbo.TabIndex = 0;
            this.originCbo.SelectedIndexChanged += new System.EventHandler(this.originCbo_SelectedIndexChanged_1);
            // 
            // destinationCbo
            // 
            this.destinationCbo.FormattingEnabled = true;
            this.destinationCbo.Location = new System.Drawing.Point(94, 220);
            this.destinationCbo.Name = "destinationCbo";
            this.destinationCbo.Size = new System.Drawing.Size(185, 21);
            this.destinationCbo.TabIndex = 1;
            this.destinationCbo.SelectedIndexChanged += new System.EventHandler(this.destinationCbo_SelectedIndexChanged_1);
            // 
            // frmAirports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 450);
            this.Controls.Add(this.destinationCbo);
            this.Controls.Add(this.originCbo);
            this.Name = "frmAirports";
            this.Text = "frmAirports";
            this.Load += new System.EventHandler(this.frmAirports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox originCbo;
        private System.Windows.Forms.ComboBox destinationCbo;
    }
}