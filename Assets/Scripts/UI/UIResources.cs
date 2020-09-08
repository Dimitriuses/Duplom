using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Resources;
public class UIResources : MonoBehaviour
{
    ResourcesStorage Resouces;
    //public List<ResourcesItem> GetDefaultResources()
    //{
    //    List<ResourcesItem> resources = new List<ResourcesItem>();
    //    foreach (KeyValuePair<RID, string> item in NameToRIDTranslete)
    //    {
    //        resources.Add(Resouces.Find(x => x.Name == item.Value));
    //    }
    //    return resources;
    //}
    void Start()
    {
       // Resources = new ResourcesStorage(TESTmoney, TESTelectricity, TESTnetwork, TESTexperience);
    }
    void Update()
    {
        
    }
}