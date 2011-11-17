using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Classes.Cards
{
    public class BaseCard
    {
        public string Title { get; set; }
        public string SubText { get; set; }
        public int Reward { get; set; }
        public int Penalty { get; set; }
    }
}
