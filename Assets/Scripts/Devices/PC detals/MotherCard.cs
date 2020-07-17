using Assets.Scripts;
using Assets.Scripts.PC_detals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MotherCard: BIOS
{
    int PCISize,PCIExpresSize, RAMSize, SATASize;
    char[] Socet;
    float _Health;
    public CPU CPU { get; set; }
    public List<RAM> RAMs { get; set; }
    public List<SataStorage> Satas { get; set; }
    public List<PCI> PCIs { get; set; }
    public List<PCIExpress> PCIExpresses { get; set; }
    public List<Cooling> CoolingSystem { get; set; }

    public MotherCard(char[] socet, int ram = 2, int sata = 2, int pci = 1, int pcie = 1)
    {
        _Health = 100;
        if(socet.Length == 10)
        {
            Socet = socet;
        }
        else
        {
            Socet = new char[10] { 'n', 'o', 'n', 'e', ' ', 's', 'o', 'c', 'e', 't' };
        }
        RAMSize = (ram >= 2) ? ram : 2;
        SATASize = (sata >= 2) ? sata : 2;
        PCISize = (pci >= 1) ? pci : 1;
        PCIExpresSize = (pcie >= 1) ? pcie : 1;
    }

    public bool isEverythingInPlace()
    {
        return CPU != null && RAMs != null && Satas != null && CoolingSystem != null 
            && RAMs.Count > 0 && Satas.Count > 0 && CoolingSystem.Count > 0;
    }

    public bool isWorking()
    {
        if (_Health > 0&&isEverythingInPlace())
        {
            List<BIOS> bios = new List<BIOS>();
            List<bool> isWorking = new List<bool>();
            bios.Add(CPU);
            RAMs.ForEach(x => { bios.Add(x); });
            Satas.ForEach(x => { bios.Add(x); });
            if (PCIs.Count > 0) { PCIs.ForEach(x => { bios.Add(x); });}
            if (PCIExpresses.Count > 0){ PCIExpresses.ForEach(x => { bios.Add(x); }); }
            bios.ForEach(x => { isWorking.Add(x.isWorking()); });
            CoolingSystem.ForEach(x => { isWorking.Add(x.isWorking()); });
            foreach (bool item in isWorking)
            {
                if (!item)
                {
                    return false;
                }
            }
            return true;
            

        }
        else
        {
            return false;
        }
        //throw new System.NotImplementedException();
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        if (isWorking())
        {
            Randomiser randomiser = new Randomiser();
            List<BIOS> bios = new List<BIOS>();
            bios.Add(CPU);
            RAMs.ForEach(x => { bios.Add(x); });
            Satas.ForEach(x => { bios.Add(x); });
            if (PCIs.Count > 0) { PCIs.ForEach(x => { bios.Add(x); }); }
            if (PCIExpresses.Count > 0) { PCIExpresses.ForEach(x => { bios.Add(x); }); }
            bios.ForEach(x => { x.Use(CoolingSystem.ToArray()); });
            _Health -= (float)randomiser.GetRandomNumber(0.001, 5);
        }
    }

    public int GetNetworkSize()
    {
        NetworkCard tmp = new NetworkCard();
        List<PCI> pci =  PCIs.FindAll(x => x.GetType().Equals(tmp.GetType()));
        List<PCIExpress> pcie = PCIExpresses.FindAll(x => x.GetType().Equals(tmp.GetType()));
        return pci.Count + pcie.Count;
    }
}
