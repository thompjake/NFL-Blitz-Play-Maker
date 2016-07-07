using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models.PlayBookFormat
{
    public abstract class MemoryPack
    {
        //offset locations 
        abstract public long PlayBookNameOffset { get; }
        abstract public int PlayBookNameIncrement { get;  }
        abstract public long PlayBookPinOffset { get; }
        abstract public int PlayBookPinIncrement { get; }

        abstract public long PlayNameOffset { get;  }
        abstract public int PlayNameIncrement { get;  }

        abstract public long PlayerRouteOffset { get; }
        abstract public int PlayerRouteIncrement { get; }
        abstract public int PlayerXOffsetFromStart { get; }
        abstract public int PlayerYOffsetFromStart { get; }
        abstract public int PlayerActionOffsetFromStart { get; }

        abstract public int PlayerRouteLimit { get; }
        abstract public int PlaysPerPlayBook { get; }

        abstract public BlitzPlayerType[] PlayerTypeOrder { get; }

    }
}
