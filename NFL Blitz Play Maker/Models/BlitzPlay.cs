using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NFLBlitzFans.PlayMaker.Models
{
    public class BlitzPlay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Strings"));
            }
        }

        public List<BlitzPlayer> Players { get; set; }




        public static List<BlitzPlayer> defaultPlayerLocation()
        {
            List<BlitzPlayer> defaultPlayers = new List<BlitzPlayer>();
            // LM 1
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.Linemen,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(17, 8) }
            });
            // LM 2
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.Linemen,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(20, 8) }
            });
            // LM 3
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.Linemen,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(23, 8) }
            });
            // QB
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.QB,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(20, 7) }
            });
            // WR 1
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.WR,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(12, 5) }
            });
            // WR 2
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.WR,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(10, 8) }
            });
            // WR 3
            defaultPlayers.Add(new BlitzPlayer()
            {
                Actions = new List<BlitzActionEnum>() { BlitzActionEnum.Nothing },
                PlayerType = BlitzPlayerType.WR,
                RouteCoordinates = new List<System.Drawing.Point>() { new System.Drawing.Point(28, 8) }
            });
            return defaultPlayers;
        }
    }
}
