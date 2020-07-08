using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    class NetworkCard : BIOS
    {
        public int MyProperty { get; set; }
        public float Speed { get; }
        int _UsingResources;
        float _Health;
        public bool isWorking()
        {
            throw new NotImplementedException();
        }

        public void Use(Cooling[] coolings, int i = 1)
        {
            throw new NotImplementedException();
        }
    }
}
