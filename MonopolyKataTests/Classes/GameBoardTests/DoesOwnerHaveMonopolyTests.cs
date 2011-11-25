using MonopolyKata.Classes.GameBoard;
using NUnit.Framework;

namespace MonopolyKataTests.Classes.GameBoardTests
{
    public class DoesOwnerHaveMonopolyTests
    {
        [Test]
        public void TestThatOwningAllPropertiesInAGroupIsMonopoly()
        {
            GameBoard gameBoard = new GameBoard();
            MonopolyKata.Classes.Players.Player player = new MonopolyKata.Classes.Players.Player();

            gameBoard.Locations[21].Purchased = true;
            gameBoard.Locations[21].Owner = player;
            gameBoard.Locations[23].Purchased = true;
            gameBoard.Locations[23].Owner = player;
            gameBoard.Locations[24].Purchased = true;
            gameBoard.Locations[24].Owner = player;
            Assert.That(gameBoard.DoesOwnerHaveMonopoly(gameBoard.Locations[21]), Is.EqualTo(true));
        }

        [Test]
        public void TestThatMixedOwningPropertiesInAGroupIsNotAMonopoly()
        {
            GameBoard gameBoard = new GameBoard();
            MonopolyKata.Classes.Players.Player player1 = new MonopolyKata.Classes.Players.Player();
            MonopolyKata.Classes.Players.Player player2 = new MonopolyKata.Classes.Players.Player();

            gameBoard.Locations[21].Purchased = true;
            gameBoard.Locations[21].Owner = player1;
            gameBoard.Locations[23].Purchased = true;
            gameBoard.Locations[23].Owner = player2;
            gameBoard.Locations[24].Purchased = true;
            gameBoard.Locations[24].Owner = player2;
            Assert.That(gameBoard.DoesOwnerHaveMonopoly(gameBoard.Locations[21]), Is.EqualTo(false));
        }

        [Test]
        public void TestThatAnUnownedPropertyInAGroupIsNotAMonopoly()
        {
            GameBoard gameBoard = new GameBoard();
            MonopolyKata.Classes.Players.Player player = new MonopolyKata.Classes.Players.Player();

            gameBoard.Locations[21].Purchased = true;
            gameBoard.Locations[21].Owner = player;
            gameBoard.Locations[23].Purchased = false;
            gameBoard.Locations[24].Purchased = true;
            gameBoard.Locations[24].Owner = player;
            Assert.That(gameBoard.DoesOwnerHaveMonopoly(gameBoard.Locations[21]), Is.EqualTo(false));
        }

        [Test]
        public void TestThatMixedOwningPropertiesInAGroupAndAnUnpurchasedIsNotAMonopoly()
        {
            GameBoard gameBoard = new GameBoard();
            MonopolyKata.Classes.Players.Player player1 = new MonopolyKata.Classes.Players.Player();
            MonopolyKata.Classes.Players.Player player2 = new MonopolyKata.Classes.Players.Player();

            gameBoard.Locations[21].Purchased = true;
            gameBoard.Locations[21].Owner = player1;
            gameBoard.Locations[23].Purchased = false;
            gameBoard.Locations[24].Purchased = true;
            gameBoard.Locations[24].Owner = player2;
            Assert.That(gameBoard.DoesOwnerHaveMonopoly(gameBoard.Locations[21]), Is.EqualTo(false));
        }
    }
}
