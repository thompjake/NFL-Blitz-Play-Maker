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
                memoryPackPlayBook.Name = FileStreamHelper.ReadStringTo(fs, type.PlayBookNameOffset, 6);
                memoryPackPlayBook.PinNumber = FileStreamHelper.ReadStringTo(fs, type.PlayBookPinOffset, 4);
                memoryPackPlayBook.Plays = new BindingList<BlitzPlay>();
                for(int z = 0; z < type.PlaysPerPlayBook; z++)
                { 
                BlitzPlay blitzPlay = new BlitzPlay();
                blitzPlay.Name = FileStreamHelper.ReadStringTo(fs, type.PlayNameOffset + (z*type.PlayNameIncrement),15);
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

    }
}
