using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class CardTests
    {
        readonly GameBoard _gameBoard = new GameBoard();

        [Test]
        public void TestThatThereAre16ChanceCards()
        {
            Assert.That(_gameBoard.ChanceCards.Count, Is.EqualTo(16));
        }

        [Test]
        public void TestThatThereAre16CommunityChestCards()
        {
            Assert.That(_gameBoard.CommunityChestCards.Count, Is.EqualTo(16));
        }
    }
}
