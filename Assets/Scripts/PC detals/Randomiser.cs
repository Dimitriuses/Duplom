using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public class Randomiser
    {
        Random Random;
        public Randomiser()
        {
            Random = new Random();
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            //Random random = new Random();
            return Random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
