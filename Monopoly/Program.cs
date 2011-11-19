using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Players;
using MonopolyKata.Interfaces;

namespace Monopoly
{
    class Program
    {
        static GameBoard _game = new GameBoard();

        static void Main(string[] args)
        {
            _game.Players = new List<Player>{ new Player()};

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter input:"); // Prompt
                string line = Console.ReadLine(); // Get string from user
                if (line == "exit") // Check string
                {
                    break;
                }

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
        }
    }
}
