using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Classes.GameBoard;
using MonopolyKata.Classes.Location;
using MonopolyKata.Classes.Players;

namespace Monopoly
{
    class Program
    {
        static readonly GameBoard _game = new GameBoard();

        static void Main(string[] args)
        {
            _game.Players = new List<Player>();

            Console.WriteLine("Welcome to Monopoly DKJ Edition"); // Prompt

            SetUpGamePlayers();
            PlayGame();
        }

        private static void SetUpGamePlayers()
        {
            int maxPlayers = Enum.GetValues(typeof (PlayerTokens.Tokens)).Length;
            int humanPlayerCount;
            int cpuPlayerCount;

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter numer of Human players [1 - " + maxPlayers + "]:");
                string humans = Console.ReadLine();
                if (string.IsNullOrEmpty(humans)) continue;

                int output;
                if (Int32.TryParse(humans, out output)) if (output < 0 || output > maxPlayers) continue; //supports zero for now

                humanPlayerCount = output;

                break;
            }

            if (humanPlayerCount < maxPlayers)
            {
                while (true)
                {
                    Console.WriteLine("Enter numer of CPU players [0 - " + (maxPlayers - humanPlayerCount) + "]:");
                    string cpus = Console.ReadLine();


                    if (string.IsNullOrEmpty(cpus)) continue;

                    int output;
                    if (Int32.TryParse(cpus, out output)) if (output < 0 || output > maxPlayers) continue; //supports zero for now

                    cpuPlayerCount = output;

                    break;
                }
            }

            for (int i = 1; i <= humanPlayerCount; i++ )
            {
                while (true)
                {
                    Console.WriteLine("Player " + i + ", please select your token:");
                    string tokenIndx = Console.ReadLine();
                    int output;
                    if (Int32.TryParse(tokenIndx, out output)) 
                        if (output < 0 || output > 12) continue;

                    Player player = new Player{ Token = (PlayerTokens.Tokens) output};

                    _game.Players.Add(player);
                    break;
                }
            }

           
            foreach (Player player in _game.Players)
            {
                player.Money = 1500;
            }

            _game.CurrentPlayer = _game.Players[0];
        }

        private static void PlayGame()
        {
            while (true) // Loop indefinitely
            {
                try
                {
                    Console.Write("[" + _game.CurrentPlayer.Token + " - £" + _game.CurrentPlayer.Money + "] ");
                    Console.WriteLine("Enter Die Values:"); // Prompt
                    string line = Console.ReadLine(); // Get string from user
                    if (string.IsNullOrEmpty(line)) continue;
                    if (line.ToLower() == "exit" || line.ToLower() == "quit" || line.ToLower() == "e" || line.ToLower() == "q") break;
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

                        _game.NextPlayerTurn();
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
            PrintLine();
            PrintRow("Name", "Purchased", "Cost", "Colour");
            PrintLine();

            foreach (Location location in _game.Locations.Where(location => location.Purchasable))
            {
                PrintRow(location.Name, location.Purchased.ToString(), "£" + location.TitleDeed.Cost, location.LocColour.ToString());
            }

            PrintLine();
        }

        private static void ShowHelp()
        {
            throw new NotImplementedException();
        }

        public static bool IsNumeric(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', 57));
        }

        static void PrintRow(string column1, string column2, string column3, string column4)
        {
            Console.WriteLine(
                string.Format("|{0}|{1}|{2}|{3}|",
                    AlignCentre(column1, 26),
                    AlignCentre(column2, 11),
                    AlignCentre(column3, 6),
                    AlignCentre(column4, 9)));
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
