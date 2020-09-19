using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Resources;
using UnityEngine.UI;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System;

public class UIResources : MonoBehaviour
{
    public Text Money;
    public Text Experience;
    public Text Electrosity;
    ResourcesStorage Resouces;
    public Text TextPrefab;
    public Transform MoneyScrollWiew;
    public Transform PoverScrollWiew;
    public Transform NetworkScrollWiew;

    public Color ColorProfit;
    public Color ColorWaste;


    void Start()
    {
        Resouces = new ResourcesStorage(111, 222, 333, 444,1);
        fillRecourcesTest();
        UpdateStatusPanel();
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

    void fillRecourcesTest()
    {
        Resouces.TestFill(10, 100);
        //Resouces.Show();
    }

    public void UpdateStatusPanel()
    {
        List<ResourcesItem> resourcesMoney = Resouces.SortByRID(RID.Money);
        List<ResourcesItem> resourcesExperience = Resouces.SortByRID(RID.Experience);
        List<ResourcesItem> resourcesElectrosity = Resouces.SortByRID(RID.Electricity);
        foreach (ResourcesItem item in resourcesMoney)
        {

            if (item.Type != RIType.Acumulation)
            {
                Text tmpMoney = Instantiate(TextPrefab, MoneyScrollWiew) as Text;
                tmpMoney.color = (item.Type == RIType.Profit) ? ColorProfit : ColorWaste;
                tmpMoney.text = item.Count.ToString();
            }
            //MoneyScrollWiew.transform.SetAsFirstSibling(Text);
        }
        //Resouces.Show();
    }
    void Update()
    {
        UpdateUpPanel();
        
    }
}