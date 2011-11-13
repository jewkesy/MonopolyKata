using System.ComponentModel;

namespace MonopolyKata.Classes.Location
{
    public class LocationBase
    {
        public string Name;
        public LocationType LocType;
        public bool Purchasable;

        public enum LocationType
        {
            Go,
            Street,
            Jail,
            [DescriptionAttribute("Free Parking")]FreeParking,
            Station,
            Utility,
            [DescriptionAttribute("Community Chest")]CommunityChest,
            Tax,
            Chance,
            [DescriptionAttribute("Go To Jail")]GoToJail
        }

        public enum LocationColour
        {
            Brown,
            Blue,
            Pink,
            Orange,
            Red,
            Yellow,
            Green,
            Purple

        }
    }
}
