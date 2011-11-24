using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class PlayerTransactionTests
    {
        private Player _player1;
        private Player _player2;
        private int _preMoney1;
        private int _preMoney2;
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _player1 = new Player { Token = PlayerTokens.Tokens.Dog };
            _player2 = new Player { Token = PlayerTokens.Tokens.Hat };
            _gameBoard.Players = new List<Player> { _player1, _player2 };
            _gameBoard.Players[0].CurrentPosition = 35;
            _gameBoard.Players[1].CurrentPosition = 35;

            _preMoney1 = _gameBoard.Players[0].Money;
            _preMoney2 = _gameBoard.Players[1].Money;

            _gameBoard.Locations[37].Purchased = true;
            _gameBoard.Locations[37].Owner = _gameBoard.Players[0];
        }

        [Test]
        public void TestLandingOnGoGivesThePlayer400()
        {
            _gameBoard.MovePlayer(_gameBoard.Players[0], 2, 3);
            Assert.That(_gameBoard.Players[0].Money - _preMoney1, Is.EqualTo(400));
        }

        [Test]
        public void TestPassingGoGivesThePlayer200()
        {
            _gameBoard.MovePlayer(_gameBoard.Players[0], 3, 6);
            Assert.That(_gameBoard.Players[0].Money - _preMoney1, Is.EqualTo(200));
        }

        [Test]
        public void TestThatPurchasingPropertyDeductsCorrectCostWhenHavingSuitableFunds()
        {
            var location = _gameBoard.Locations[_gameBoard.Players[0].CurrentPosition];
            
            _gameBoard.MovePlayer(_gameBoard.Players[0], 1, 3);
            _gameBoard.PurchaseLocation(location, _gameBoard.Players[0]);

            Assert.That(_gameBoard.Players[0].Money, Is.EqualTo(_preMoney1 - location.TitleDeed.Cost));
        }

        [Test]
        public void TestThatLandingOnOwnPropertyDoesNotChargeRent()
        {
            var location = _gameBoard.Locations[_gameBoard.Players[0].CurrentPosition];

            _gameBoard.MovePlayer(_gameBoard.Players[0], 1, 1);
            _gameBoard.PurchaseLocation(location, _gameBoard.Players[0]);

            Assert.That(_gameBoard.Players[0].Money, Is.EqualTo(_preMoney1));
        }

        [Test]
        public void TestThatLandingOnPropertyChargesRentWhenOwnedByOtherPlayer()
        {
            var location = _gameBoard.Locations[_gameBoard.Players[1].CurrentPosition];

            _gameBoard.MovePlayer(_gameBoard.Players[1], 1, 1);
            _gameBoard.HandleLandOnLocation(location, _gameBoard.Players[1]);

            Assert.That(_gameBoard.Players[1].Money, Is.EqualTo(_preMoney2 - location.TitleDeed.Rent));
        }
    }
}
