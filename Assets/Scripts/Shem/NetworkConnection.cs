using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NetworkConnection
{
    public PhysicalAdress FirstAdress;
    public PhysicalAdress SecondAdress;

    public NetworkConnection( PhysicalAdress first, PhysicalAdress second)
    {
        FirstAdress = first;
        SecondAdress = second;
    }

    public bool FindAdress(PhysicalAdress adress)
    {
        return FirstAdress.Equals(adress) || SecondAdress.Equals(adress);
    }

    public PhysicalAdress GetNextAdress(PhysicalAdress adress)
    {
        if (FindAdress(adress))
        {
            return (FirstAdress.Equals(adress)) ? SecondAdress : FirstAdress;
        }
        return null;
    }
}

    
