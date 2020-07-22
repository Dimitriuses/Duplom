using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    //[CreateAssetMenu(menuName = "Player")]
    public class Player
    {
        public string nik;
        public ResourcesStorage ResourcesStorage;

        public Player(string nik = "Player")
        {
            this.nik = nik;
            ResourcesStorage = new ResourcesStorage();
        }

    }
}
