using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PCIExpress : ScriptableObject, BIOS
{
    public bool isWorking()
    {
        throw new NotImplementedException();
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        throw new NotImplementedException();
    }

    public bool CanConnectToPCIE()
    {
        throw new NotImplementedException();
    }
}
