using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class NextPlayerTurnTests
    {
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _gameBoard.Players = new List<Player>
                                     {
                                         new Player { Token = PlayerTokens.Tokens.Car }, 
                                         new Player { Token = PlayerTokens.Tokens.Shoe }, 
                                         new Player { Token = PlayerTokens.Tokens.Hat, Bankrupt = true}, 
                                         new Player { Token = PlayerTokens.Tokens.MoneyBag }, 
                                         new Player { Token = PlayerTokens.Tokens.Horse }, 
                                         new Player { Token = PlayerTokens.Tokens.Wheebarrow }
                                     };
        }

        [Test]
        public void TestThatTheCurrentPlayerIsUpdatedToTheNextPlayerInTheGame()
        {
            _gameBoard.CurrentPlayer = _gameBoard.Players[4];
            _gameBoard.NextPlayerTurn();
            Assert.That(_gameBoard.CurrentPlayer.Token, Is.EqualTo(PlayerTokens.Tokens.Wheebarrow));
        }

        [Test]
        public void TestThatIfTheCurrentPlayerIsTheLastPlayerThenTheFirstPlayerBecomesCurrent()
        {
            _gameBoard.CurrentPlayer = _gameBoard.Players[5];
            _gameBoard.NextPlayerTurn();
            Assert.That(_gameBoard.CurrentPlayer.Token, Is.EqualTo(PlayerTokens.Tokens.Car));
        }

        [Test]
        public void TestThatABankruptPlayerSkipsTheirTurn()
        {
            _gameBoard.CurrentPlayer = _gameBoard.Players[1];
            _gameBoard.NextPlayerTurn();
            Assert.That(_gameBoard.CurrentPlayer.Token, Is.EqualTo(PlayerTokens.Tokens.MoneyBag));
        }
    }
}
