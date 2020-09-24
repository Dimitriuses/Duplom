using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public enum SataStorageType
{
    HHD = 100000,
    SSD = 500000,
    M2 = 900000,
}
public class SataStorage : ScriptableObject, BIOS, PCIExpress
{
    public int Capacity { get; }
    public SataStorageType Type { get; }
    public float Speed { get; }
    int _UsingResources;
    float _Health;

    public SataStorage(int capacity, SataStorageType type, float speed, float health = 100)
    {
        Capacity = capacity;
        Type = type;
        Speed = speed;
        _Health = health;
        _UsingResources = (int)Type;
    }

    public float GetUsingResouces()
    {
        return _UsingResources;
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        if (_UsingResources - i > 0 && isWorking())
        {
            _UsingResources -= i;
            Randomiser randomiser = new Randomiser();
            float htemp = _UsingResources / ((int)Type / 100);
            _Health = (float)randomiser.GetRandomNumber(htemp, _Health);
            foreach (Cooling item in coolings)
            {
                item.Use(1);
            }
        }

    }

    public bool isWorking()
    {
        return _Health > 0;
    }

    public bool CanConnectToPCIE()
    {
        return Type == SataStorageType.M2;
    }
}
