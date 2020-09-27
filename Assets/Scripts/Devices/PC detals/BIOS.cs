using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface BIOS
{
    bool isWorking();
    void Use(Cooling[] coolings, int i = 1);
}

