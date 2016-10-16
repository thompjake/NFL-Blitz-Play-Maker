using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker
{
    public static class IntToActionFactory
    {
        public static BlitzActionEnum CreateBlitzActionEnum(int blitzAction)
        {
            switch(blitzAction)
            {

                case 1 :
                    return BlitzActionEnum.Juke;
                case 136:
                    return BlitzActionEnum.Block;
                case 2:
                    return BlitzActionEnum.Spin;
                case 16:
                    return BlitzActionEnum.Turbo;
                case 32:
                    return BlitzActionEnum.Wave;
                case 64:
                    return BlitzActionEnum.Delay;
                default:
                    return BlitzActionEnum.Nothing;
            }
        }

    }
}
