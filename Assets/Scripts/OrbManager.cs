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
    public Text autoClick2Text;
    public Text autoClick3Text;
    public Text autoClick4Text;
    public Text clickUpgradeText;

    public Text mat1Text;
    public Text mat2Text;
    public Text mat3Text;
    public Text mat4Text;

    public Text autoClickAlchemyText;
    public Text autoClick2AlchemyText;
    public Text autoClick3AlchemyText;
    public Text autoClick4AlchemyText;
    public Text clickUpgradeAlchemyText;
    public Text createMat4AlchemyText;

    public float insight;
    public float insightAmount = 1f;
    public float insightPerSec = 0f;

    public float autoClickCost = 10f;
    public float autoClickCost2 = 100f;
    public float autoClickCost3 = 500f;
    public float autoClickCost4 = 1000f;

    public float familiarAmount = 0;
    public float familiarStrength = 0.1f;
    public float familiar2Amount = 0;
    public float familiar2Strength = 1f;
    public float familiar3Amount = 0;
    public float familiar3Strength = 5f;
    public float familiar4Amount = 0;
    public float familiar4Strength = 10f;

    public float clickUpgradeCost = 100f;
    public float clickUpgradeLevel;

    public float mat1 = 0f;
    public float mat1Cost = 150f;
    public float mat2 = 0f;
    public float mat2Cost = 200f;
    public float mat3 = 0f;
    public float mat3Cost = 250f;
    public float mat4 = 0f;
    public float mat4Cost = 1;

    public float alchemyAutoClickCost = 1f;
    public float alchemyAutoClick2Cost = 1;
    public float alchemyAutoClick3Cost = 1;
    public float alchemyAutoClick4Cost = 1;
    public float alchemyClickUpgradeCost = 1f;

    // Start is called before the first frame update
    void Start()
    {
        insight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        insightPerSec = familiarAmount * familiarStrength + familiar2Amount * familiar2Strength + familiar3Amount * familiar3Strength + familiar4Amount * familiar4Strength;
        insight += insightPerSec * Time.deltaTime;

        insightText.text = "i: " + insight.ToString("F1");
        insightPerSecText.text = Math.Round(insightPerSec, 2) + " per second";

        autoClickText.text = "Summon Familiar \ni: " + autoClickCost.ToString("F1") + "\n" + familiarAmount;
        autoClick2Text.text = "Summon Imp \ni: " + autoClickCost2.ToString("F1") + "\n" + familiar2Amount;
        autoClick3Text.text = "Summon Shadow Wizard \ni: " + autoClickCost3.ToString("F1") + "\n" + familiar3Amount;
        autoClick4Text.text = "Summon Sleep Demon \ni: " + autoClickCost4.ToString("F1") + "\n" + familiar4Amount;
        clickUpgradeText.text = "Research Technique \ni: " + clickUpgradeCost.ToString("F1") +"\n" + clickUpgradeLevel;

        mat1Text.text = "Material 1 \ni: " + mat1Cost + "\n" + mat1;
        mat2Text.text = "Material 2 \ni: " + mat2Cost + "\n" + mat2;
        mat3Text.text = "Material 3 \ni: " + mat3Cost + "\n" + mat3;
        mat4Text.text = "Material 4 \n" +mat4;

        autoClickAlchemyText.text = "Strengthen Familiar \nMaterial 1 x" + alchemyAutoClickCost + " + Material 2 x" + alchemyAutoClickCost;
        autoClick2AlchemyText.text = "Feed Imps \nMaterial 1 x" + alchemyAutoClick2Cost + " + Material 3 x" + alchemyAutoClick2Cost;
        autoClick3AlchemyText.text = "Shadow Wizard Money Gang \nMaterial 1 x" + alchemyAutoClick3Cost + " + Material 4 x" + alchemyAutoClick3Cost;
        autoClick4AlchemyText.text = "Crystallise Dreams \nMaterial 2 x" + alchemyAutoClick4Cost + " + Material 4 x" + alchemyAutoClick4Cost;
        clickUpgradeAlchemyText.text = "Refine Orb \nMaterial 3 x" + alchemyClickUpgradeCost + " + Material 4 x" + alchemyClickUpgradeCost;
    }

    public void Click()
    {
        insight += insightAmount;
    }

    public void AutoClick()
    {
        if (insight >= autoClickCost) 
        {

        familiarAmount++;
        insight -= autoClickCost;
        autoClickCost *= 1.07f;
        
        }
    }

    public void AutoClick2()
    {
        if (insight >= autoClickCost2)
        {
            familiar2Amount++;
            insight -= autoClickCost2;
            autoClickCost2 *= 1.07f;
        }
    }

    public void AutoClick3()
    {
        if (insight >= autoClickCost3)
        {
            familiar3Amount++;
            insight -= autoClickCost3;
            autoClickCost3 *= 1.07f;
        }
    }

    public void AutoClick4()
    {
        if (insight >= autoClickCost4)
        {
            familiar4Amount++;
            insight -= autoClickCost4;
            autoClickCost4 *= 1.07f;
        }
    }
    
    public void DoubleClick()
    {
        if (insight >= clickUpgradeCost)
        {
            clickUpgradeLevel++;
            insightAmount *= 2;
            insight -= clickUpgradeCost;
            clickUpgradeCost *= 10;
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

    public void BuyMat3()
    {
        if (insight >= mat3Cost)
        {
            mat3++;
            insight -= mat3Cost;
        }
    }

    public void BuyMat4()
    {
        if (mat2 >= mat4Cost && mat3 >= mat4Cost)
        {
            mat4++;
            mat2 -= mat4Cost;
            mat3 -= mat4Cost;
        }
    }

    public void AutoClickAlchemy()
    {
        if (mat1 >= alchemyAutoClickCost && mat2 >= alchemyAutoClickCost)
        {
            familiarStrength *= 2f;
            mat1 -= alchemyAutoClickCost;
            mat2 -= alchemyAutoClickCost;
            alchemyAutoClickCost *= 2f;
        }
    }

    public void AutoClick2Alchemy()
    {
        if(mat1 >= alchemyAutoClick2Cost && mat3 >= alchemyAutoClick2Cost)
        {
            familiar2Strength *= 2f;
            mat1 -= alchemyAutoClick2Cost;
            mat3 -= alchemyAutoClick2Cost;
            alchemyAutoClick2Cost *= 2f;
        }
    }

    public void AutoClick3Alchemy()
    {
        if (mat1 >= alchemyAutoClick3Cost && mat4 >= alchemyAutoClick3Cost)
        {
            familiar3Strength *= 2f;
            mat1 -= alchemyAutoClick3Cost;
            mat4 -= alchemyAutoClick3Cost;
            alchemyAutoClick3Cost *= 2f;
        }
    }

    public void AutoClick4Alchemy()
    {
        if (mat2 >= alchemyAutoClick4Cost && mat4 >= alchemyAutoClick4Cost)
        {
            familiar4Strength *= 2f;
            mat2 -= alchemyAutoClick4Cost;
            mat4 -= alchemyAutoClick4Cost;
            alchemyAutoClick4Cost *= 2f;
        }
    }

    public void DoubleClickAlchemy()
    {
        if (mat3 >= alchemyClickUpgradeCost && mat4 >= alchemyClickUpgradeCost)
        {
            insightAmount *= 2;
            mat3 -= alchemyClickUpgradeCost;
            mat4 -= alchemyClickUpgradeCost;
            alchemyClickUpgradeCost *= 10;
        }
    }
}
