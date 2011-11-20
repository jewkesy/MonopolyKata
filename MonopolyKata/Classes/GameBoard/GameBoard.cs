﻿using System;
using System.Collections.Generic;
using MonopolyKata.Classes.Cards;
using MonopolyKata.Classes.Location;
using MonopolyKata.Classes.Players;

namespace MonopolyKata.Classes.GameBoard 
{
    /// <summary>
    /// http://www.moonatnoon.com/puzzles/reference/monopoly.html
    /// If one "Utility" is owned rent is 4 times amount shown on dice.
    /// If both "Utilities" are owned rent is 10 times amount shown on dice.
    /// 32 houses, 12 hotels, two six-sided dice
    /// There are 16 each of Chance and Community Chest cards
    /// If a player owns ALL the Lots of any Color-Group, the rent is Doubled on Unimproved Lots in that group.
    /// Each player starts with £1500
    /// </summary>
    public class GameBoard
    {
        public IList<Location.Location> Locations;
        public IList<CommunityChest> CommunityChestCards;
        public IList<Chance> ChanceCards;
        public IList<Player> Players;
        public Player CurrentPlayer;

        public GameBoard()
        {
            AssembleGameBoard();
            AssembleChanceCards();
            AssembleCommunityChestCards();
        }

        private void AssembleCommunityChestCards()
        {
            CommunityChestCards = new List<CommunityChest>();

            CommunityChestCards.Add(new CommunityChest { Title = "Advance to Go"});


            ShuffleCommunityChestCards();
        }

        private void AssembleChanceCards()
        {
            ChanceCards = new List<Chance>();

            ChanceCards.Add(new Chance { Title = "Advance to Go" });

            ShuffleChanceCards();
        }

        private void ShuffleCommunityChestCards()
        {
            //throw new NotImplementedException();
        }

        private void ShuffleChanceCards()
        {
            //throw new NotImplementedException();
        }

