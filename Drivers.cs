using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Championship
{
    internal class Driver 
    {
        public string name;

        public int points;

        public double talent;

        public double currentChance;

        public Driver(string name) 
        {
            this.name = name;
            points = 0;
            currentChance = 0;
        }    
    }
}
