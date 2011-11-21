using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class TokenTests
    {
        [Test]
        public void TestThatTokenIsNoLongerAvailableToOtherPlayersOnceTakenByAPlayer()
        {
            GameBoard gameBoard = new GameBoard { Players = new List<Player> {new Player {Token = PlayerTokens.Tokens.Dog}}};
            gameBoard.UpdateAvailableTokens(PlayerTokens.Tokens.Dog);
            Assert.That(gameBoard.AvailableTokens.Count, Is.EqualTo(11));
        }

        [Test]
        public void TestThatAllTokensAreAvailableAtStart()
        {
            GameBoard gameBoard = new GameBoard();
            Assert.That(gameBoard.AvailableTokens.Count, Is.EqualTo(12));
        }
    }
}
