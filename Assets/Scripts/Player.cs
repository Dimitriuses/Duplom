using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts
{
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
