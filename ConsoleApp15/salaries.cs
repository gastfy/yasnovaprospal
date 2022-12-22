using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class salaries
    {
        public string ID;
        public string Name;
        public int sum;
        public string date;
        public string dopOrMinus;

        public salaries(string _ID, string _Name, int _sum, string _date, string _d)
        {
            ID = _ID;
            Name = _Name;
            sum = _sum;
            date = _date;
            dopOrMinus = _d;
        }


    }
}
