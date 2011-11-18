using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Interfaces;

namespace Monopoly
{
    class Program
    {
        static GameBoard _game = new GameBoard();

        static void Main(string[] args)
        {
            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter input:"); // Prompt
                string line = Console.ReadLine(); // Get string from user
                if (line == "exit") // Check string
                {
                    break;
                }
                Console.Write("You typed "); // Report output
                Console.Write(line.Length);
                Console.WriteLine(" character(s)");

                int output;
                
               
                if (Int32.TryParse(line, out output))
                {
                    Console.Write("You landed on ");
                    Console.WriteLine(_game.Locations[output].Name);
                }


                
            }
        }
    }
}
