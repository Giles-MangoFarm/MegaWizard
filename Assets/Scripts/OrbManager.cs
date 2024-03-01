using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OrbManager : MonoBehaviour
{
    public Text insightText;
    public Text insightPerSecText;
    public Text autoClickText;
    public Text clickUpgradeText;

    public float insight;
    public float insightAmount = 1f;
    public float insightPerSec = 0f;

    public float autoClickCost = 10f;
    public float autoClickUpgradeLevel;

    public float clickUpgradeCost = 100f;
    public float clickUpgradeLevel;

    // Start is called before the first frame update
    void Start()
    {
        insight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        insight += insightPerSec * Time.deltaTime;

        insightText.text = "i: " + insight.ToString("F1");
        insightPerSecText.text = Math.Round(insightPerSec, 2) + " per second";
        autoClickText.text = "Summon Familiar \ni: " + autoClickCost.ToString("F1") + "\n" + autoClickUpgradeLevel;
        clickUpgradeText.text = "Improve da Orb \ni: " + clickUpgradeCost.ToString("F1") +"\n" + clickUpgradeLevel;
    }

    public void Click()
    {
        insight += insightAmount;
    }

    public void AutoClick()
    {
        if (insight >= autoClickCost) 
        {
        autoClickUpgradeLevel++;
        insightPerSec += 0.1f;
        insight -= autoClickCost;
        autoClickCost *= 1.07f;
        
        }
    }
    
    public void DoubleClick()
    {
        if (insight >= clickUpgradeCost)
        {
            clickUpgradeLevel++;
            insightAmount *= 2;
            insight -= clickUpgradeCost;
            clickUpgradeCost *= 1.07f;
        }
    }
}
