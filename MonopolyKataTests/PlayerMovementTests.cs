using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests
{

    public class PlayerMovementTests
    {
        //http://schuchert.wikispaces.com/Monopoly%28r%29+Release+1+User+Stories
        //As a player, I can take a turn so that I can move around the board.

        
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _gameBoard.Players = new List<Player> { new Player { Token = PlayerTokens.Tokens.Dog }, new Player { Token = PlayerTokens.Tokens.Hat } };
        }

        [Test]
        public void TestThatAPlayerAtGoRolls7GoesToLocation7()
        {
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 3, 4);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(7));
        }

        [Test]
        public void TestThatAPlayerAtLocation39Rolls6GoesToLocation5()
        {
            _gameBoard.Players[0].CurrentPosition = 39;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 3, 3);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(5));
        }

        [Test]
        public void TestThatAPlayerAtLocation37Rolls3GoesToLocation0()
        {
            _gameBoard.Players[0].CurrentPosition = 37;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 1, 2);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(0));
        }

        [Test]
        public void TestThatRollingDoubleEnablesAnotherGoIfNotLandingInJail()
        {
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 6, 6);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(7));
            Assert.That(_gameBoard.CurrentPlayer.Token, Is.EqualTo(PlayerTokens.Tokens.Dog));
        }

        [Test]
        public void TestThatRolling3ConsectutiveDoublesPutsPlayerInJail()
        {
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 6, 6);
            _gameBoard.MovePlayer(_gameBoard.Players[0], 3, 3);
            _gameBoard.MovePlayer(_gameBoard.Players[0], 1, 1);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(10));
        }

        [Test]
        public void TestThatLandingOnJailTakePlayerToJail()
        {
            _gameBoard.Players[0].CurrentPosition = 20;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 4, 6);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(10));
            Assert.That(_gameBoard.Players[0].InJail, Is.EqualTo(true));
        }

        [Test]
        public void TestThatAPlayerInJailRollingDoubleReleasesPlayer()
        {
            _gameBoard.Players[0].CurrentPosition = 10;
            _gameBoard.Players[0].InJail = true;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 2, 2);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(14));
            Assert.That(_gameBoard.Players[0].InJail, Is.EqualTo(false));
        }

        [Test]
        [Ignore]
        public void TestThatPlayerGoingBack3SpacesDoesSo()
        {
            
        }

        [Test]
        [Ignore]
        public void TestThatPlayerAdvancingViaCardDoesSo()
        {
            
        }

        [Test]
        public void TestThatPlayer1MovesIndependantlyOfPlayer2WhenStartingOnSame()
        {
            _gameBoard.Players[0].CurrentPosition = 7;
            _gameBoard.Players[1].CurrentPosition = 7;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 4, 2);
            _gameBoard.MovePlayer(_gameBoard.Players[1], 2, 1);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(13));
            Assert.That(_gameBoard.Players[1].CurrentPosition, Is.EqualTo(10));
        }

        [Test]
        public void TestThatPlayer1MovesIndependantlyOfPlayer2WhenStartingOnDifferent()
        {
            _gameBoard.Players[0].CurrentPosition = 13;
            _gameBoard.Players[1].CurrentPosition = 27;
            _gameBoard.MovePlayer(_gameBoard.Players[0], 1, 5);
            _gameBoard.MovePlayer(_gameBoard.Players[1], 4, 4);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(19));
            Assert.That(_gameBoard.Players[1].CurrentPosition, Is.EqualTo(35));
            _gameBoard.MovePlayer(_gameBoard.Players[0], 2, 2);
            _gameBoard.MovePlayer(_gameBoard.Players[1], 4, 1);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(23));
            Assert.That(_gameBoard.Players[1].CurrentPosition, Is.EqualTo(0));

        }
    }
}
