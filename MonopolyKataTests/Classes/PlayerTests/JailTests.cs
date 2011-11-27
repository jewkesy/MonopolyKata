using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests.Classes.PlayerTests
{
    public class JailTests
    {
        readonly GameBoard _gameBoard = new GameBoard();

        [SetUp]
        public void Setup()
        {
            _gameBoard.Players = new List<Player>
                                     {
                                         new Player { Token = PlayerTokens.Tokens.Dog, CurrentPosition = 10, InJail = true, JailRolls = 0},
                                         new Player { Token = PlayerTokens.Tokens.Dog, CurrentPosition = 10, InJail = true, JailRolls = 1},
                                         new Player { Token = PlayerTokens.Tokens.Dog, CurrentPosition = 10, InJail = true, JailRolls = 2},
                                         new Player { Token = PlayerTokens.Tokens.Dog, CurrentPosition = 10, InJail = true, JailRolls = 0}
                                     };
            _gameBoard.FirstDie = 1;
            _gameBoard.SecondDie = 2;
        }

        [Test]
        public void TestThatAPlayerInJailFirstRollNonDoubleHas1AttemptLogged()
        {
            _gameBoard.RollOutOfJail(_gameBoard.Players[0]);
            Assert.That(_gameBoard.Players[0].JailRolls, Is.EqualTo(1));
        }

        [Test]
        public void TestThatAPlayerInJailSecondRollNonDoubleHas2AttemptsLogged()
        {
            _gameBoard.RollOutOfJail(_gameBoard.Players[1]);
            Assert.That(_gameBoard.Players[1].JailRolls, Is.EqualTo(2));
        }

        [Test]
        public void TestThatAPlayerInJailThirdRollNonDoubleIsFree()
        {
            _gameBoard.RollOutOfJail(_gameBoard.Players[2]);
            Assert.That(_gameBoard.Players[2].InJail, Is.EqualTo(false));
        }

        [Test]
        public void TestThatAPlayerInJailThirdRollNonDoublePays50()
        {
            int preMoney = _gameBoard.Players[2].Money;
            _gameBoard.RollOutOfJail(_gameBoard.Players[2]);
            Assert.That(_gameBoard.Players[2].Money, Is.EqualTo(preMoney - 50));
        }

        [Test]
        public void TestThatAPlayerInJailCanUseGetOutFreeCard()
        {
            throw  new NotImplementedException();
        }

        [Test]
        public void TestThatAPlayerInJailRollingDoubleIsFree()
        {
            _gameBoard.FirstDie = 3;
            _gameBoard.SecondDie = 3;
          
            _gameBoard.RollOutOfJail(_gameBoard.Players[3]);
            Assert.That(_gameBoard.Players[3].CurrentPosition, Is.EqualTo(16));
            Assert.That(_gameBoard.Players[3].InJail, Is.EqualTo(false));

        }
    }
}
