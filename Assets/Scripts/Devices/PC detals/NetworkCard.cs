using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum CNType
{
    LAN = 100 * 1024,
    WLAN = 300 * 1024,
    OLAN = 100 * 1024 * 1024
}
public class NetworkCard : PCI, PCIExpress, BIOS
{
    const int DefaulNetworkCardResource = 1000000;
    //public int Settings { get; set; }
    public CNType Type { get; }
    public float Speed { get; }
    int _UsingResources;
    float _Health;

    public NetworkCard(CNType type = CNType.LAN)
    {
        Type = type;
        Speed = (float)type;
        _UsingResources = DefaulNetworkCardResource;
        _Health = 100;
    }
    public bool isWorking()
    {
        return _Health > 0;
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        if (_UsingResources - i > 0 && isWorking())
        {
            _UsingResources -= i;
            Randomiser randomiser = new Randomiser();
            float htemp = _UsingResources / (DefaulNetworkCardResource / 100);
            _Health = (float)randomiser.GetRandomNumber(htemp, _Health);
            foreach (Cooling item in coolings)
            {
                item.Use(1);
            }
        }
    }

    public bool CanConnectToPCIE()
    {
        return true;
    }
}