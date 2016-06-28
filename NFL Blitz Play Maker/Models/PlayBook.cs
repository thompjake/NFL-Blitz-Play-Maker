using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models
{
    public class PlayBook
    { 
        public string Name { get; set; }
        public string PinNumber { get; set; }
        public List<BlitzPlay> Plays { get; set; }
    }
}
