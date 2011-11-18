using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Classes.Helpers
{
    public class ShuffleCards
    {
        static Random r = new Random();
        //      Based on Java code from wikipedia:
        //      http://en.wikipedia.org/wiki/Fisher-Yates_shuffle

        static public IList<Cards.BaseCard> Shuffle(IList<Cards.BaseCard> deck)
        {
            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Cards.BaseCard temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }

            return deck;
        }

        static public void ShuffleInts(int[] deck)
        {
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                int temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
    }
}
