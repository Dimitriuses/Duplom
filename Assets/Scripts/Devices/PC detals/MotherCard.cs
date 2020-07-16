using Assets.Scripts;
using Assets.Scripts.PC_detals;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MotherCard: BIOS
{
    int PCISize,PCIExpresSize, RAMSize, SATASize;
    char[] Socet;
    public CPU CPU { get; set; }
    public List<RAM> RAMs { get; set; }
    public List<SataStorage> Satas { get; set; }
    public List<PCI> PCIs { get; set; }
    public List<PCIExpress> PCIExpresses { get; set; }
    public List<Cooling> CoolingSystem { get; set; }

    public MotherCard(char[] socet, int ram = 2, int sata = 2, int pci = 1, int pcie = 1)
    {
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

    public bool isWorking()
    {
        throw new System.NotImplementedException();
    }

    public void Use(Cooling[] coolings, int i = 1)
    {
        throw new System.NotImplementedException();
    }
}
