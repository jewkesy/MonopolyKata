using System.ComponentModel;

namespace MonopolyKata.Classes.Location
{
    public class LocationBase
    {
        public string Name;
        public LocationType LocType;

        public enum LocationType
        {
            Go,
            Street,
            Jail,
            [DescriptionAttribute("Free Parking")]FreeParking,
            Station,
            Utility,
            [DescriptionAttribute("Community Chest")]CommunityChest,
            Chance,
            [DescriptionAttribute("Go To Jail")]GoToJail
        }
    }
}
