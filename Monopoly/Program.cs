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
        static readonly GameBoard Game = new GameBoard();

        static void Main(string[] args)
        {
            Game.Players = new List<Player>();

            Console.WriteLine("Welcome to Monopoly DKJ Edition"); // Prompt

            SetUpGamePlayers();
            PlayGame();
        }

        private static void SetUpGamePlayers()
        {
            int maxPlayers = Enum.GetValues(typeof (PlayerTokens.Tokens)).Length;
            int humanPlayerCount = 0;
            int cpuPlayerCount = 0;

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter number of Human players [1 - " + maxPlayers + "]:");
                string humans = Console.ReadLine();
                if (string.IsNullOrEmpty(humans)) continue;

                int output;
                if (Int32.TryParse(humans, out output)) if (output < 0 || output > maxPlayers) continue; //supports zero for now

                humanPlayerCount = output;

                break;
            }

            for (int i = 1; i <= humanPlayerCount; i++)
            {
                while (true)
                {
                    ShowAvailableTokens();
                    
                    Console.WriteLine("Player " + i + ", please select your token:");
                    string tokenIndx = Console.ReadLine();
                    if (tokenIndx == "") continue;
                    int output;
                    if (Int32.TryParse(tokenIndx, out output))
                        if (output < 0 || output > Game.AvailableTokens.Count) continue;

                    Player player = new Player { Token = Game.AvailableTokens[output - 1] , Type = Player.PlayerType.Human };

                    Game.Players.Add(player);
                    Game.UpdateAvailableTokens(player.Token);
                    break;
                }
            }

            if (humanPlayerCount < maxPlayers)
            {
                while (true)
                {
                    int minCpuPlayers = 0;
                    if (humanPlayerCount <= 1) minCpuPlayers = 1;
                    Console.WriteLine("Enter number of CPU players [" + minCpuPlayers + " - " + (maxPlayers - humanPlayerCount) + "]:");
                    string cpus = Console.ReadLine();

                    if (string.IsNullOrEmpty(cpus)) continue;

                    int output;
                    if (Int32.TryParse(cpus, out output)) if (output < minCpuPlayers || output > maxPlayers - humanPlayerCount) continue; //supports zero for now

                    for (int i = 1; i <= output; i++)
                    {
                        Player player = new Player { Token = Game.AvailableTokens[i - 1], Type = Player.PlayerType.Cpu};
                        Game.Players.Add(player);
                    }
                    break;
                }
            }

            Game.SetInitialMonies(1500);
            Game.CurrentPlayer = Game.Players[0];
        }

        private static void ShowAvailableTokens()
        {
            int i = 1;
            foreach (var token in Game.AvailableTokens)
            {
                Console.WriteLine(i + " - " + token);
                i++;
            }
            
        }

        private static void PlayGame()
        {
            while (true) // Loop indefinitely
            {
                try
                {
                    Console.Write("[" + Game.CurrentPlayer.Token + " > " + Game.Locations[Game.CurrentPlayer.CurrentPosition].Name + " - £" + Game.CurrentPlayer.Money + "] ");
                    Console.WriteLine("Press Enter to roll!"); // Prompt

                    string input = "";
                    string who = "";

                    if (Game.CurrentPlayer.Type == Player.PlayerType.Cpu)
                    {
                        Game.CpuPreRoll();
                        who = "[CPU]";
                    }
                    else
                    {
                        input = Console.ReadLine(); // Get string from user   
                        who = "You";
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        int firstDie = Game.RollDice();
                        int secondDie = Game.RollDice();
                        Game.MovePlayer(Game.CurrentPlayer, firstDie, secondDie);
                        string locName = Game.Locations[Game.CurrentPlayer.CurrentPosition].Name;

                        Console.Write(who + " rolled " + firstDie + "/" + secondDie + " and landed on ");
                        Console.WriteLine(locName);

                        if (Game.Locations[Game.CurrentPlayer.CurrentPosition].LocType == LocationBase.LocationType.Street || Game.Locations[Game.CurrentPlayer.CurrentPosition].LocType == LocationBase.LocationType.Station || Game.Locations[Game.CurrentPlayer.CurrentPosition].LocType == LocationBase.LocationType.Utility)
                        {
                            if (Game.Locations[Game.CurrentPlayer.CurrentPosition].Purchased == false)
                            {
                                if (Game.CurrentPlayer.Type == Player.PlayerType.Cpu)
                                {
                                    Game.CpuPostRoll(Game.Locations[Game.CurrentPlayer.CurrentPosition], Game.CurrentPlayer);
                                }
                                else
                                {
                                    int locCost = Game.Locations[Game.CurrentPlayer.CurrentPosition].TitleDeed.Cost;
                                    while (true)
                                    {
                                        Console.Write("Do you want to purchase '" + locName + "' for " + locCost +
                                                      " (Y/N)?");
                                        string answer = Console.ReadLine();
                                        if (string.IsNullOrEmpty(answer)) continue;
                                        if (answer.ToLower() == "n") break;
                                        if (answer.ToLower() == "y")
                                        {
                                            if (locCost > Game.CurrentPlayer.Money)
                                            {
                                                //show payment options
                                            }
                                            Game.PurchaseLocation(Game.Locations[Game.CurrentPlayer.CurrentPosition],
                                                                  Game.CurrentPlayer);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Game.HandleLandOnLocation(Game.Locations[Game.CurrentPlayer.CurrentPosition], Game.CurrentPlayer);
                            }
                        }
                        Game.NextPlayerTurn();
                    }

                    if (WantsToQuit(input)) break;
                    ProcessInput(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static bool WantsToQuit(string input)
        {
            return input.ToLower() == "exit" || input.ToLower() == "quit" || input.ToLower() == "e" || input.ToLower() == "q";
        }

        private static void ProcessInput(string input)
        {
            switch (input.ToLower())
            {
                case "?":
                    ShowHelp();
                    break;
                case "b":
                    ShowBoard();
                    break;
                case "£":
                    ShowBank();
                    break;
                case "p":
                    ShowPlayers();
                    break;
                case "i":
                    ShowPlayerInfo();
                    break;
                case "m":
                    ShowPropertyManager();
                    break;
            }
        }

        private static void ShowPropertyManager()
        {
            throw new NotImplementedException();
        }

        private static void ShowPlayerInfo()
        {
            throw new NotImplementedException();
        }

        private static void ShowPlayers()
        {
            PrintBankLine();
            PrintBankRow("Game Token", "Location", "Money", "Turn", "In Jail");
            PrintBankLine();

            foreach (Player player in Game.Players)
            {
                string locationName = Game.Locations[player.CurrentPosition].Name;
                string turn = "";
                string playerType = "";
                if (player.Type == Player.PlayerType.Cpu) playerType = " [CPU]";
                if (Game.CurrentPlayer.Token == player.Token) turn = "X";
               
                PrintBankRow(player.Token + playerType, locationName, "£" + player.Money, turn, player.InJail.ToString());
            }
            PrintBankLine();
        }

        private static void ShowBoard()
        {
            throw new NotImplementedException();
        }

        private static void ShowBank()
        {
            PrintBankLine();
            PrintBankRow("Name", "Purchased", "Cost", "Rent", "Colour");
            PrintBankLine();

            foreach (Location location in Game.Locations.Where(location => location.Purchasable))
            {
                if (location.Purchased)
                {
                    PrintBankRow(location.Name, location.Owner.Token.ToString(), "£" + location.TitleDeed.Cost,
                             "£" + location.TitleDeed.Rent, location.LocColour.ToString());
                }
                else
                {
                    PrintBankRow(location.Name, "Bank", "£" + location.TitleDeed.Cost,
                             "£" + location.TitleDeed.Rent, location.LocColour.ToString());
                }
            }


            PrintBankLine();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("b - Show the Game Board");
            Console.WriteLine("£ - Show the Bank");
            Console.WriteLine("p - Show Players");
            Console.WriteLine("i - Show your information");
            Console.WriteLine("m - Manage your Properties");
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

        static void PrintBankLine()
        {
            Console.WriteLine(new string('-', 57));
        }

        static void PrintBankRow(string name, string owner, string cost, string rent, string colour)
        {
            Console.WriteLine(
                string.Format("|{0}|{1}|{2}|{3}|{4}|",
                    AlignCentre(name, 26),
                    AlignCentre(owner, 11),
                    AlignCentre(cost, 6),
                    AlignCentre(rent, 9),
                    AlignCentre(colour, 9)));
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
