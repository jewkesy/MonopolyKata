using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.GameBoard;
using NUnit.Framework;

namespace MonopolyKataTests
{
    public class LocationsTests
    {
        readonly GameBoard _gameBoard = new GameBoard();

        //Display the names of the locations rather than the number of the locations
        [Test] 
        public void TestThatLocationNamesCanBeDisplayedForAGivenPosition()
        {
            Assert.That( _gameBoard.Locations[0].Name,Is.EqualTo("Go"));
        }
    }
}
