using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public RID GetRandomRID()
        {
            Array values = Enum.GetValues(typeof(RID));
            return (RID)values.GetValue((int)GetRandomNumber(0, values.Length));
        }

        public RIType GetRandomRIType()
        {
            Array values = Enum.GetValues(typeof(RIType));
            return (RIType)values.GetValue((int)GetRandomNumber(0, values.Length));
        }
    }
