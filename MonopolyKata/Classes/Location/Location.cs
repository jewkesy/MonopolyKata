using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Classes.Location
{
    public class Location : LocationBase
    {
        public bool Purchased;
        public int TaxPrice;
        public TitleDeed TitleDeed;
    }
}
