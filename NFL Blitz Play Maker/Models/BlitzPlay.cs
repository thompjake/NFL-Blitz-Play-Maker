using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models
{
    public class BlitzPlay
    {
        public string Name { get; set; }
        public List<BlitzPlayer> Players { get; set; }
    }
}
