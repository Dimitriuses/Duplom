using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Math;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Resources
{
    //[CreateAssetMenu(menuName = "ResourcesItem")]
    public class ResourcesItem
    {
        public RID Id;
        public string Name;
        public RIType Type;
        public int Count;

        public ResourcesItem(RID id, string name, RIType type, int cout)
        {
            Id = id;
            Name = name;
            Type = type;
            Count = cout;
        }


        public static ResourcesItem operator + (ResourcesItem t0, ResourcesItem t1)
        {
            if (t0.Id != t1.Id) throw new UnityException("Items are different (id)");
            var newItem = new ResourcesItem(t0.Id, t0.Name, t0.Type, t0.Count + t1.Count);
            
            if(t0.Type == RIType.Acumulation)
            {
                newItem = new ResourcesItem(t0.Id, t0.Name, t0.Type, t0.Count + t1.Count);
            }
            else if(t1.Type == RIType.Acumulation && t0.Type != RIType.Acumulation)
            {
                newItem = new ResourcesItem(t0.Id, t1.Name, t1.Type, t0.Count + t1.Count);
            }

            return newItem;
        }

        public void FixValue()
        {
            switch (Type)
            {
                case RIType.Acumulation:
                    if (Count < 0)
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count = Math.Abs(Count);
                    }
                    break;
                case RIType.Profit:
                    Count = Math.Abs(Count);
                    break;
                case RIType.Waste:
                    Count = 0 - Math.Abs(Count);
                    break;
                default:
                    break;
            }
        }

        public string ToString()
        {
            string Rezult = Name + " " + Count;
            switch (Id)
            {
                case RID.Money:
                    Rezult += "$";
                    break;
                case RID.Electricity:
                    Rezult += "Wt";
                    break;
                case RID.Network:
                    Rezult += "Mbit";
                    break;
                case RID.Experience:
                    Rezult += "Xp";
                    break;
                default:
                    break;
            }
            return Rezult;
        }
    }
}