        private void AssembleGameBoard()
        {
            Locations = new List<Location.Location>();

            Locations.Add(new Location.Location { Name = "Go", LocType = LocationBase.LocationType.Go });
            Locations.Add(new Location.Location { Name = "Old Kent Road", Purchasable = true, TitleDeed = new TitleDeed { Cost = 60, Rent = 2, OneHouse = 10, TwoHouses = 30, ThreeHouses = 90, FourHouses = 160, Hotel = 250, CostToBuild = 50 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Brown });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Whitechapel Road", Purchasable = true, TitleDeed = new TitleDeed { Cost = 60, Rent = 4, OneHouse = 20, TwoHouses = 60, ThreeHouses = 180, FourHouses = 320, Hotel = 450, CostToBuild = 50 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Brown });
            Locations.Add(new Location.Location { Name = "Income Tax", TaxPrice = 200, LocType = LocationBase.LocationType.Tax });
            Locations.Add(new Location.Location { Name = "Kings Cross Station", Purchasable = true, TitleDeed = new TitleDeed { Cost = 200 }, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "The Angel Islington", Purchasable = true, TitleDeed = new TitleDeed { Cost = 100, Rent = 6, OneHouse = 30, TwoHouses = 90, ThreeHouses = 270, FourHouses = 400, Hotel = 550, CostToBuild = 50 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Blue });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Chance });
            Locations.Add(new Location.Location { Name = "Euston Road", Purchasable = true, TitleDeed = new TitleDeed { Cost = 100, Rent = 6, OneHouse = 30, TwoHouses = 90, ThreeHouses = 270, FourHouses = 400, Hotel = 550, CostToBuild = 50 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Blue });
            Locations.Add(new Location.Location { Name = "Pentonville Road", Purchasable = true, TitleDeed = new TitleDeed { Cost = 120, Rent = 8, OneHouse = 40, TwoHouses = 100, ThreeHouses = 300, FourHouses = 450, Hotel = 600, CostToBuild = 50 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Blue });
            Locations.Add(new Location.Location { Name = "In Jail/Just Visiting", LocType = LocationBase.LocationType.Jail });
            Locations.Add(new Location.Location { Name = "Pall Mall", Purchasable = true, TitleDeed = new TitleDeed { Cost = 140, Rent = 10, OneHouse = 50, TwoHouses = 150, ThreeHouses = 450, FourHouses = 625, Hotel = 750, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Pink });
            Locations.Add(new Location.Location { Name = "Electric Company", Purchasable = true, TitleDeed = new TitleDeed { Cost = 150 }, LocType = LocationBase.LocationType.Utility });
            Locations.Add(new Location.Location { Name = "Whitehall", Purchasable = true, TitleDeed = new TitleDeed { Cost = 140, Rent = 10, OneHouse = 50, TwoHouses = 150, ThreeHouses = 450, FourHouses = 625, Hotel = 750, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Pink });
            Locations.Add(new Location.Location { Name = "Northumberland Avenue", Purchasable = true, TitleDeed = new TitleDeed { Cost = 160, Rent = 12, OneHouse = 60, TwoHouses = 180, ThreeHouses = 500, FourHouses = 700, Hotel = 900, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Pink });
            Locations.Add(new Location.Location { Name = "Marylebone Station", Purchasable = true, TitleDeed = new TitleDeed { Cost = 200 }, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Bow Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 180, Rent = 14, OneHouse = 70, TwoHouses = 200, ThreeHouses = 550, FourHouses = 750, Hotel = 950, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Orange });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Marlborough Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 180, Rent = 14, OneHouse = 70, TwoHouses = 200, ThreeHouses = 550, FourHouses = 750, Hotel = 950, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Orange });
            Locations.Add(new Location.Location { Name = "Vine Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 200, Rent = 16, OneHouse = 80, TwoHouses = 220, ThreeHouses = 600, FourHouses = 800, Hotel = 1000, CostToBuild = 100 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Orange });
            Locations.Add(new Location.Location { Name = "Free Parking", LocType = LocationBase.LocationType.FreeParking });
            Locations.Add(new Location.Location { Name = "Strand", Purchasable = true, TitleDeed = new TitleDeed { Cost = 220, Rent = 18, OneHouse = 90, TwoHouses = 250, ThreeHouses = 700, FourHouses = 875, Hotel = 1050, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Red });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Chance });
            Locations.Add(new Location.Location { Name = "Fleet Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 220, Rent = 18, OneHouse = 90, TwoHouses = 250, ThreeHouses = 700, FourHouses = 875, Hotel = 1050, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Red });
            Locations.Add(new Location.Location { Name = "Trafalgar Square", Purchasable = true, TitleDeed = new TitleDeed { Cost = 240, Rent = 20, OneHouse = 100, TwoHouses = 300, ThreeHouses = 750, FourHouses = 925, Hotel = 1100, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Red });
            Locations.Add(new Location.Location { Name = "Fenchurch Street Station", Purchasable = true, TitleDeed = new TitleDeed { Cost = 200 }, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Leicester Square", Purchasable = true, TitleDeed = new TitleDeed { Cost = 260, Rent = 22, OneHouse = 110, TwoHouses = 330, ThreeHouses = 800, FourHouses = 975, Hotel = 1150, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Yellow });
            Locations.Add(new Location.Location { Name = "Coventry Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 260, Rent = 22, OneHouse = 110, TwoHouses = 330, ThreeHouses = 800, FourHouses = 975, Hotel = 1150, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Yellow });
            Locations.Add(new Location.Location { Name = "Water Works", Purchasable = true, TitleDeed = new TitleDeed { Cost = 150 }, LocType = LocationBase.LocationType.Utility });
            Locations.Add(new Location.Location { Name = "Piccadilly", Purchasable = true, TitleDeed = new TitleDeed { Cost = 280, Rent = 24, OneHouse = 120, TwoHouses = 360, ThreeHouses = 850, FourHouses = 1025, Hotel = 1200, CostToBuild = 150 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Yellow });
            Locations.Add(new Location.Location { Name = "Go To Jail", LocType = LocationBase.LocationType.GoToJail });
            Locations.Add(new Location.Location { Name = "Regent Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 300, Rent = 26, OneHouse = 130, TwoHouses = 390, ThreeHouses = 900, FourHouses = 1100, Hotel = 1275, CostToBuild = 200 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Green });
            Locations.Add(new Location.Location { Name = "Oxford Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 300, Rent = 26, OneHouse = 130, TwoHouses = 390, ThreeHouses = 900, FourHouses = 1100, Hotel = 1275, CostToBuild = 200 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Green });
            Locations.Add(new Location.Location { Name = "Community Chest", LocType = LocationBase.LocationType.CommunityChest });
            Locations.Add(new Location.Location { Name = "Bond Street", Purchasable = true, TitleDeed = new TitleDeed { Cost = 320, Rent = 28, OneHouse = 150, TwoHouses = 450, ThreeHouses = 1000, FourHouses = 1200, Hotel = 1400, CostToBuild = 200 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Green });
            Locations.Add(new Location.Location { Name = "Liverpool Street Station", Purchasable = true, TitleDeed = new TitleDeed { Cost = 200 }, LocType = LocationBase.LocationType.Station });
            Locations.Add(new Location.Location { Name = "Chance", LocType = LocationBase.LocationType.Chance });
            Locations.Add(new Location.Location { Name = "Park Lane", Purchasable = true, TitleDeed = new TitleDeed { Cost = 350, Rent = 35, OneHouse = 175, TwoHouses = 500, ThreeHouses = 1100, FourHouses = 1300, Hotel = 1500, CostToBuild = 200 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Purple });
            Locations.Add(new Location.Location { Name = "Super Tax", TaxPrice = 100, LocType = LocationBase.LocationType.Tax });
            Locations.Add(new Location.Location { Name = "Mayfair", Purchasable = true, TitleDeed = new TitleDeed { Cost = 400, Rent = 50, OneHouse = 200, TwoHouses = 600, ThreeHouses = 1400, FourHouses = 1700, Hotel = 2000, CostToBuild = 200 }, LocType = LocationBase.LocationType.Street, LocColour = LocationBase.LocationColour.Purple });
        }

        public void MovePlayer(int playerIndex, int i, int i1)
        {
            int currLoc = Players[playerIndex].CurrentPosition;

            int newLoc =  currLoc + i + i1;

            if (newLoc > Locations.Count-1)
            {
                newLoc = newLoc - Locations.Count;
                if (newLoc == 0) Players[playerIndex].Money = Players[playerIndex].Money + 400; //Landed on Go
                else
                {
                    Players[playerIndex].Money = Players[playerIndex].Money + 200; //Passed Go
                }
            }

            Players[playerIndex].CurrentPosition = newLoc;



        }

        public void NextPlayerTurn()
        {
            Player prevPlayer = CurrentPlayer;

            int counter = 0;

            foreach (Player player in Players)
            {
                if (player.Token == prevPlayer.Token)
                {
                    counter++;
                    if (counter == Players.Count)
                    {
                        CurrentPlayer = Players[0];
                    }
                    else
                    {
                        CurrentPlayer = Players[counter];
                    }
                    break;
                }
                counter++;
            }
        }
    }
}
