using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Helpers
{
   public static class FileStreamHelper
    {

        public static string ReadStringTo(FileStream fs, long offset, int length)
        {
            List<Byte> listOfBytes = new List<byte>();
            fs.Position = offset;
            for (int x = 0; x < length; x++)
            {
                byte thisByte = byte.Parse(fs.ReadByte().ToString());
                listOfBytes.Add(thisByte);
            }
            return System.Text.Encoding.ASCII.GetString(listOfBytes.ToArray());
        }

    }
}
