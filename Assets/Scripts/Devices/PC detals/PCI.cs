using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PC_detals
{
    public abstract class PCI : ScriptableObject, BIOS 
    {
        public bool isWorking()
        {
            //throw new NotImplementedException();
            return false;
        }

        public void Use(Cooling[] coolings, int i = 1)
        {
            //throw new NotImplementedException();
        }
    }
}
