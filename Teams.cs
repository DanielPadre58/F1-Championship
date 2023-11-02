using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Championship
{
    internal class Team
    {
        public string name;

        public Driver driver1;

        public Driver driver2;

        public int points;

        public int position;

        public double carAdvantage;

        public Team(string name)
        {
            this.name = name;
        }
    }
}
