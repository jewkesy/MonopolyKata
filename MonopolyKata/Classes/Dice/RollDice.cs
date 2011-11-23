using System;

namespace MonopolyKata.Classes.Dice
{
    public static class RollDice
    {
        private static readonly Random Rnd = new Random();

        public static int GetRolledDiceValue()
        {
            return Rnd.Next(6) + 1;
        }

    }
}
