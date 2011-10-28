using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Classes.Location
{
    public class Purchasable : LocationBase
    {
        public int PurchasePrice;
        public int MortgagePrice;
        public int SellPrice;

        public int Rent;
    }
}
