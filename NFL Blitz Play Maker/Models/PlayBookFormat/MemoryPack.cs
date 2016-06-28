using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models.PlayBookFormat
{
    abstract class MemoryPack
    {
        //offset locations 
        abstract public long PlayBookNameOffset { get; }
        abstract public int PlayBookNameIncrement { get;  }
        abstract public long PlayBookPinOffset { get; }
        abstract public int PlayBookPinIncrement { get; }

        abstract public long PlayNameOffset { get;  }
        abstract public int PlayNameIncrement { get;  }
    }
}
