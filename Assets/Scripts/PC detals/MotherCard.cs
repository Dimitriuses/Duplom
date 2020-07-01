using Assets.Scripts;
using Assets.Scripts.PC_detals;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MotherCard : MonoBehaviour
{
    int PCISize,PCIExpresSize, RAMSize, SATASize;
    char[] Socet;
    public CPU CPU { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Socet = new char[10];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
