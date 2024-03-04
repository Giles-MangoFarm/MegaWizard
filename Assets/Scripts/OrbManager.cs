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
    public Text mat1Text;
    public Text mat2Text;
    public Text autoClickAlchemyText;
    public Text clickUpgradeAlchemyText;

    public float insight;
    public float insightAmount = 1f;
    public float insightPerSec = 0f;

    public float autoClickCost = 10f;
    public float autoClickUpgradeLevel;

    public float familiarAmount = 0;
    public float familiarStrength = 0.1f;

    public float clickUpgradeCost = 100f;
    public float clickUpgradeLevel;

    public int mat1 = 0;
    public float mat1Cost = 150f;
    public int mat2 = 0;
    public float mat2Cost = 200f;

    public int alchemyAutoClickCost = 1;
    public int alchemyClickUpgradeCost = 5;

    // Start is called before the first frame update
    void Start()
    {
        insight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        insightPerSec = familiarAmount * familiarStrength;
        insight += insightPerSec * Time.deltaTime;

        insightText.text = "i: " + insight.ToString("F1");
        insightPerSecText.text = Math.Round(insightPerSec, 2) + " per second";
        autoClickText.text = "Summon Familiar \ni: " + autoClickCost.ToString("F1") + "\n" + autoClickUpgradeLevel;
        clickUpgradeText.text = "Research Technique \ni: " + clickUpgradeCost.ToString("F1") +"\n" + clickUpgradeLevel;
        mat1Text.text = "Material 1 \ni: " + mat1Cost + "\n" + mat1;
        mat2Text.text = "Material 2 \ni: " + mat2Cost + "\n" + mat2;
        autoClickAlchemyText.text = "Strengthen Familiar \nM1 x" + alchemyAutoClickCost + " + M2 x" + alchemyAutoClickCost;
        clickUpgradeAlchemyText.text = "Refine Orb \nM1 x" + alchemyClickUpgradeCost + " + M2 x" + alchemyClickUpgradeCost;
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
        familiarAmount++;
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
            clickUpgradeCost *= 1.15f;
        }
    }

    public void BuyMat1()
    {
        if (insight >= mat1Cost)
        {
            mat1++;
            insight -= mat1Cost;
        }
    }

    public void BuyMat2()
    {
        if (insight >= mat2Cost)
        {
            mat2++;
            insight -= mat2Cost;
        }
    }

    public void AutoClickAlchemy()
    {
        if (mat1 + mat2 >= alchemyAutoClickCost)
        {
            insightPerSec *= 2f;
            familiarStrength *= 2f;
            mat1 -= alchemyAutoClickCost;
            mat2 -= alchemyAutoClickCost;
            alchemyAutoClickCost *= 2;
        }
    }

    public void DoubleClickAlchemy()
    {
        if (mat1 + mat2 >= alchemyClickUpgradeCost)
        {
            insightAmount += clickUpgradeLevel;
            mat1 -= alchemyClickUpgradeCost;
            mat2 -= alchemyClickUpgradeCost;
            alchemyClickUpgradeCost *= 2;
        }
    }
}
