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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAirports));
            this.originCbo = new System.Windows.Forms.ComboBox();
            this.destinationCbo = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOrigin = new System.Windows.Forms.TextBox();
            this.lblDestiny = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originCbo
            // 
            resources.ApplyResources(this.originCbo, "originCbo");
            this.originCbo.FormattingEnabled = true;
            this.originCbo.Name = "originCbo";
            this.originCbo.SelectedIndexChanged += new System.EventHandler(this.originCbo_SelectedIndexChanged_1);
            // 
            // destinationCbo
            // 
            resources.ApplyResources(this.destinationCbo, "destinationCbo");
            this.destinationCbo.FormattingEnabled = true;
            this.destinationCbo.Name = "destinationCbo";
            this.destinationCbo.SelectedIndexChanged += new System.EventHandler(this.destinationCbo_SelectedIndexChanged_1);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1,
            this.spanishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem1
            // 
            resources.ApplyResources(this.englishToolStripMenuItem1, "englishToolStripMenuItem1");
            this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            this.englishToolStripMenuItem1.Click += new System.EventHandler(this.englishToolStripMenuItem1_Click);
            // 
            // spanishToolStripMenuItem
            // 
            resources.ApplyResources(this.spanishToolStripMenuItem, "spanishToolStripMenuItem");
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // lblOrigin
            // 
            resources.ApplyResources(this.lblOrigin, "lblOrigin");
            this.lblOrigin.Name = "lblOrigin";
            // 
            // lblDestiny
            // 
            resources.ApplyResources(this.lblDestiny, "lblDestiny");
            this.lblDestiny.Name = "lblDestiny";
            // 
            // frmAirports
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDestiny);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.destinationCbo);
            this.Controls.Add(this.originCbo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAirports";
            this.Load += new System.EventHandler(this.frmAirports_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox originCbo;
        private System.Windows.Forms.ComboBox destinationCbo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.TextBox lblOrigin;
        private System.Windows.Forms.TextBox lblDestiny;
    }
}