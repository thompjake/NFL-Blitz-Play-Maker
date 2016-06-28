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
    }
}
