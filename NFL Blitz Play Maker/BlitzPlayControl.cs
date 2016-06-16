using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NFLBlitzFans.PlayMaker
{
    public static class BlitzPlayEditorHelper
    {
        public static Point FlipCoordinates(int x, int y,PictureBox pb)
        {
            return new Point() { X = pb.Width - x, Y = pb.Height - y };
        }


    }
}
