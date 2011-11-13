using MonopolyKata.Classes.Location;
using MonopolyKata.Classes.GameBoard;
using NUnit.Framework;

namespace MonopolyKataTests.Classes.GameBoardTests
{
    public class NormalCase
    {
        readonly GameBoard _gameBoard = new GameBoard();

        [Test]
        public void TestThatTheGameBoardHas40Squares()
        {
            Assert.That(_gameBoard.Locations.Count, Is.EqualTo(40));
        }

        [Test]
        public void TestThatGoIsInPos0()
        {
            Assert.That(_gameBoard.Locations[0].LocType, Is.EqualTo(LocationBase.LocationType.Go));
        }

        [Test]
        public void TestThatJailIsInPos10()
        {
            Assert.That(_gameBoard.Locations[10].LocType, Is.EqualTo(LocationBase.LocationType.Jail));
        }

        [Test]
        public void TestThatFreeParkingIsInPos20()
        {
            Assert.That(_gameBoard.Locations[20].LocType, Is.EqualTo(LocationBase.LocationType.FreeParking));
        }

        [Test]
        public void TestThatGoToJailIsInPos30()
        {
            Assert.That(_gameBoard.Locations[30].LocType, Is.EqualTo(LocationBase.LocationType.GoToJail));
        }

        [Test]
        public void TestThatStationsArePositionedCorrectly()
        {
            Assert.That(_gameBoard.Locations[5].LocType,  Is.EqualTo(LocationBase.LocationType.Station));
            Assert.That(_gameBoard.Locations[15].LocType, Is.EqualTo(LocationBase.LocationType.Station));
            Assert.That(_gameBoard.Locations[25].LocType, Is.EqualTo(LocationBase.LocationType.Station));
            Assert.That(_gameBoard.Locations[35].LocType, Is.EqualTo(LocationBase.LocationType.Station));
        }

        [Test]
        public void TestThatUtilitiesArePositionedCorrectly()
        {
            Assert.That(_gameBoard.Locations[12].LocType, Is.EqualTo(LocationBase.LocationType.Utility));
            Assert.That(_gameBoard.Locations[28].LocType, Is.EqualTo(LocationBase.LocationType.Utility));
        }

        [Test]
        public void TestThatTaxesArePositionedCorrectly()
        {
            Assert.That(_gameBoard.Locations[4].LocType, Is.EqualTo(LocationBase.LocationType.Tax));
            Assert.That(_gameBoard.Locations[38].LocType, Is.EqualTo(LocationBase.LocationType.Tax));
        }

        [Test]
        public void TestThatCommunityChestsArePositionedCorrectly()
        {
            Assert.That(_gameBoard.Locations[2].LocType,  Is.EqualTo(LocationBase.LocationType.CommunityChest));
            Assert.That(_gameBoard.Locations[17].LocType, Is.EqualTo(LocationBase.LocationType.CommunityChest));
            Assert.That(_gameBoard.Locations[33].LocType, Is.EqualTo(LocationBase.LocationType.CommunityChest));
        }

        [Test]
        public void TestThatChanceArePositionedCorrectly()
        {
            Assert.That(_gameBoard.Locations[7].LocType,  Is.EqualTo(LocationBase.LocationType.Chance));
            Assert.That(_gameBoard.Locations[22].LocType, Is.EqualTo(LocationBase.LocationType.Chance));
            Assert.That(_gameBoard.Locations[36].LocType, Is.EqualTo(LocationBase.LocationType.Chance));
        }
    }
}
