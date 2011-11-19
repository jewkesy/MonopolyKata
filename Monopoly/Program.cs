using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Location;
using MonopolyKata.Classes.Players;
using MonopolyKata.Interfaces;

namespace Monopoly
{
    class Program
    {
        static readonly GameBoard _game = new GameBoard();

        static void Main(string[] args)
        {
            _game.Players = new List<Player>{ new Player()};

            Console.WriteLine("Welcome to Monopoly DKJ Edition"); // Prompt

            SetUpGamePlayers();
            PlayGame();
        }

        private static void SetUpGamePlayers()
        {
            while (true) // Loop indefinitely
            {

                break;
            }
        }

        private static void PlayGame()
        {
            while (true) // Loop indefinitely
            {
                try
                {


                    Console.WriteLine("Enter Die Values:"); // Prompt
                    string line = Console.ReadLine(); // Get string from user
                    if (line == null) continue;
                    if (line.ToLower() == "exit") break;
                    if (line.ToLower() == "help" || line == "?") ShowHelp();
                    if (line.ToLower() == "board" || line == "b") ShowBoard();
                    if (line.ToLower() == "bank" || line == "£") ShowBank();


                    if (line.Length != 2) continue;

                    int output;
                    if (Int32.TryParse(line, out output))
                    {
                        int die1 = Int32.Parse(line.Substring(0, 1));
                        int die2 = Int32.Parse(line.Substring(1, 1));
                        _game.MovePlayer(0, die1, die2);
                        Console.Write("You landed on ");
                        Console.WriteLine(_game.Locations[_game.Players[0].CurrentPosition].Name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static void ShowBoard()
        {
            throw new NotImplementedException();
        }

        private static void ShowBank()
        {
            Console.Write("Name\t\t\t\t");
            Console.Write("Purchased\t");
            Console.WriteLine("Cost");

            foreach (Location location in _game.Locations.Where(location => location.Purchasable))
            {
                Console.Write(location.Name + "\t\t\t");
                Console.Write(location.Purchased + "\t");
                Console.WriteLine("£" + location.TitleDeed.Cost);
            }
        }

        private static void ShowHelp()
        {
            throw new NotImplementedException();
        }
    }
}
