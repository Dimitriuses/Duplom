using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public class CPU: BIOS
    {
        public char[] Socet { get; }
        public float BaseFerequency { get; }
        public float MaxFerequency { get; }
        public int NumberOfCores { get; }
        public int HeatOutput { get; }
        public bool withGPU;
        public bool Broken;
        public CPU(char[] socet, float baseF, float maxF, int cores, int heat, bool gpu)
        {
            Socet = new char[10];
            if(socet.Length == 10)
            {
                Socet = socet;
            }
            else
            {
                Socet = new char[10] { 'n', 'o', 'n', 'e', ' ', 's', 'o', 'c', 'e', 't' };
            }
            BaseFerequency = baseF;
            MaxFerequency = maxF;
            NumberOfCores = cores;
            HeatOutput = heat;
            withGPU = gpu;
            Broken = false;
        }

        public bool isWorking()
        {
            return !Broken;
        }

        public void Use(Cooling[] coolings, int i = 1)
        {
            if (isWorking())
            {
                float Ctmp = 0;
                foreach (Cooling item in coolings)
                {
                    Ctmp += item.GetHeatWorking();
                }
                if (Ctmp >= HeatOutput)
                {
                    Randomiser randomiser = new Randomiser();
                    float Htmp = HeatOutput / 100;
                    Broken = randomiser.GetRandomNumber(HeatOutput - Htmp, Ctmp) < HeatOutput;
                    foreach (Cooling item in coolings)
                    {
                        item.Use();
                    }
                }
            }
        }
    }
}
