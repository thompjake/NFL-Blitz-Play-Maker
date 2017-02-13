using NFLBlitzFans.PlayMaker.Models;
using NFLBlitzFans.PlayMaker.Models.PlayBookFormat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                memoryPackPlayBook.Name = fs.ReadStringTo(type.PlayBookNameOffset, 6);
                memoryPackPlayBook.PinNumber = fs.ReadStringTo(type.PlayBookPinOffset, 4);
                memoryPackPlayBook.Plays = new BindingList<BlitzPlay>();
                for(int z = 0; z < type.PlaysPerPlayBook; z++)
                { 
                BlitzPlay blitzPlay = new BlitzPlay();
                blitzPlay.Name = FileStreamExtensionMethods.ReadStringTo(fs, type.PlayNameOffset + (z*type.PlayNameIncrement),15);
                //for each player get their routes
                blitzPlay.Players = new List<BlitzPlayer>();
                int routeCount = 0;
                    for (int x = 0; x < type.PlayerTypeOrder.Length; x++)
                    {
                        // Get each route
                        BlitzPlayer player = new BlitzPlayer();
                        player.PlayerType = type.PlayerTypeOrder[x];
                        player.RouteCoordinates = new List<System.Drawing.Point>();
                        player.Actions = new List<BlitzActionEnum>();
                        for (int y = 0; y < type.PlayerRouteLimit; y++)
                        {
                            long routeStart = type.PlayerRouteOffset + (z * type.PlayNameIncrement) + (type.PlayerRouteIncrement * routeCount++);
                            //get x cord
                            fs.Position = routeStart + type.PlayerXOffsetFromStart;
                            int playerX = fs.ReadByte();
                            // Get y cord
                            fs.Position = routeStart + type.PlayerYOffsetFromStart;
                            int playerY = fs.ReadByte();
                            // Get Action
                            fs.Position = routeStart + type.PlayerActionOffsetFromStart;
                            int playerAction = fs.ReadByte();
                            // Create route cord
                              player.RouteCoordinates.Add(new System.Drawing.Point() { X = playerX, Y = playerY });
                            player.Actions.Add(IntToActionFactory.CreateBlitzActionEnum(playerAction));
                        }
                        blitzPlay.Players.Add(player);
                    }
                    memoryPackPlayBook.Plays.Add(blitzPlay);
                }
            }

            return memoryPackPlayBook;
        }

        public void WriteMemoryPackPlays(string fileLocation, MemoryPack type,PlayBook memoryPackPlayBook)
        {
            //Write Play Book
            using (var fs = new FileStream(fileLocation, FileMode.Open, FileAccess.ReadWrite))
            {
                fs.WriteStringToFile(memoryPackPlayBook.Name, type.PlayBookNameOffset);
                fs.WriteStringToFile(memoryPackPlayBook.PinNumber, type.PlayBookPinOffset);
                for (int z = 0; z < type.PlaysPerPlayBook; z++)
                {
                    BlitzPlay blitzPlay = memoryPackPlayBook.Plays[z];
                     fs.WriteStringToFile(blitzPlay.Name, type.PlayNameOffset + (z * type.PlayNameIncrement));
                    int routeCount = 0;
                    for (int x = 0; x < type.PlayerTypeOrder.Length; x++)
                    {
                        BlitzPlayer player = memoryPackPlayBook.Plays[z].Players[x];
                        // Write each route
                        player.PlayerType = type.PlayerTypeOrder[x];
                        for (int y = 0; y < type.PlayerRouteLimit; y++)
                        {
                            long routeStart = type.PlayerRouteOffset + (z * type.PlayNameIncrement) + (type.PlayerRouteIncrement * routeCount++);
                            if (player.RouteCoordinates.Count != 0 && player.RouteCoordinates.Count > y)
                            {
                                //get x cord
                                fs.Position = routeStart + type.PlayerXOffsetFromStart;
                                fs.WriteByte((byte)player.RouteCoordinates[y].X);
                                // Get y cord
                                fs.Position = routeStart + type.PlayerYOffsetFromStart;
                                fs.WriteByte((byte)player.RouteCoordinates[y].Y);
                                // Get Action
                                fs.Position = routeStart + type.PlayerActionOffsetFromStart;
                                // fs.WriteByte((byte)player.Actions[y]); TODO:
                            }
                            else
                            {
                                fs.Position = routeStart + type.PlayerXOffsetFromStart;
                                fs.Write(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);
                            }
                        }
                    }
                }
            }
        }

    }
}
