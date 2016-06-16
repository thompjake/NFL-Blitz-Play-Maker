using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker
{
    public static class ActionIconPathFactory
    {
        public static string CreateIconPath(BlitzActionEnum blitzAction)
        {
            switch(blitzAction)
            {

                case BlitzActionEnum.Juke :
                    return "./icons/JukeIcon.png";
                case BlitzActionEnum.Block:
                    return "./icons/BlockIcon.png";
                case BlitzActionEnum.Spin:
                    return "./icons/SpinIcon.png";
                case BlitzActionEnum.Turbo:
                    return "./icons/TurboIcon.png";
                case BlitzActionEnum.Wave:
                    return "./icons/WaveIcon.png";
                case BlitzActionEnum.Delay:
                    return "./icons/DelayIcon.png";
                default:
                    return "./icons/nothing.png";
            }
        }

    }
}
