using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shematic
{
    List<ShemObj> Objects;
    List<NetworkConnection> NetworkConnections;

    public Shematic()
    {
        
    }

    public PhysicalAdress GetNextAddress( PhysicalAdress adress )
    {
        foreach (NetworkConnection item in NetworkConnections)
        {
            if (item.FindAdress(adress))
            {
                return item.GetNextAdress(adress);
            }
        }
        return null;
    }

}

