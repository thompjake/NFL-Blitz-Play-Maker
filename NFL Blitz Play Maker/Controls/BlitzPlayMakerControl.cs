using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NFLBlitzFans.PlayMaker;

namespace NFLBlitzFans.PlayMaker.Controls
{
    public partial class BlitzPlayMaker : PictureBox
    {

        // The grid spacing.
        const int grid_gap = 15;
        //
        private int LineOfScrimageYCord { get { return this.Height - grid_gap * 9; } }
        private int QBXCord { get { return grid_gap * 14; } }
        // The "size" of an object for mouse over purposes.
        private const int object_radius = 5;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        private const int over_dist_squared = object_radius * object_radius * 4;

        // List of Blitz players on the field 
        private List<BlitzPlayer> BlitzPlayers = new List<BlitzPlayer>();
        // bool for if we are currently drawing
        private bool IsDrawing = false;
        // points used when setting new route
        private Point NewPt1, NewPt2;
        // recorded x/y cords of mouse on right click
        private Point rightClickPoint;
        // Context menu for right click on editor
        private ContextMenu rightClickCM;
        // The currently selected player.
        private int selectedPlayer = -1;

        /// <summary>
        /// Constructor for Blitz Play Maker Control
        /// </summary>
        public BlitzPlayMaker()
        {
            InitializeComponent();
            //set mouse functions
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.thisMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.thisMouseMove_NotDown);

            //set drawing functions for WR and linemen 
            this.Paint += new System.Windows.Forms.PaintEventHandler(DrawPlayersAndRoutes);
            this.Resize += new System.EventHandler(this.OnResize);

