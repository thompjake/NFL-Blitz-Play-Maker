using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models.PlayBookFormat
{
    /// <summary>
    /// ROm locations for playbooks in blitzmaster5000 NFL Blitz 200 hacked rom
    /// MPK memory locations in decimal format
    /// </summary>
    class HackedRom : MemoryPack
    {
        public override int PlayBookNameIncrement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long PlayBookNameOffset
        {
            get
            {
                return 16637904;
            }
        }

        public override int PlayBookPinIncrement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long PlayBookPinOffset
        {
            get
            {
                return 16637910;
            }
        }

        public override int PlayerActionOffsetFromStart
        {
            get
            {
                return 3;
            }
        }

        public override int PlayerRouteLimit
        {
            get
            {
                return 8;
            }
        }

        public override long PlayerRouteOffset
        {
            get
            {
                return 16637934;
            }
        }

        public override int PlayerRouteIncrement
        {
            get
            {
                return 4;
            }
        }

        public override int PlayerXOffsetFromStart
        {
            get
            {
                return 0;
            }
        }

        public override int PlayerYOffsetFromStart
        {
            get
            {
                return 1;
            }
        }

        public override int PlayNameIncrement
        {
            get
            {
                return 274;
            }
        }

        public override long PlayNameOffset
        {
            get
            {
                return 16637914;
            }
        }

        public override BlitzPlayerType[] PlayerTypeOrder
        {
            get
            {
                return new BlitzPlayerType[] { BlitzPlayerType.Linemen, BlitzPlayerType.Linemen, BlitzPlayerType.Linemen, BlitzPlayerType.QB, BlitzPlayerType.WR, BlitzPlayerType.WR, BlitzPlayerType.WR };
            }
        }

        public override int PlaysPerPlayBook
        {
            get
            {
                return 8;
            }
        }
    }
}
