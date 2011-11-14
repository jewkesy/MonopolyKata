namespace MonopolyKata.Classes.Location
{
    public class TitleDeed
    {
        public int Cost;
        public int Monopoly {get { return Cost*2; }}
        public int Rent;
        public int OneHouse;
        public int TwoHouses;
        public int ThreeHouses;
        public int FourHouses;
        public int Hotel;
        public int CostToBuild;
        public int CostToSell { get { return CostToBuild/2; } }
        public int MortageValue {get { return Cost/2; }}
    }
}
