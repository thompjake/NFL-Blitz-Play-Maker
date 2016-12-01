using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models
{
    public class PlayBook
    { 
        public string Name { get; set; }
        public string PinNumber { get; set; }
        public BindingList<BlitzPlay> Plays { get; set; }
    }
}
