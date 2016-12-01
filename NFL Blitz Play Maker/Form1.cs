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

        public BindingList<PlayBook> playBooks = new BindingList<PlayBook>();

        private void loadPlaybookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load MPK
            MemoryPackReadWrite memoryPackReader = new MemoryPackReadWrite();
            playBooks = new BindingList<PlayBook>();
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
            if (cbSelectBlitzPlay.SelectedItem !=null)
            picCanvas.DrawyPlayers(((BlitzPlay)cbSelectBlitzPlay.SelectedItem).Players);
        }

        private void btnAddPlaybook_Click(object sender, EventArgs e)
        {
            playBooks.Add(new PlayBook() { Name = cbSelectPlayBook.Text, Plays = new BindingList<BlitzPlay>() });
        }

        private void btnAddPlay_Click(object sender, EventArgs e)
        {
            //Look for an empty play (no name) if there isnt one create a new play
            var emptyPlay = ((PlayBook)cbSelectPlayBook.SelectedItem).Plays.FirstOrDefault(p => string.IsNullOrEmpty(p.Name.Trim()) || p.Name.Equals("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"));
            if (emptyPlay != null)
            {
                emptyPlay.Name = cbSelectBlitzPlay.Text;
                emptyPlay.Players = BlitzPlay.defaultPlayerLocation();
            }
            else
            {
                ((PlayBook)cbSelectPlayBook.SelectedItem).Plays.Add(new BlitzPlay() { Name = cbSelectBlitzPlay.Text, Players = BlitzPlay.defaultPlayerLocation() });
            }
        }

        private void btnSavePlayChange_Click(object sender, EventArgs e)
        {
            ((BlitzPlay)cbSelectBlitzPlay.SelectedItem).Players = picCanvas.GetPlayers();
        }
    }
}
