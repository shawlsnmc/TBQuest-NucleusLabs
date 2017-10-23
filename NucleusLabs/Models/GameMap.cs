using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace NucleusLabs
{
    public class GameMap
    {
        private DataTable MapData { get; set; }

        public enum Direction
        {
            North,
            South,
            East,
            West,
            Up,
            Down
        }
        
        public GameMap()
        {
            //initialize map
            MapData = BuildMap();
        }

        /// <summary>
        /// Returns an array of bools indicating which directions are accessible
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns>[North, South, East, West, Up, Down]</returns>
        public bool[] GetAvailableMovement(int locationID)
        {
            
            DataRow[] result = this.MapData.Select("LocationID = "+locationID);
            bool[] results = new bool[]{
                (bool)result[0][result[0].Table.Columns["LocationNorthAccessible"].Ordinal],
                (bool)result[0][result[0].Table.Columns["LocationSouthAccessible"].Ordinal],
                (bool)result[0][result[0].Table.Columns["LocationEastAccessible"].Ordinal],
                (bool)result[0][result[0].Table.Columns["LocationWestAccessible"].Ordinal],
                (bool)result[0][result[0].Table.Columns["LocationUpAccessible"].Ordinal],
                (bool)result[0][result[0].Table.Columns["LocationDownAccessible"].Ordinal]
            };

            return (results);
        }

        public bool GetTravelDirectionAccessible(int locationID, Direction Direction)
        {

            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            //result[0]["LocationNorthAccessible"], result[0]["LocationSouthAccessible"], result[0]["LocationEastAccessible"], result[0]["LocationWestAccessible"], result[0]["LocationUpAccessible"], result[0]["LocationDownAccessible"] };
            switch (Direction){
                case Direction.North:
                    return (bool)result[0][result[0].Table.Columns["LocationNorthAccessible"].Ordinal];
                case Direction.South:
                    return (bool)result[0][result[0].Table.Columns["LocationSouthAccessible"].Ordinal];
                case Direction.East:
                    return (bool)result[0][result[0].Table.Columns["LocationEastAccessible"].Ordinal];
                case Direction.West:
                    return (bool)result[0][result[0].Table.Columns["LocationWestAccessible"].Ordinal];
                case Direction.Up:
                    return (bool)result[0][result[0].Table.Columns["LocationUpAccessible"].Ordinal];
                case Direction.Down:
                    return (bool)result[0][result[0].Table.Columns["LocationDownAccessible"].Ordinal];
                default:
                    // oh crap what direction did they ask for? I guess they can't go there.
                    return false;
            }


        }
        public int GetTravelLocation(int locationID, Direction Direction)
        {

            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            //result[0]["LocationNorthAccessible"], result[0]["LocationSouthAccessible"], result[0]["LocationEastAccessible"], result[0]["LocationWestAccessible"], result[0]["LocationUpAccessible"], result[0]["LocationDownAccessible"] };
            switch (Direction)
            {
                case Direction.North:
                    return (int)result[0][result[0].Table.Columns["LocationNorthID"].Ordinal];
                case Direction.South:
                    return (int)result[0][result[0].Table.Columns["LocationSouthID"].Ordinal];
                case Direction.East:
                    return (int)result[0][result[0].Table.Columns["LocationEastID"].Ordinal];
                case Direction.West:
                    return (int)result[0][result[0].Table.Columns["LocationWestID"].Ordinal];
                case Direction.Up:
                    return (int)result[0][result[0].Table.Columns["LocationUpID"].Ordinal];
                case Direction.Down:
                    return (int)result[0][result[0].Table.Columns["LocationDownID"].Ordinal];
                default:
                    // oh crap what direction did they ask for? I guess they can't go there. Program should never get here.
                    return 0;
            }


        }
        

        /// <summary>
        /// Returns a string of the location name
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns>String LocationName</returns>
        public string GetLocationName(int locationID)
        {
            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            return (result[0][result[0].Table.Columns["LocationName"].Ordinal].ToString());
        }

        /// <summary>
        /// Returns a string of the location Description
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns>String LocationDescription</returns>
        public string GetLocationDescription(int locationID)
        {
            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            return (result[0][result[0].Table.Columns["LocationDescription"].Ordinal].ToString());
        }


        public bool GetLocationVisited(int locationID)
        {
            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            return (bool)result[0][result[0].Table.Columns["LocationVisitedByPlayer"].Ordinal];
        }

        public void SetLocationVisited(int locationID)
        {
            DataRow[] result = this.MapData.Select("LocationID = " + locationID);
            result[0][result[0].Table.Columns["LocationVisitedByPlayer"].Ordinal] = true;
        }
        


        static DataTable BuildMap()
        {
            DataTable mapdata = new DataTable();
            mapdata.Columns.Add("LocationID", typeof(int));
            mapdata.Columns.Add("LocationName", typeof(string));
            mapdata.Columns.Add("LocationDescription", typeof(string));
            mapdata.Columns.Add("LocationNorthID", typeof(int));
            mapdata.Columns.Add("LocationNorthAccessible", typeof(bool));
            mapdata.Columns.Add("LocationSouthID", typeof(int));
            mapdata.Columns.Add("LocationSouthAccessible", typeof(bool));
            mapdata.Columns.Add("LocationEastID", typeof(int));
            mapdata.Columns.Add("LocationEastAccessible", typeof(bool));
            mapdata.Columns.Add("LocationWestID", typeof(int));
            mapdata.Columns.Add("LocationWestAccessible", typeof(bool));
            mapdata.Columns.Add("LocationUpID", typeof(int));
            mapdata.Columns.Add("LocationUpAccessible", typeof(bool));
            mapdata.Columns.Add("LocationDownID", typeof(int));
            mapdata.Columns.Add("LocationDownAccessible", typeof(bool));
            mapdata.Columns.Add("LocationVisitedByPlayer", typeof(bool));

            //build base grid
            int location;
            int north;
            int south;
            int east;
            int west;
            int up;
            int down;
            bool northacc;
            bool southacc;
            bool eastacc;
            bool westacc;
            bool upacc;
            bool downacc;

            for (int f = 1; f <= 6; f++)
            {
                for (int r = 1; r <= 6; r++)
                {
                    for (int c = 1; c <= 6; c++)
                    {
                        location = f * 100 + r * 10 + c;
                        if (r == 1) { north = 0; northacc = false; } else { north = location - 10; northacc = true; }
                        if (r == 6) { south = 0; southacc = false; } else { south = location + 10; southacc = true; }
                        if (c == 1) { west = 0; westacc = false; } else { west = location - 1; westacc = true; }
                        if (c == 6) { east = 0; eastacc = false; } else { east = location + 1; eastacc = true; }
                        if (f == 1) { up = 0; upacc = false; } else { up = location - 100; upacc = true; }
                        if (f == 6) { down = 0; downacc = false; } else { down = location + 100; downacc = true; }

                        mapdata.Rows.Add(location, "LOC"+location.ToString(), "LOC"+location.ToString()+"Desc", north, northacc, south, southacc, east, eastacc, west, westacc, up, upacc, down, downacc, false);

                    }
                }
            }
            DataRow[] result;

            result = mapdata.Select("LocationID = 611");
            result[0][result[0].Table.Columns["LocationSouthAccessible"].Ordinal] = false;
            result[0][result[0].Table.Columns["LocationUpAccessible"].Ordinal] = false;

            result = mapdata.Select("LocationID = 621");
            result[0][result[0].Table.Columns["LocationNorthAccessible"].Ordinal] = false;
            

            result = mapdata.Select("LocationID = 612");
            result[0][result[0].Table.Columns["LocationEastAccessible"].Ordinal] = false;
            result[0][result[0].Table.Columns["LocationUpAccessible"].Ordinal] = false;

            result = mapdata.Select("LocationID = 613");
            result[0][result[0].Table.Columns["LocationWestAccessible"].Ordinal] = false;

            return mapdata;
        }
    }
}
