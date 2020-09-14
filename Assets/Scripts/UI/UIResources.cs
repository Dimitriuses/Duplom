using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Resources;
using UnityEngine.UI;

public class UIResources : MonoBehaviour
{
    public Text Money;
    public Text Experience;
    public Text Electrosity;
    ResourcesStorage Resouces;



    void Start()
    {
        Resouces = new ResourcesStorage(111, 222, 333, 444);
    }

    void UpdateUpPanel()
    {
        List<ResourcesItem> resources = Resouces.GetDefaultResources();
        foreach (ResourcesItem item in resources)
        {
            if (item.Name.Equals(Resouces.NameDefaulMoney))
            {
                Money.text = item.Count.ToString();
            }
                    if (item.Name.Equals(Resouces.NameDefaultExperience))
                    {
                        Experience.text = item.Count.ToString();
                    }
                    if (item.Name.Equals(Resouces.NameDefaultElectricity))
                    {
                        Electrosity.text = item.Count.ToString();
                    }
                }
    }

    void UpdateStatusPanel()
    {
        Resouces.TestFill(10, 100);
        List<ResourcesItem> resourcesMoney = Resouces.SortByRID(RID.Money);
        List<ResourcesItem> resourcesExperience = Resouces.SortByRID(RID.Experience);
        List<ResourcesItem> resourcesElectrosity = Resouces.SortByRID(RID.Electricity);

    }
    void Update()
    {
        UpdateUpPanel();
        UpdateStatusPanel();
    }
}