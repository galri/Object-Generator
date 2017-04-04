using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator
{
    class RandomeGenerator : IRandome
    {
        private static Random randome = new Random(DateTime.Now.Millisecond);

        public int get(int min, int max)
        {
            return randome.Next(min, max);
        }
    }
}
