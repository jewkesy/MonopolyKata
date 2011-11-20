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
            GameBoard gameBoard = new GameBoard();
            gameBoard.Players = new List<Player> { new Player { Token = PlayerTokens.Tokens.Dog }};
            gameBoard.UpdateAvailableTokens(PlayerTokens.Tokens.Dog);

            IList<PlayerTokens.Tokens> sut = gameBoard.GetAvailableTokens();
            Assert.That(sut.Count, Is.EqualTo(11));
        }

        [Test]
        public void TestThatAllTokensAreAvailableAtStart()
        {
            GameBoard gameBoard = new GameBoard();
            IList<PlayerTokens.Tokens> sut = gameBoard.GetAvailableTokens();

            Assert.That(sut.Count, Is.EqualTo(12));
        }
    }
}
