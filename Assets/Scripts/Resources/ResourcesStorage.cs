﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    //[CreateAssetMenu(menuName = "ResourcesStorage")]
    public class ResourcesStorage
    {

        public string NameDefaulMoney = "Money";
        public string NameDefaultElectricity = "Electricity";
        public string NameDefaultNetwork = "Network";
        public string NameDefaultExperience = "Experience";
        public string NameDefaultSkillCoin = "SkillCoins";
        //public string[] NamesTransleteToRID = new string[(int)RID];
        public Dictionary<RID, string> NameToRIDTranslete;
        List<ResourcesItem> Resources;

        public ResourcesStorage()
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(0, 0, 0, 0, 0);
        }

        public ResourcesStorage(int money = 0, int electrosity = 0, int network = 0, int experience = 0, int skillcoins = 0)
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(money, electrosity, network, experience, skillcoins);
        }

        public ResourcesStorage(List<ResourcesItem> resources, int money = 0, int electrosity = 0, int network = 0, int experience = 0, int skillcoins = 0)
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(money, electrosity, network, experience, skillcoins);
            foreach (ResourcesItem item in resources)
            {
                item.FixValue();
                Resources.Add(item);
            }
        }

        void AddDefaultResources(int money, int electrosity, int network, int experience = 0, int skillcoin = 0)
        {
            Resources.Add(new ResourcesItem(RID.Money, NameDefaulMoney, RIType.Acumulation, money));
            Resources.Add(new ResourcesItem(RID.Electricity, NameDefaultElectricity, RIType.Acumulation, electrosity));
            Resources.Add(new ResourcesItem(RID.Network, NameDefaultNetwork, RIType.Acumulation, network));
            Resources.Add(new ResourcesItem(RID.Experience, NameDefaultExperience, RIType.Acumulation, experience));
            Resources.Add(new ResourcesItem(RID.Experience, NameDefaultSkillCoin, RIType.Acumulation, skillcoin));

            NameToRIDTranslete = new Dictionary<RID, string>()
            {
                {RID.Money, NameDefaulMoney },
                {RID.Electricity, NameDefaultElectricity },
                {RID.Network, NameDefaultNetwork },
                {RID.Experience, NameDefaultExperience },
                //{RID.Experience, NameDefaultSkillCoin }
            };
            //NameToRIDTranslete.Add(RID.Money, NameDefaulMoney);
            //NameToRIDTranslete.Add(RID.Electricity, NameDefaultElectricity);
            //NameToRIDTranslete.Add(RID.Network, NameDefaultNetwork);
        }

        public void AddResource(ResourcesItem item)
        {
            item.FixValue();
            Resources.Add(item);
        }

        public List<ResourcesItem> GetResources()
        {
            return Resources;
        }

        public List<ResourcesItem> GetDefaultResources()
        {
            List<ResourcesItem> resources = new List<ResourcesItem>();
            foreach (KeyValuePair<RID, string> item in NameToRIDTranslete)
            {
                resources.Add(Resources.Find(x => x.Name == item.Value));
            }
            return resources;
        }

        public List<ResourcesItem> GetOtherResources()
        {
            List<ResourcesItem> resources = new List<ResourcesItem>(Resources);
            foreach (KeyValuePair<RID,string> item in NameToRIDTranslete)
            {
                resources.Remove(resources.Find(x => x.Name == item.Value));
            }
            return resources;
        }

        public List<ResourcesItem> FindByName(string name)
        {
            List<ResourcesItem> resources = new List<ResourcesItem>();
            foreach (ResourcesItem item in Resources)
            {
                if (item.Name.Equals(name))
                {
                    resources.Add(item);
                }
            }
            return resources;
        }

        public bool ChangeCountByName(string name,int count)
        {
            List<ResourcesItem> resources = FindByName(name);
            if(resources.Count > 0)
            {
                foreach (ResourcesItem item in resources)
                {
                    if(item.Type == RIType.Acumulation)
                    {
                        ResourcesItem item1 = item;
                        item1.Count = count;
                        Resources.Remove(item);
                        Resources.Add(item1);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteResourceByName(string name)
        {
            List<ResourcesItem> resources = new List<ResourcesItem>();

            foreach (ResourcesItem item in Resources)
            {
                if (item.Name.Equals(name))
                {
                    resources.Add(item);
                }
            }

            if (resources.Count > 0)
            {
                foreach (ResourcesItem item in resources)
                {
                    Resources.Remove(item);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ResourcesItem> SortByType(RIType type)
        {
            List<ResourcesItem> items = new List<ResourcesItem>();

            foreach (ResourcesItem item in Resources)
            {
                if(item.Type == type)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public List<ResourcesItem> SortByRID(RID id)
        {
            List<ResourcesItem> items = new List<ResourcesItem>();

            foreach (ResourcesItem item in Resources)
            {
                if (item.Id == id)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public List<ResourcesItem> Sort(RID id, RIType type)
        {
            List<ResourcesItem> items = new List<ResourcesItem>();

            foreach (ResourcesItem item in Resources)
            {
                if (item.Id == id && item.Type == type)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public int ToCalculateByRID(RID id)
        {
            string DNTemp = NameToRIDTranslete.FirstOrDefault(x => x.Key == id).Value;
            ResourcesItem DefIA = Resources.Find(x => x.Name == DNTemp);

            foreach (ResourcesItem item in Resources)
            {
                if(item.Id == id && item.Type != RIType.Acumulation)
                {
                    DefIA += item;
                }
            }

            return DefIA.Count;
        }

        public void ToCalculateAll()
        {
            //List<ResourcesItem> resources = new List<ResourcesItem>();
            foreach (KeyValuePair<RID,string> item in NameToRIDTranslete)
            {
                ResourcesItem TMP = Resources.Find(x => x.Name == item.Value);
                Resources.Remove(TMP);
                TMP.Count = ToCalculateByRID(TMP.Id);
                Resources.Add(TMP);
            }

            List<ResourcesItem> Trash = SortByType(RIType.Profit);
            Trash.AddRange(SortByType(RIType.Waste));

            foreach (ResourcesItem item in Trash)
            {
                Resources.Remove(item);
            }

        }

        public void TestFill(int minimum,int maximum)
        {
            Randomiser randomiser = new Randomiser();
            int Imax = (int)randomiser.GetRandomNumber(minimum, maximum);
            for (int i = 0; i < Imax; i++)
            {
                ResourcesItem item = new ResourcesItem(
                    randomiser.GetRandomRID(),
                    "Test" + i,
                    randomiser.GetRandomRIType(), 
                    (int)randomiser.GetRandomNumber(1, int.MaxValue)
                    );
                
                if(item.Type == RIType.Acumulation)
                {
                    item.Type = RIType.Profit;
                }
                item.FixValue();
                Resources.Add(item);
                //Debug.Log(item.ToString() + "  " + item.Type);
            }
            
        }
        public void Show()
        {
            Resources.ForEach(item =>
            {
                UnityEngine.Debug.Log(item.ToString() + "  " + item.Type + "  " + item.Id);
            });
        }
    }
}
