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
using NFLBlitzFans.PlayMaker.Models;

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
            List<PlayBook> playBooks = new List<PlayBook>();
            playBooks.Add(memoryPackReader.ReadMemoryPackPlays(@"C:\Program Files (x86)\Project64 1.6\Save\blitz2k.mpk", new NFLBlitz2kMemoryPack()));
            cbSelectPlayBook.DataSource = playBooks;
            cbSelectPlayBook.DisplayMember = "Name";
        }

        private void cbSelectPlayBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSelectBlitzPlay.DataSource = ((PlayBook)cbSelectPlayBook.SelectedItem).Plays;
            cbSelectBlitzPlay.DisplayMember = "Name";
        }

        private void cbSelectBlitzPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            picCanvas.DrawyPlayers(((BlitzPlay)cbSelectBlitzPlay.SelectedItem).Players);
        }
    }
}
