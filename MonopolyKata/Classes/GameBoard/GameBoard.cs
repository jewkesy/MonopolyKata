using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.Location;

namespace MonopolyKata.Classes.GameBoard
{
    public class GameBoard
    {
        public IList<Location.Location> Locations;

        public GameBoard()
        {
            Locations.Add( new Location.Location{ Name = "Old Kent Road", LocType = LocationBase.LocationType.Street});
        }
            
    }
}
