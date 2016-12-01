
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
            this.cbSelectPlayBook = new System.Windows.Forms.ComboBox();
            this.cbSelectBlitzPlay = new System.Windows.Forms.ComboBox();
            this.btnAddPlaybook = new System.Windows.Forms.Button();
            this.btnAddPlay = new System.Windows.Forms.Button();
            this.picCanvas = new NFLBlitzFans.PlayMaker.Controls.BlitzPlayMaker();
            this.btnSavePlayChange = new System.Windows.Forms.Button();
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
            // cbSelectPlayBook
            // 
            this.cbSelectPlayBook.FormattingEnabled = true;
            this.cbSelectPlayBook.Location = new System.Drawing.Point(12, 107);
            this.cbSelectPlayBook.Name = "cbSelectPlayBook";
            this.cbSelectPlayBook.Size = new System.Drawing.Size(121, 21);
            this.cbSelectPlayBook.TabIndex = 3;
            this.cbSelectPlayBook.SelectedIndexChanged += new System.EventHandler(this.cbSelectPlayBook_SelectedIndexChanged);
            // 
            // cbSelectBlitzPlay
            // 
            this.cbSelectBlitzPlay.FormattingEnabled = true;
            this.cbSelectBlitzPlay.Location = new System.Drawing.Point(12, 151);
            this.cbSelectBlitzPlay.Name = "cbSelectBlitzPlay";
            this.cbSelectBlitzPlay.Size = new System.Drawing.Size(121, 21);
            this.cbSelectBlitzPlay.TabIndex = 4;
            this.cbSelectBlitzPlay.SelectedIndexChanged += new System.EventHandler(this.cbSelectBlitzPlay_SelectedIndexChanged);
            // 
            // btnAddPlaybook
            // 
            this.btnAddPlaybook.Location = new System.Drawing.Point(139, 105);
            this.btnAddPlaybook.Name = "btnAddPlaybook";
            this.btnAddPlaybook.Size = new System.Drawing.Size(103, 23);
            this.btnAddPlaybook.TabIndex = 5;
            this.btnAddPlaybook.Text = "Add Playbook";
            this.btnAddPlaybook.UseVisualStyleBackColor = true;
            this.btnAddPlaybook.Click += new System.EventHandler(this.btnAddPlaybook_Click);
            // 
            // btnAddPlay
            // 
            this.btnAddPlay.Location = new System.Drawing.Point(139, 149);
            this.btnAddPlay.Name = "btnAddPlay";
            this.btnAddPlay.Size = new System.Drawing.Size(103, 23);
            this.btnAddPlay.TabIndex = 6;
            this.btnAddPlay.Text = "Add Play";
            this.btnAddPlay.UseVisualStyleBackColor = true;
            this.btnAddPlay.Click += new System.EventHandler(this.btnAddPlay_Click);
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
            // btnSavePlayChange
            // 
            this.btnSavePlayChange.Location = new System.Drawing.Point(139, 178);
            this.btnSavePlayChange.Name = "btnSavePlayChange";
            this.btnSavePlayChange.Size = new System.Drawing.Size(103, 23);
            this.btnSavePlayChange.TabIndex = 7;
            this.btnSavePlayChange.Text = "Save Play Changes";
            this.btnSavePlayChange.UseVisualStyleBackColor = true;
            this.btnSavePlayChange.Click += new System.EventHandler(this.btnSavePlayChange_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 676);
            this.Controls.Add(this.btnSavePlayChange);
            this.Controls.Add(this.btnAddPlay);
            this.Controls.Add(this.btnAddPlaybook);
            this.Controls.Add(this.cbSelectBlitzPlay);
            this.Controls.Add(this.cbSelectPlayBook);
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
        private System.Windows.Forms.ComboBox cbSelectPlayBook;
        private System.Windows.Forms.ComboBox cbSelectBlitzPlay;
        private System.Windows.Forms.Button btnAddPlaybook;
        private System.Windows.Forms.Button btnAddPlay;
        private System.Windows.Forms.Button btnSavePlayChange;
    }
}

