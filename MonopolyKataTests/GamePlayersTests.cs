using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class GamePlayersTests
    {
        //As a game, I can have between 2 and 8 players with an initial random ordering.

        [Test]
        [Ignore]
        public void TestThatCanCreateAGameWith2PlayersNamedDogAndCarRespectively()
        {
            
        }

        [Test]
        [Ignore]
        public void TestThatCanCreateAGameWith2PlayersNamedCarAndDogRespectively()
        {

        }

        [Test]
        [Ignore]
        public void TestThatExceptionIsThrownWhenPlayerCountIsLessThan2()
        {
            
        }

        [Test]
        [Ignore]
        public void TestThatExceptionIsThrownWhenPlayerCountIsGreaterThan8()
        {

        }

        [Test]
        [Ignore]
        public void TestThatThe2PlayersCannotHaveTheSameGameToken()
        {
            
        }

        [Test]
        public void TestThatAllPlayersStartWithTheSameAmountOfMoney()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.Players = new List<Player> { new Player { Token = PlayerTokens.Tokens.Dog }, new Player { Token = PlayerTokens.Tokens.Hat } };
            gameBoard.SetInitialMonies(1234);
            Assert.That(gameBoard.Players[0].Money, Is.EqualTo(1234));
            Assert.That(gameBoard.Players[1].Money, Is.EqualTo(1234));
        }
    }
}
