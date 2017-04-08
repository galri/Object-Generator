using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator
{
    public class RandomeGenerator : IRandome
    {
        private Random randome = new Random();

        public int get(int min, int max)
        {
            return randome.Next(0,2);
        }
    }
}
