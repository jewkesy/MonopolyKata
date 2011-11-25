using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MonopolyKata.Classes.Players
{
    public class Player: PlayerTokens
    {
        public PlayerType Type;

        public enum PlayerType
        {
            Human,
            [Description("CPU")] Cpu
        }
        
        public bool InJail;

        public int CurrentPosition;
        public int Money;
        public bool Bankrupt;
    }
}
