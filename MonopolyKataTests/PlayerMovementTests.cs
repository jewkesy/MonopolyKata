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

        private Player _player;
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _player = new Player { Token = PlayerTokens.Tokens.Dog};
            _gameBoard.Players = new List<Player> {_player};
        }

        [Test]
        public void TestThatAPlayerAtGoRolls7GoesToLocation7()
        {
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(0, 3, 4);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(7));
        }

        [Test]
        public void TestThatAPlayerAtLocation39Rolls6GoesToLocation5()
        {
            _gameBoard.Players[0].CurrentPosition = 39;
            _gameBoard.MovePlayer(0, 3, 3);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(5));
        }

        [Test]
        public void TestThatRollingDoubleEnablesAnotherGoIfNotLandingInJail()
        {
            Player player2 = new Player{ Token = PlayerTokens.Tokens.Car};
            _gameBoard.Players[1] = player2;
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(0, 6, 6);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(7));
            Assert.That(_gameBoard.CurrentPlayer.Token, Is.EqualTo(PlayerTokens.Tokens.Dog));
        }

        [Test]
        public void TestThatRolling3ConsectutiveDoublesPutsPlayerInJail()
        {
            _gameBoard.Players[0].CurrentPosition = 0;
            _gameBoard.MovePlayer(0, 6, 6);
            _gameBoard.MovePlayer(0, 3, 3);
            _gameBoard.MovePlayer(0, 1, 1);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(10));
        }

        [Test]
        public void TestThatLandingOnJailTakePlayerToJail()
        {
            _gameBoard.Players[0].CurrentPosition = 20;
            _gameBoard.MovePlayer(0, 4, 6);
            Assert.That(_gameBoard.Players[0].CurrentPosition, Is.EqualTo(10));
            Assert.That(_gameBoard.Players[0].InJail, Is.EqualTo(true));
        }

        [Test]
        public void TestThatAPlayerInJailRollingDoubleReleasesPlayer()
        {
            _gameBoard.Players[0].CurrentPosition = 20;
            _gameBoard.Players[0].InJail = true;
            _gameBoard.MovePlayer(0, 2, 2);
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
    }
}
