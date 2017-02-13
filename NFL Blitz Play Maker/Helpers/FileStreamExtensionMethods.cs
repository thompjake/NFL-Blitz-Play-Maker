using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Helpers
{
    public static class FileStreamExtensionMethods
    {

        public static string ReadStringTo(this FileStream fs, long offset, int length)
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

        public static void WriteStringToFile(this FileStream fs, string toBeWritten, long offset)
        {
            if (string.IsNullOrEmpty(toBeWritten))
                return;
                fs.Position = offset;
                foreach (char letter in toBeWritten)
                {
                    fs.WriteByte(Convert.ToByte(letter));
                }
        }

    }
}
