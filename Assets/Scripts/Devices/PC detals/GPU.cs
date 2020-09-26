using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum GCType
{
    GeForce,
    NVidia,
    QUADRO,
    Radeon,
    RX
}
public class GPU :PCIExpress, BIOS
{
    [Header("Characteristics")]
    public GCType Type;
    public int Ferequency;
    public int GMCapacity;
    public List<Cooling> CoolingSystem;
    public int HeatOutput;
    public bool Broken;

    //public GPU(GCType type, int ferequency, int graph_memory_capacit)
    //{
    //    Type = type;
    //    Ferequency = ferequency;
    //    GMCapacity = graph_memory_capacit;
    //    CoolingSystem = new List<Cooling>()
    //        {
    //            new Cooling(HeatOutput,CoolingType.Active),
    //            new Cooling(HeatOutput,CoolingType.Active),
    //            new Cooling(HeatOutput/2,CoolingType.Pasive)
    //        };
    //}

    public bool CanConnectToPCIE()
    {
        return true;
    }

    public bool isWorking()
    {
        return Broken;
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        if (isWorking())
        {
            float Ctmp = 0;
            foreach (Cooling item in CoolingSystem)
            {
                Ctmp += item.GetHeatWorking();
            }
            foreach (Cooling item in coolings)
            {
                Ctmp += item.GetHeatWorking();
            }
            if (Ctmp >= HeatOutput)
            {
                Randomiser randomiser = new Randomiser();
                float Htmp = HeatOutput / 100;
                float HR = (float)randomiser.GetRandomNumber(HeatOutput - Htmp, Ctmp);
                Broken = HR < HeatOutput;
                int HBtmp = 0;
                foreach (Cooling item in CoolingSystem)
                {
                    if (!item.isWorking())
                    {
                        HBtmp++;
                    }
                    item.Use(HR);
                }
                foreach (Cooling item in coolings)
                {
                    item.Use(HR / HBtmp);
                }
            }
        }
    }
}