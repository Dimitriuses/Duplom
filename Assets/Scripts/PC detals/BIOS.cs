using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PC_detals
{
    public interface BIOS
    {
        public bool isWorking();
        public void Use(Cooling[] coolings, int i = 1);
    }
}
