using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public enum MType
    {
        DDR1,
        DDR2,
        DDR3,
        DDR4
    }
    public class RAM: BIOS
    {
        const int DefaulMemoryResource = 40000000;
        public MType Type { get; }
        public int Capacity { get; }
        public float Speed { get; }
        int _UsingResources;
        float _Health;

        public RAM(int capacity, MType type, float speed, float health = 100)
        {
            Capacity = capacity;
            Type = type;
            Speed = speed;
            _Health = health;
            _UsingResources = DefaulMemoryResource;
        }

        public bool isWorking()
        {
            return _Health < 0;
        }

        public void Use(Cooling[] coolings, int i = 1)
        {
            if (_UsingResources - i > 0 && isWorking())
            {
                _UsingResources -= i;
                Randomiser randomiser = new Randomiser();
                float htemp = _UsingResources / (DefaulMemoryResource/100);
                _Health = (float)randomiser.GetRandomNumber(htemp, _Health);
                foreach (Cooling item in coolings)
                {
                    item.Use(1);
                }
            }
        }
    }
}
