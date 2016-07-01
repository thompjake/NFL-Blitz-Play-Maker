using NFLBlitzFans.PlayMaker.Models;
using NFLBlitzFans.PlayMaker.Models.PlayBookFormat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Helpers
{
    public class MemoryPackReadWrite
    {
        public PlayBook ReadMemoryPackPlays(string fileLocation,MemoryPack type)
        {
            PlayBook memoryPackPlayBook = new PlayBook();
            //Read Play Book
            using (var fs = new FileStream(fileLocation,FileMode.Open,FileAccess.Read))
               {
                memoryPackPlayBook.Name = FileStreamHelper.ReadStringTo(fs, type.PlayBookNameOffset, 6);
                memoryPackPlayBook.PinNumber = FileStreamHelper.ReadStringTo(fs, type.PlayBookPinOffset, 4);
                memoryPackPlayBook.Plays = new List<BlitzPlay>();
                BlitzPlay blitzPlay = new BlitzPlay();
                blitzPlay.Name = FileStreamHelper.ReadStringTo(fs, type.PlayNameOffset,15);
                memoryPackPlayBook.Plays.Add(blitzPlay);
            }

            return memoryPackPlayBook;
        }

    }
}
