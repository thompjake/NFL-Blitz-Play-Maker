using NFLBlitzFans.PlayMaker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Helpers
{
    public class MemoryPackReadWrite
    {
        public PlayBook ReadMemoryPackPlays(string fileLocation)
        {
            PlayBook memoryPackPlayBook = new PlayBook();
            //Read Play Book
            using (var fs = new FileStream(fileLocation,FileMode.Open,FileAccess.Read))
            {
                
            }

            return memoryPackPlayBook;
        }

    }
}
