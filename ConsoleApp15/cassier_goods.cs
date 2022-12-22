using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Cassier_goods : goods
    {
        public int used_count = 0;

        public Cassier_goods(string iD, string name, int costForPiece, int amount) : base(iD, name, costForPiece, amount)
        {
            ID = iD;
            Name = name;
            CostForPiece = costForPiece;
            Amount = amount;
        }
    }
}
