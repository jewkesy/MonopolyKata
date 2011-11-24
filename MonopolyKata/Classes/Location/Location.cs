using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Classes.Players;

namespace MonopolyKata.Classes.Location
{
    public class Location : LocationBase
    {
        public bool Purchased;
        public int TaxPrice;
        public TitleDeed TitleDeed;
        public Player Owner;
    }
}
