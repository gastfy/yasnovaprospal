using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class goods
    {
        public string ID;
        public string Name;
        public int CostForPiece;
        public int Amount;
        public goods(string iD, string name, int costForPiece, int amount)
        {
            ID = iD;
            Name = name;
            CostForPiece = costForPiece;
            Amount = amount;
        }
    }
}
