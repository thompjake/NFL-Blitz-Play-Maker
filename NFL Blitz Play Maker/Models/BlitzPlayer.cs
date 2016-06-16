using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NFLBlitzFans.PlayMaker
{

    public enum BlitzPlayerType
    {
        WR,
        Linemen,
        QB
    }

    public class BlitzPlayer
    {
        public List<Point> RouteCoordinates { get; set; }
        public List<BlitzActionEnum> Actions { get; set; }
        public BlitzPlayerType PlayerType {get; set;}
        public BlitzPlayer()
        {
            Actions = new List<BlitzActionEnum>();
            RouteCoordinates = new List<Point>();
        }

    }
}
