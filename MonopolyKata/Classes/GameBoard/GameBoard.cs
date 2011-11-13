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
            //Go
            Locations.Add(new Location.Location { Name = "Old Kent Road", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Whitechapel Road", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Income Tax", TaxPrice = 200, LocType = LocationBase.LocationType.Tax });
            Locations.Add(new Location.Location { Name = "Kings Cross Station", PurchasePrice = 200, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "The Angel Islington", PurchasePrice = 100, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Chance });
            Locations.Add(new Location.Location { Name = "Euston Road", PurchasePrice = 100, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Pentonville Road", PurchasePrice = 120, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "In Jail/Just Visiting", LocType = LocationBase.LocationType.Jail });
            Locations.Add(new Location.Location { Name = "Pall Mall", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Electric Company", PurchasePrice = 60, LocType = LocationBase.LocationType.Utility });
            Locations.Add(new Location.Location { Name = "Whitehall", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Northumberland Avenue", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Marylebone Station", PurchasePrice = 60, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Bow Street", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Vine Street", PurchasePrice = 60, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Free Parking", LocType = LocationBase.LocationType.FreeParking });
            Locations.Add(new Location.Location { Name = "Strand", PurchasePrice = 220, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Fleet Street", PurchasePrice = 220, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Trafalgar Square", PurchasePrice = 240, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Fenchurch Street Station", PurchasePrice = 200, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Leicester Square", PurchasePrice = 260, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Coventry Street", PurchasePrice = 260, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Water Works", PurchasePrice = 150, LocType = LocationBase.LocationType.Utility });
            Locations.Add(new Location.Location { Name = "Piccadilly", PurchasePrice = 280, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Go To Jail", LocType = LocationBase.LocationType.GoToJail });
            Locations.Add(new Location.Location { Name = "Regent Street", PurchasePrice = 300, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Oxford Street", PurchasePrice = 300, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Bond Street", PurchasePrice = 320, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Liverpool Street Station", PurchasePrice = 200, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Chance });
            Locations.Add(new Location.Location { Name = "Park Lane", PurchasePrice = 350, LocType = LocationBase.LocationType.Street });
            Locations.Add(new Location.Location { Name = "Super Tax", TaxPrice = 100, LocType = LocationBase.LocationType.Tax });
            Locations.Add(new Location.Location { Name = "Mayfair", PurchasePrice = 400, LocType = LocationBase.LocationType.Street });

        }
        
//Vine Street
//£200	
//MONOPOLY
//Regent Street
//£300
//Marlborough Street
//£180	Oxford Street
//£300
//Community Chest	Community Chest
//Bow Street
//£180	Bond Street
//£320
//Marylebone station
//£200	Liverpool Street station
//£200
//Northumberland Avenue
//£160	Chance
//?
//Whitehall
//£140	Park Lane
//£350
//Electric Company
//£150	Super Tax
//(pay £100)
//Pall Mall
//£140	Mayfair
//£400
//In Jail/Just Visiting	Pentonville Road
//£120	Euston Road
//£100	Chance
//?
//The Angel Islington
//£100	King's Cross station
//£200	Income Tax
//(pay £200)	Whitechapel Road
//£60	Community Chest	Old Kent Road
//£60	Go
//Collect £200 salary as you pass




    }
}
