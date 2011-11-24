using System;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests.Classes.GameBoardTests
{
    public class HandleLandOnLocationTests
    {
        private Player _playerWhoOwns;
        readonly GameBoard _gameBoard = new GameBoard();
        
        [SetUp]
        public void Setup()
        {
            _playerWhoOwns = new Player { Token = PlayerTokens.Tokens.Dog };

            //stations
            _gameBoard.Locations[5].Purchased = true;
            _gameBoard.Locations[5].Owner = _playerWhoOwns;
            _gameBoard.Locations[15].Purchased = true;
            _gameBoard.Locations[15].Owner = _playerWhoOwns;
            _gameBoard.Locations[25].Purchased = true;
            _gameBoard.Locations[25].Owner = _playerWhoOwns;
            _gameBoard.Locations[35].Purchased = true;
            _gameBoard.Locations[35].Owner = _playerWhoOwns;

            //utilities
            _gameBoard.Locations[12].Purchased = true;
            _gameBoard.Locations[12].Owner = _playerWhoOwns;
            _gameBoard.Locations[28].Purchased = true;
            _gameBoard.Locations[28].Owner = _playerWhoOwns;

            //Reds
            _gameBoard.Locations[16].Purchased = true;
            _gameBoard.Locations[16].Owner = _playerWhoOwns;
            _gameBoard.Locations[18].Purchased = true;
            _gameBoard.Locations[18].Owner = _playerWhoOwns;
            _gameBoard.Locations[19].Purchased = true;
            _gameBoard.Locations[19].Owner = _playerWhoOwns;
        }


        [Test]
        public void TestThatOwning4StationsCharges200()
        {



            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwning3StationsCharges150()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwning2StationsCharges100()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwning1StationCharges50()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwning1UtilityCharges4TimesDice()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwning2UtilityCharges10TimesDice()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestThatOwningAllPropertyGroupChargesDouble()
        {
            throw new NotImplementedException();
        }
    }
}