            // create context menu
            rightClickCM = new ContextMenu();
            rightClickCM.MenuItems.Add("Delete Point", new EventHandler(DeletePoint));
            rightClickCM.MenuItems.Add("Default", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Nothing)));
            rightClickCM.MenuItems.Add("Juke", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Juke)));
            rightClickCM.MenuItems.Add("Spin", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Spin)));
            rightClickCM.MenuItems.Add("Block", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Block)));
            rightClickCM.MenuItems.Add("Turbo", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Turbo)));
            rightClickCM.MenuItems.Add("Wave", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Wave)));
            rightClickCM.MenuItems.Add("Delay", new EventHandler((sender, e) => SetPointAction(sender, e, BlitzActionEnum.Delay)));
        }


        #region Draw Players

        public void DrawyPlayers(List<BlitzPlayer> players)
        {
            List<BlitzPlayer> convertedPlayerList = new List<BlitzPlayer>();
            foreach (BlitzPlayer player in players)
            {
                BlitzPlayer convertedPlayer = new BlitzPlayer();
                convertedPlayer.PlayerType = player.PlayerType;
                convertedPlayer.RouteCoordinates = new List<Point>();
                convertedPlayer.Actions = new List<BlitzActionEnum>();
                for(int r = 0; r < player.RouteCoordinates.Count(); r++)
                {
                    if (player.RouteCoordinates[r].X == 0 && player.RouteCoordinates[r].Y == 0)
                    {
                        break;
                    }
                    convertedPlayer.RouteCoordinates.Add(new Point()
                    {
                        Y = this.Height - player.RouteCoordinates[r].Y * grid_gap,
                        X = player.RouteCoordinates[r].X * grid_gap
                    });
                    convertedPlayer.Actions.Add(player.Actions[r]);
                }
                convertedPlayerList.Add(convertedPlayer);
            }
            BlitzPlayers = convertedPlayerList;
            this.Refresh();
        }

        public List<BlitzPlayer> GetRawPlayerData()
        {
            List<BlitzPlayer> players = new List<PlayMaker.BlitzPlayer>();
            // Convert players back to mem pack format
            foreach (BlitzPlayer player in BlitzPlayers)
            {
                BlitzPlayer convertedPlayer = new BlitzPlayer();
                convertedPlayer.PlayerType = player.PlayerType;
                convertedPlayer.RouteCoordinates = new List<Point>();
                convertedPlayer.Actions = new List<BlitzActionEnum>();
                for (int r = 0; r < player.RouteCoordinates.Count(); r++)
                {
                    if (player.RouteCoordinates[r].X == 0 && player.RouteCoordinates[r].Y == 0)
                    {
                        break;
                    }
                    convertedPlayer.RouteCoordinates.Add(new Point()
                    {
                        Y =   (player.RouteCoordinates[r].Y / grid_gap - this.Height) * -1,
                        X = player.RouteCoordinates[r].X / grid_gap
                    });
                    convertedPlayer.Actions.Add(player.Actions[r]);
                }
                players.Add(convertedPlayer);
            }
            return players;
        }


        // Draw the lines.
        private void DrawPlayersAndRoutes(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //below ints used to draw player numbers
            int wrNumber = 1;
            int lmNumber = 1;
            string playerNumber = "";
            // for each player draw icon and routes
            for (int p = 0; p < BlitzPlayers.Count; p++)
            {
                // Draw the line segments between route points.
                for (int i = 0; i + 1 < BlitzPlayers[p].RouteCoordinates.Count; i++)
                {
                    // Draw the segment.
                    Pen playLinePen = new Pen(Brushes.Yellow);
                    playLinePen.Width = 3.0F;
                    e.Graphics.DrawLine(playLinePen, BlitzPlayers[p].RouteCoordinates[i], BlitzPlayers[p].RouteCoordinates[i + 1]);
                }
                // Draw the route end points and icons
                for (int z = 0; z < BlitzPlayers[p].RouteCoordinates.Count(); z++)
                {
                    if (z == 0)
                    {
                        // if its the first point in the list, then we draw the player
                        Bitmap playerIcon = null;
                        if (BlitzPlayers[p].PlayerType.Equals(BlitzPlayerType.WR))
                        {
                            playerNumber = wrNumber++.ToString();
                            playerIcon = new Bitmap("./icons/WR.png");
                        }
                        if (BlitzPlayers[p].PlayerType.Equals(BlitzPlayerType.Linemen))
                        {
                            playerNumber = lmNumber++.ToString();
                            playerIcon = new Bitmap("./icons/lineman.png");
                        }
                        if (BlitzPlayers[p].PlayerType.Equals(BlitzPlayerType.QB))
                        {
                            playerNumber = "";
                            playerIcon = new Bitmap("./icons/QB.png");
                        }
                        e.Graphics.DrawImage(playerIcon, BlitzPlayers[p].RouteCoordinates[z].X - playerIcon.Height / 2, BlitzPlayers[p].RouteCoordinates[z].Y - playerIcon.Width / 2, playerIcon.Width, playerIcon.Height);
                        e.Graphics.DrawString(playerNumber, new Font("Arial", 9, FontStyle.Bold), Brushes.White, BlitzPlayers[p].RouteCoordinates[z].X + 6, BlitzPlayers[p].RouteCoordinates[z].Y);
                    }
                    else
                    {
                        // else its a route endpoint
                        Rectangle rect = new Rectangle(
                         BlitzPlayers[p].RouteCoordinates[z].X - object_radius, BlitzPlayers[p].RouteCoordinates[z].Y - object_radius,
                            2 * object_radius + 1, 2 * object_radius + 1);
                        e.Graphics.FillEllipse(Brushes.Yellow, rect);
                        e.Graphics.DrawEllipse(Pens.Black, rect);
                        Bitmap actionIcon = new Bitmap(ActionIconPathFactory.CreateIconPath(BlitzPlayers[p].Actions[z]));
                        e.Graphics.DrawImage(actionIcon, BlitzPlayers[p].RouteCoordinates[z].X - actionIcon.Height / 2, BlitzPlayers[p].RouteCoordinates[z].Y - actionIcon.Width / 2, actionIcon.Width, actionIcon.Height);
                    }
                }
            }
            // If there's a new segment under constructions, draw it.
            if (IsDrawing)
            {
                e.Graphics.DrawLine(Pens.Red, NewPt1, NewPt2);
            }
        }

        #endregion Draw Players


        #region Create Background


        // Snap to the nearest grid point.
        private void SnapToGrid(ref int x, ref int y)
        {
            x = grid_gap * (int)Math.Round((double)x / grid_gap);
            y = grid_gap * (int)Math.Round((double)y / grid_gap);
        }

        /// <summary>
        /// Snhould be able to draw the gird here
        /// </summary>
        private void MakeBackgroundGrid()
        {
            ColorConverter colorConverter = new ColorConverter();
            Pen gridPen = new Pen((Color)colorConverter.ConvertFromString("#086363"), 1);
            Pen yardsPen = new Pen((Color)colorConverter.ConvertFromString("#086363"), 3);
            Bitmap bm = new Bitmap(
                this.ClientSize.Width,
                this.ClientSize.Height);

            // draw vertical lines
            for (int x = 0; x < this.ClientSize.Width; x += grid_gap)
            {   // Draw line to screen.
                using (var graphics = Graphics.FromImage(bm))
                {
                    graphics.DrawLine(gridPen, x, 0, x, this.ClientSize.Height);
                }
            }

            //Draw horizontal lines
            for (int y = this.Height; y > 0; y -= grid_gap)
            {
                // Draw line to screen.
                using (var graphics = Graphics.FromImage(bm))
                {
                    graphics.DrawLine(gridPen, 0, y, this.ClientSize.Width, y);
                    graphics.DrawLine(yardsPen, 13 * grid_gap + 5, y, 13 * grid_gap + 10, y);
                }
            }

            //Draw line of scrimmage
            using (var graphics = Graphics.FromImage(bm))
            {
                Pen scrimmagePen = new Pen((Color)colorConverter.ConvertFromString("#a70000"), 5);
                graphics.DrawLine(scrimmagePen, 0, LineOfScrimageYCord, this.Width, LineOfScrimageYCord);
            }

            //Draw yard lines
            int currentYard = 0;
            for (int y = this.Height - grid_gap * 18; y > 0; y -= grid_gap * 10)
            {
                // Draw line to screen.
                using (var graphics = Graphics.FromImage(bm))
                {
                    graphics.DrawLine(yardsPen, 0, y, this.ClientSize.Width, y);
                    currentYard += 10;
                    graphics.DrawString((currentYard).ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.White, 10, y);
                    graphics.DrawString((currentYard).ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.White, this.Width - 30, y);
                }
            }

            // Set Canvas to image we just made
            this.BackgroundImage = bm;
        }
        #endregion Create Background


        #region Mouse Functions
        // The mouse is up. See whether we're over an end point or segment.
        private void thisMouseMove_NotDown(object sender, MouseEventArgs e)
        {
            Cursor new_cursor = Cursors.Cross;

            // See what we're over.
            Point hit_point;

            if (MouseIsOverLastEndpoint(e.Location, out hit_point))
            {
                new_cursor = Cursors.Arrow;
            }
            // Set the new cursor.
            if (this.Cursor != new_cursor)
            {
                this.Cursor = new_cursor;
            }
        }

        // See what we're over and start doing whatever is appropriate.
        private void thisMouseDown(object sender, MouseEventArgs e)
        {
            // See what we're over.
            Point hit_point;

            if (e.Button.Equals(MouseButtons.Right))
            {
                if (MouseIsOverAnyEndpoint(e.Location, out hit_point))
                {
                    rightClickPoint = new Point(e.X, e.Y);
                    this.ContextMenu = rightClickCM;
                }
                else
                {
                    this.ContextMenu = null;

                    if (MouseIsOverWR(e.Location, out hit_point))
                    {
                        // Start moving this end point.
                        this.MouseMove -= thisMouseMove_NotDown;
                        this.MouseMove += MouseMove_MovingPlayer;
                        this.MouseUp += MouseUp_EndMovingEndPlayer;


                        // See if we're moving the start end point.
                        //MovingStartEndPoint =
                        // (Pt1[segment_number].Equals(hit_point));

                        // Remember the offset from the mouse to the point.
                        //OffsetX = hit_point.X - e.X;
                        //OffsetY = hit_point.Y - e.Y;
                    }

                }
                return;
            }



            if (MouseIsOverLastEndpoint(e.Location, out hit_point))
            {
                // Start drawing a new segment.
                this.MouseMove -= thisMouseMove_NotDown;
                this.MouseMove += thisMouseMove_Drawing;
                this.MouseUp += MouseUp_Drawing;

                IsDrawing = true;

                int x = e.X;
                int y = e.Y;
                SnapToGrid(ref x, ref y);
                NewPt1 = new Point(x, y);
                NewPt2 = new Point(x, y);
            }
        }
        #endregion Mouse Functions

        #region Check Mouse Location

        // See if the mouse is over an end point.
        private bool MouseIsOverAnyEndpoint(Point mouse_pt, out Point hit_pt)
        {
            for (int x = 0; x < BlitzPlayers.Count; x++)
            {
                for (int y = 1; y < BlitzPlayers[x].RouteCoordinates.Count; y++)
                    if (FindDistanceToPointSquared(mouse_pt, BlitzPlayers[x].RouteCoordinates[y]) < over_dist_squared)
                    {
                        // We're over this point.
                        hit_pt = BlitzPlayers[x].RouteCoordinates[y];
                        selectedPlayer = x;
                        return true;
                    }
            }
            hit_pt = new Point(-1, -1);
            return false;
        }

        // See if the mouse is over an end point.
        private bool MouseIsOverLastEndpoint(Point mouse_pt, out Point hit_pt)
        {
            for (int x = 0; x < BlitzPlayers.Count; x++)
            {
                if (BlitzPlayers[x].PlayerType.Equals(BlitzPlayerType.WR))
                    if (FindDistanceToPointSquared(mouse_pt, BlitzPlayers[x].RouteCoordinates[BlitzPlayers[x].RouteCoordinates.Count - 1]) < over_dist_squared)
                    {
                        // We're over this point.
                        hit_pt = BlitzPlayers[x].RouteCoordinates[BlitzPlayers[x].RouteCoordinates.Count - 1];
                        selectedPlayer = x;
                        return true;
                    }
            }
            hit_pt = new Point(-1, -1);
            return false;
        }

        // See if the mouse is over an end point.
        private bool MouseIsOverWR(Point mouse_pt, out Point hit_pt)
        {
            for (int x = 0; x < BlitzPlayers.Count; x++)
            {
                if (FindDistanceToPointSquared(mouse_pt, BlitzPlayers[x].RouteCoordinates[0]) < over_dist_squared)
                {
                    // We're over this point.
                    hit_pt = BlitzPlayers[x].RouteCoordinates[0];
                    selectedPlayer = x;
                    return true;
                }
            }
            hit_pt = new Point(-1, -1);
            return false;
        }



        // Calculate the distance squared between two points.
        private int FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            int dx = pt1.X - pt2.X;
            int dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        // Calculate the distance squared between
        // point pt and the segment p1 --> p2.
        private double FindDistanceToSegmentSquared(Point pt, Point p1, Point p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return dx * dx + dy * dy;
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return dx * dx + dy * dy;
        }
        #endregion Check Mouse Location



        #region "Drawing"

        // Give the PictureBox a grid background.
        private void OnResize(object sender, EventArgs e)
        {
            MakeBackgroundGrid();
            this.Refresh();
        }

        // We're drawing a new segment.
        private void thisMouseMove_Drawing(object sender, MouseEventArgs e)
        {
            // Save the new point.
            int x = e.X;
            int y = e.Y;
            SnapToGrid(ref x, ref y);
            NewPt2 = new Point(x, y);

            // Redraw.
            this.Invalidate();
        }

        // Stop drawing.
        private void MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            IsDrawing = false;

            // Reset the event handlers.
            this.MouseMove -= thisMouseMove_Drawing;
            this.MouseMove += thisMouseMove_NotDown;
            this.MouseUp -= MouseUp_Drawing;

            // Create the new segment.
            BlitzPlayers[selectedPlayer].RouteCoordinates.Add(NewPt2);
            BlitzPlayers[selectedPlayer].Actions.Add(BlitzActionEnum.Nothing);
            // Redraw.
            this.Invalidate();
        }

        #endregion // Drawing

        #region "Moving End Point"

        // We're moving an end point.
        private void MouseMove_MovingPlayer(object sender, MouseEventArgs e)
        {
            // Move the point to its new location.
            int x = e.X;
            int y = e.Y;
            SnapToGrid(ref x, ref y);

            //Keep QB behind center
            if (BlitzPlayers[selectedPlayer].PlayerType.Equals(BlitzPlayerType.QB))
            {
                x = QBXCord;
                if (y < LineOfScrimageYCord + grid_gap * 2)
                    y = LineOfScrimageYCord + grid_gap * 2;
            }

            // Keep the player behind the line of scrimage 
            if (y < LineOfScrimageYCord + grid_gap)
                y = LineOfScrimageYCord + grid_gap;
            //Keep Linemen at the line of scrimage
            if (BlitzPlayers[selectedPlayer].PlayerType.Equals(BlitzPlayerType.Linemen))
                y = LineOfScrimageYCord + grid_gap;



            // Keep Players in bounds
            if (x <= grid_gap)
                x = grid_gap;
            if (x >= this.Width - grid_gap)
                x = this.Width - grid_gap;
            if (y >= this.Height - grid_gap)
                y = this.Height - grid_gap;

            // Keep Players 2 gird_gaps away from each other, skip itself
            foreach (BlitzPlayer player in BlitzPlayers.Where(z => !z.Equals(BlitzPlayers[selectedPlayer])))
            {

                int distance = FindDistanceToPointSquared(new Point() { X = x, Y = y }, new Point() { X = player.RouteCoordinates[0].X, Y = player.RouteCoordinates[0].Y }) / grid_gap;

                if (distance <= 30)
                {
                    return;
                }
            }

            BlitzPlayers[selectedPlayer].RouteCoordinates[0] = new Point(x, y);

            // Redraw.
            this.Invalidate();
        }

        // Stop moving the end point.
        private void MouseUp_EndMovingEndPlayer(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            this.MouseMove += thisMouseMove_NotDown;
            this.MouseMove -= MouseMove_MovingPlayer;
            this.MouseUp -= MouseUp_EndMovingEndPlayer;

            // Redraw.
            this.Invalidate();
        }


        private void DeletePoint(object sender, EventArgs e)
        {
            ContextMenu menu = ((MenuItem)sender).Parent as ContextMenu;

            for (int x = 0; x < BlitzPlayers.Count; x++)
            {
                for (int z = 1; z < BlitzPlayers[x].RouteCoordinates.Count(); z++)
                    if (FindDistanceToPointSquared(rightClickPoint, BlitzPlayers[x].RouteCoordinates[z]) < over_dist_squared)
                    {
                        // We're over this point.
                        BlitzPlayers[x].RouteCoordinates.RemoveAt(z);
                        BlitzPlayers[x].Actions.RemoveAt(z);
                    }
            }
            // Redraw.
            this.Invalidate();
        }

        private void SetPointAction(object sender, EventArgs e, BlitzActionEnum blitzAction)
        {
            ContextMenu menu = ((MenuItem)sender).Parent as ContextMenu;

            for (int x = 0; x < BlitzPlayers.Count; x++)
            {
                for (int z = 1; z < BlitzPlayers[x].RouteCoordinates.Count(); z++)
                    if (FindDistanceToPointSquared(rightClickPoint, BlitzPlayers[x].RouteCoordinates[z]) < over_dist_squared)
                    {
                        // We're over this point (player x point z).
                        BlitzPlayers[x].Actions[z] = blitzAction;
                    }
            }
            // Redraw.
            this.Invalidate();
        }


        #endregion // Moving End Point

        public List<BlitzPlayer> GetPlayers()
        {
            List<BlitzPlayer> convertedPlayerList = new List<BlitzPlayer>();
            foreach (BlitzPlayer player in this.BlitzPlayers)
            {
                BlitzPlayer convertedPlayer = new BlitzPlayer();
                convertedPlayer.PlayerType = player.PlayerType;
                convertedPlayer.RouteCoordinates = new List<Point>();
                convertedPlayer.Actions = new List<BlitzActionEnum>();
                for (int r = 0; r < player.RouteCoordinates.Count(); r++)
                {
                    if (player.RouteCoordinates[r].X == 0 && player.RouteCoordinates[r].Y == 0)
                    {
                        break;
                    }
                    convertedPlayer.RouteCoordinates.Add(new Point()
                    {
                        Y = (this.Height - player.RouteCoordinates[r].Y) / grid_gap,
                        X = player.RouteCoordinates[r].X / grid_gap
                    });
                    convertedPlayer.Actions.Add(player.Actions[r]);
                }
                convertedPlayerList.Add(convertedPlayer);
            }
            BlitzPlayers = convertedPlayerList;
            return convertedPlayerList;
        }
    }
}
