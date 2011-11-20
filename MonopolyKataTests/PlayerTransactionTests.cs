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
        private Player _player;
        private int _preMoney;
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _player = new Player { Token = PlayerTokens.Tokens.Dog };
            _gameBoard.Players = new List<Player> { _player };
            _gameBoard.Players[0].CurrentPosition = 35;
            _preMoney = _gameBoard.Players[0].Money;
        }

        [Test]
        public void TestLandingOnGoGivesThePlayer400()
        {
            _gameBoard.MovePlayer(_gameBoard.Players[0], 2, 3);
            Assert.That(_gameBoard.Players[0].Money - _preMoney, Is.EqualTo(400));
        }

        [Test]
        public void TestPassingGoGivesThePlayer200()
        {
            _gameBoard.MovePlayer(_gameBoard.Players[0], 6, 3);
            Assert.That(_gameBoard.Players[0].Money - _preMoney, Is.EqualTo(200));
        }
    }
}
