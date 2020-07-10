using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public enum CoolingType
    {
        Active = 25,
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

        public void Use(float heatInput,int i = 1)
        {
            float tmp = i / 1000;
            if (isWorking() && _Health - tmp > 0) 
            {
                float HHP = _HeatWorking / _Health;
                float HETmp = (_HeatWorking / (int)Type) - heatInput;
                //_HeatWorking = (_HeatWorking / (int)Type) / _Health * (_Health - tmp);
                if (HETmp < 0)
                {
                    _HeatWorking += HETmp;
                    _Health -= Math.Abs(HETmp)/HHP;
                }
                else
                {
                    _HeatWorking -= tmp * HHP;
                    _Health -= tmp;
                }
               
                
            }
        }
    }
}
