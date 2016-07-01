using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using NFLBlitzFans.PlayMaker.Helpers;
using NFLBlitzFans.PlayMaker.Models.PlayBookFormat;

namespace NFLBlitzFans.PlayMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void loadPlaybookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load MPK
            MemoryPackReadWrite memoryPackReader = new MemoryPackReadWrite();
            memoryPackReader.ReadMemoryPackPlays(@"C:\Program Files (x86)\Project64 1.6\Save\blitz2k.mpk", new NFLBlitz2kMemoryPack());
        }
    }
}
