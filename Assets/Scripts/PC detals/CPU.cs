using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public class CPU
    {
        char[] Socet;
        float BaseFerequency;
        float MaxFerequency;
        int NumberOfCores;
        int HeatOutput;
        public bool withGPU;
        public bool Broken;
        public CPU()
        {
            Socet = new char[10];
            Broken = false;
        }
    }
}
