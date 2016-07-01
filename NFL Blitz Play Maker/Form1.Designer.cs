
using NFLBlitzFans.PlayMaker.Controls;
namespace NFLBlitzFans.PlayMaker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nbpmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPlaybookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picCanvas = new NFLBlitzFans.PlayMaker.Controls.BlitzPlayMaker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nbpmMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nbpmMenu
            // 
            this.nbpmMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPlaybookToolStripMenuItem});
            this.nbpmMenu.Name = "nbpmMenu";
            this.nbpmMenu.Size = new System.Drawing.Size(37, 20);
            this.nbpmMenu.Text = "File";
            // 
            // loadPlaybookToolStripMenuItem
            // 
            this.loadPlaybookToolStripMenuItem.Name = "loadPlaybookToolStripMenuItem";
            this.loadPlaybookToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadPlaybookToolStripMenuItem.Text = "Load Playbook";
            this.loadPlaybookToolStripMenuItem.Click += new System.EventHandler(this.loadPlaybookToolStripMenuItem_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.picCanvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picCanvas.BackgroundImage")));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(309, 4);
            this.picCanvas.MaximumSize = new System.Drawing.Size(600, 660);
            this.picCanvas.MinimumSize = new System.Drawing.Size(390, 630);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(600, 660);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 676);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NFL Blitz Play Maker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BlitzPlayMaker picCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nbpmMenu;
        private System.Windows.Forms.ToolStripMenuItem loadPlaybookToolStripMenuItem;
    }
}

