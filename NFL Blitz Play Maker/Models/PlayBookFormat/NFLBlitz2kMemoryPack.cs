using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models.PlayBookFormat
{
    /// <summary>
    /// N64 NFL Blitz 2000
    /// MPK memory locations in decimal format
    /// </summary>
    class NFLBlitz2kMemoryPack : MemoryPack
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
                return 12760;
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
                return 12766;
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
                return 12790;
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
                return 12770;
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
