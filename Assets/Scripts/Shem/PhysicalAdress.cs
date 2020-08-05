﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class PhysicalAdress
{
    public string Adress => _adress.ToString();
    GUID _adress;
    public PhysicalAdress()
    {
        _adress = GUID.Generate();
    }
    public PhysicalAdress(string hexAdress)
    {
        _adress = new GUID(hexAdress);
    }
    // override object.Equals
    public override bool Equals(object obj)
    {
        //       
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237  
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        // TODO: write your implementation of Equals() here
        //throw new NotImplementedException();
        return ((PhysicalAdress)obj).Adress.Equals(Adress);
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        //throw new NotImplementedException();
        return base.GetHashCode();
    }
}
