namespace MonopolyKata.Classes.Location
{
    public class LocationBase
    {
        public string Name;



        public enum LocationType
        {
            Go,
            Street,
            Jail,
            FreeParking,
            Station,
            Utility,
            CommunityChest,
            Chance,
            GoToJail
        }
    }
}
