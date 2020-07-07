using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public enum CoolingType
    {
        Active = 15,
        Pasive = 50,
    }
    public class Cooling
    {
        public CoolingType Type { get; }
        float _HeatWorking;
        float _Health;

        public Cooling(float hworking, CoolingType type)
        {
            Type = type;
            _HeatWorking = hworking * (int)Type;
            _Health = 100;
        }

        public float GetHeatWorking()
        {
            return _HeatWorking;
        }

        public bool isWorking()
        {
            return _Health > 0;
        }

        public void Use( int i = 1)
        {
            float tmp = i / 1000;
            if (isWorking() && _Health - tmp > 0) 
            {
                _HeatWorking = (_HeatWorking / (int)Type) / _Health * (_Health - tmp);
                _Health -= tmp;
            }
        }
    }
}
