using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Resources
{
    public class ResourcesStorage
    {
        public string NameDefaulMoney = "Money";
        public string NameDefaultElectricity = "Electricity";
        public string NameDefaultNetwork = "Network";
        //public string[] NamesTransleteToRID = new string[(int)RID];
        public Dictionary<RID, string> NameToRIDTranslete;
        List<ResourcesItem> Resources;

        public ResourcesStorage()
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(0, 0, 0);
        }

        public ResourcesStorage(int money = 0, int electrosity = 0, int network = 0)
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(money, electrosity, network);
        }

        public ResourcesStorage(List<ResourcesItem> resources, int money = 0, int electrosity = 0, int network = 0)
        {
            Resources = new List<ResourcesItem>();
            AddDefaultResources(money, electrosity, network);
            foreach (ResourcesItem item in resources)
            {
                item.FixValue();
                Resources.Add(item);
            }
        }

        void AddDefaultResources(int money, int electrosity, int network)
        {
            Resources.Add(new ResourcesItem(RID.Money, NameDefaulMoney, RIType.Acumulation, money));
            Resources.Add(new ResourcesItem(RID.Electricity, NameDefaultElectricity, RIType.Acumulation, electrosity));
            Resources.Add(new ResourcesItem(RID.Network, NameDefaultNetwork, RIType.Acumulation, network));
            
            NameToRIDTranslete = new Dictionary<RID, string>()
            {
                {RID.Money, NameDefaulMoney },
                {RID.Electricity, NameDefaultElectricity },
                {RID.Network, NameDefaultNetwork }
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
            resources.Add(Resources.Find(x => x.Name == NameDefaulMoney));
            resources.Add(Resources.Find(x => x.Name == NameDefaultElectricity));
            resources.Add(Resources.Find(x => x.Name == NameDefaultNetwork));
            return resources;
        }

        public List<ResourcesItem> GetOtherResources()
        {
            List<ResourcesItem> resources = new List<ResourcesItem>(Resources);
            resources.Remove(resources.Find(x => x.Name == NameDefaulMoney));
            resources.Remove(resources.Find(x => x.Name == NameDefaultElectricity));
            resources.Remove(resources.Find(x => x.Name == NameDefaultNetwork));
            return resources;
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
            ResourcesItem Money = Resources.Find(x => x.Name == NameDefaulMoney);
            ResourcesItem Electricity = Resources.Find(x => x.Name == NameDefaultElectricity);
            ResourcesItem Network = Resources.Find(x => x.Name == NameDefaultNetwork);

            Money.Count = ToCalculateByRID(Money.Id);
            Electricity.Count = ToCalculateByRID(Electricity.Id);
            Network.Count = ToCalculateByRID(Network.Id);

            List<ResourcesItem> Trash = SortByType(RIType.Profit);
            Trash.AddRange(SortByType(RIType.Waste));

            foreach (ResourcesItem item in Trash)
            {
                Resources.Remove(item);
            }

        }
    }
}
