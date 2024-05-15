using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoatUpgrades : MonoBehaviour
{
    [Header("Upgrade levels")]
    public int boatSpeedLevel = 1;
    public TextMeshProUGUI boatSpeedLevelText;
    public int waterGunLevel = 1;
    public TextMeshProUGUI waterGunLevelText;
    public int boatDurabilityLevel = 1;
    public TextMeshProUGUI boatDurabilityLevelText;
    public int boatLevel = 1;
    public TextMeshProUGUI boatLevelText;
    public int maxLevel = 2;

    [Header("Boat speed")]
    public int speedRequiredCredits;
    public int speedRequiredWood, speedRequiredCoal, speedRequiredGold;
    public TextMeshProUGUI speedRequiredWoodText, speedRequiredCoalText, speedRequiredGoldText, speedRequiredCreditsText;

    [Header("Water gun")]
    public int gunRequiredCredits;
    public int gunRequiredWood, gunRequiredIron, gunRequiredGold;
    public TextMeshProUGUI gunRequiredWoodText, gunRequiredIronText, gunRequiredGoldText, gunRequiredCreditsText;

    [Header("Boat durability")]
    public int durabRequiredCredits;
    public int durabRequiredWood, durabRequiredStone, durabRequiredIron;
    public TextMeshProUGUI durabRequiredWoodText, durabRequiredStoneText, durabRequiredIronText, durabRequiredCreditsText;

    [Header("Buy a new boat")]
    public int buyBoatRequiredCredits;
    public int buyBoatRequiredWood, buyBoatRequiredStone, buyBoatRequiredCoal,
        buyBoatRequiredIron, buyBoatRequiredGold, buyBoatRequiredGem;

    public TextMeshProUGUI buyBoatRequiredWoodText, buyBoatRequiredStoneText,
        buyBoatRequiredCoalText, buyBoatRequiredIronText, buyBoatRequiredGoldText,
        buyBoatRequiredGemText, buyBoatRequiredCreditsText;

    [Header("References")]
    public ResourceInventory resourceInventory;
    public CreditManager creditManager;

    void Start()
    {
        LoadAllRequirements();
    }

    public void UpgradeBoatSpeed()
    {
        if (resourceInventory.woodAmount >= speedRequiredWood
            && resourceInventory.coalAmount >= speedRequiredCoal
            && resourceInventory.goldAmount >= speedRequiredGold
            && creditManager.credits >= speedRequiredCredits
            && boatSpeedLevel < maxLevel && boatSpeedLevel < 3)
        {

            resourceInventory.woodAmount -= speedRequiredWood;
            resourceInventory.coalAmount -= speedRequiredCoal;
            resourceInventory.goldAmount -= speedRequiredGold;
            creditManager.credits -= speedRequiredCredits;

            boatSpeedLevel++;

            PlayerPrefs.SetFloat("BoatSpeed", 5f + boatSpeedLevel);
            PlayerPrefs.SetInt("BoatSpeedLevel", boatSpeedLevel);

            if (boatSpeedLevel >= maxLevel || boatSpeedLevel >= 3)
            {
                boatSpeedLevelText.text = "MAX";
            }
            else
            {
                boatSpeedLevelText.text = "LVL " + boatSpeedLevel;
            }

            speedRequiredWood = RaisedRequirement(speedRequiredWood, speedRequiredWoodText);
            speedRequiredCoal = RaisedRequirement(speedRequiredCoal, speedRequiredCoalText);
            speedRequiredGold = RaisedRequirement(speedRequiredGold, speedRequiredGoldText);
            speedRequiredCredits = RaisedRequirement(speedRequiredCredits, speedRequiredCreditsText);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
    public void UpgradeWaterGun()
    {
        if (resourceInventory.woodAmount >= gunRequiredWood
           && resourceInventory.ironAmount >= gunRequiredIron
           && resourceInventory.goldAmount >= gunRequiredGold
           && creditManager.credits >= gunRequiredCredits
           && waterGunLevel < maxLevel && waterGunLevel < 3)
        {
            resourceInventory.woodAmount -= gunRequiredWood;
            resourceInventory.ironAmount -= gunRequiredIron;
            resourceInventory.goldAmount -= gunRequiredGold;
            creditManager.credits -= gunRequiredCredits;

            waterGunLevel++;
            PlayerPrefs.SetInt("WaterGunLevel", waterGunLevel);

            if (waterGunLevel >= maxLevel || waterGunLevel >= 3)
            {
                waterGunLevelText.text = "MAX";
            }
            else
            {
                waterGunLevelText.text = "LVL " + waterGunLevel;
            }

            gunRequiredWood = RaisedRequirement(gunRequiredWood, gunRequiredWoodText);
            gunRequiredIron = RaisedRequirement(gunRequiredIron, gunRequiredIronText);
            gunRequiredGold = RaisedRequirement(gunRequiredGold, gunRequiredGoldText);
            gunRequiredCredits = RaisedRequirement(gunRequiredCredits, gunRequiredCreditsText);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
    public void UpgradeBoatDurability()
    {
        if (resourceInventory.woodAmount >= durabRequiredWood
           && resourceInventory.stoneAmount >= durabRequiredStone
           && resourceInventory.ironAmount >= durabRequiredIron
           && creditManager.credits >= durabRequiredCredits
           && boatDurabilityLevel < maxLevel && boatDurabilityLevel < 3)
        {
            resourceInventory.woodAmount -= durabRequiredWood;
            resourceInventory.stoneAmount -= durabRequiredStone;
            resourceInventory.ironAmount -= durabRequiredIron;
            creditManager.credits -= durabRequiredCredits;

            boatDurabilityLevel++;
            PlayerPrefs.SetInt("BoatDurabilityLevel", boatDurabilityLevel);

            if (boatDurabilityLevel >= maxLevel || boatDurabilityLevel >= 3)
            {
                boatDurabilityLevelText.text = "MAX";
            }
            else
            {
                boatDurabilityLevelText.text = "LVL " + boatDurabilityLevel;
            }

            durabRequiredWood = RaisedRequirement(durabRequiredWood, durabRequiredWoodText);
            durabRequiredStone = RaisedRequirement(durabRequiredStone, durabRequiredStoneText);
            durabRequiredIron = RaisedRequirement(durabRequiredIron, durabRequiredIronText);
            durabRequiredCredits = RaisedRequirement(durabRequiredCredits, durabRequiredCreditsText);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
    public void BuyNewBoat()
    {
        if (maxLevel <= 3
        && resourceInventory.woodAmount >= buyBoatRequiredWood
        && resourceInventory.stoneAmount >= buyBoatRequiredStone
        && resourceInventory.coalAmount >= buyBoatRequiredCoal
        && resourceInventory.ironAmount >= buyBoatRequiredIron
        && resourceInventory.goldAmount >= buyBoatRequiredGold
        && resourceInventory.gemAmount >= buyBoatRequiredGem
        && creditManager.credits >= buyBoatRequiredCredits)
        {
            resourceInventory.woodAmount -= buyBoatRequiredWood;
            resourceInventory.stoneAmount -= buyBoatRequiredStone;
            resourceInventory.coalAmount -= buyBoatRequiredCoal;
            resourceInventory.ironAmount -= buyBoatRequiredIron;
            resourceInventory.goldAmount -= buyBoatRequiredGold;
            resourceInventory.gemAmount -= buyBoatRequiredGem;
            creditManager.credits -= buyBoatRequiredCredits;

            boatLevel++;
            maxLevel++;

            PlayerPrefs.SetInt("BoatLevel", boatLevel);
            PlayerPrefs.SetInt("MaxBoatLevel", maxLevel);

            if (boatLevel >= 3)
            {
                boatLevelText.text = "MAX";
            }
            else
            {
                boatLevelText.text = "LVL " + boatLevel;
                boatSpeedLevelText.text = "LVL " + boatSpeedLevel;
                waterGunLevelText.text = "LVL " + waterGunLevel;
                boatDurabilityLevelText.text = "LVL " + boatDurabilityLevel;
            }

            buyBoatRequiredWood = RaisedRequirement(buyBoatRequiredWood, buyBoatRequiredWoodText);
            buyBoatRequiredStone = RaisedRequirement(buyBoatRequiredStone, buyBoatRequiredStoneText);
            buyBoatRequiredCoal = RaisedRequirement(buyBoatRequiredCoal, buyBoatRequiredCoalText);
            buyBoatRequiredIron = RaisedRequirement(buyBoatRequiredIron, buyBoatRequiredIronText);
            buyBoatRequiredGold = RaisedRequirement(buyBoatRequiredGold, buyBoatRequiredGoldText);
            buyBoatRequiredGem = RaisedRequirement(buyBoatRequiredGem, buyBoatRequiredGemText);
            buyBoatRequiredCredits = RaisedRequirement(buyBoatRequiredCredits, buyBoatRequiredCreditsText);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    private int RaisedRequirement(int required, TextMeshProUGUI requiredText)
    {
        required = (int)(required * 1.15);
        requiredText.text = "" + required;
        return required;
    }

    public void RefreshRequirementTexts()
    {
        speedRequiredWoodText.text = speedRequiredWood + "";
        speedRequiredCoalText.text = speedRequiredCoal + "";
        speedRequiredGoldText.text = speedRequiredGold + "";
        speedRequiredCreditsText.text = speedRequiredCredits + "";

        gunRequiredWoodText.text = gunRequiredWood + "";
        gunRequiredIronText.text = gunRequiredIron + "";
        gunRequiredGoldText.text = gunRequiredGold + "";
        gunRequiredCreditsText.text = gunRequiredCredits + "";

        durabRequiredWoodText.text = durabRequiredWood + "";
        durabRequiredStoneText.text = durabRequiredStone + "";
        durabRequiredIronText.text = durabRequiredIron + "";
        durabRequiredCreditsText.text = durabRequiredCredits + "";

        buyBoatRequiredWoodText.text = buyBoatRequiredWood + "";
        buyBoatRequiredStoneText.text = buyBoatRequiredStone + "";
        buyBoatRequiredCoalText.text = buyBoatRequiredCoal + "";
        buyBoatRequiredIronText.text = buyBoatRequiredIron + "";
        buyBoatRequiredGoldText.text = buyBoatRequiredGold + "";
        buyBoatRequiredGemText.text = buyBoatRequiredGem + "";
        buyBoatRequiredCreditsText.text = buyBoatRequiredCredits + "";
    }

    // public void SaveRequirements(string prefsName, int requiredResource)
    // {
    //     PlayerPrefs.SetInt(prefsName, requiredResource);
    // }
    public int LoadRequirement(string upgradeLevel, int requiredResource, TextMeshProUGUI levelText)
    {
        int resourceRequired = requiredResource;

        if (PlayerPrefs.GetInt(upgradeLevel) == 2)
        {
            levelText.text = "LVL " + 2;
            resourceRequired = (int)(requiredResource * 1.15);
        }
        else if (PlayerPrefs.GetInt(upgradeLevel) >= 3)
        {
            levelText.text = "MAX";
            resourceRequired = (int)(requiredResource * 1.15 * 1.15);
        }
        else
        {
            levelText.text = "LVL " + 1;
        }
        return resourceRequired;
    }

    public void LoadAllRequirements()
    {
        maxLevel = PlayerPrefs.GetInt("MaxBoatLevel", 2);
        boatSpeedLevel = PlayerPrefs.GetInt("BoatSpeedLevel", 1);
        waterGunLevel = PlayerPrefs.GetInt("WaterGunLevel", 1);
        boatDurabilityLevel = PlayerPrefs.GetInt("BoatDurabilityLevel", 1);
        boatLevel = PlayerPrefs.GetInt("BoatLevel", 1);

        speedRequiredWood = LoadRequirement("BoatSpeedLevel", speedRequiredWood, boatSpeedLevelText);
        speedRequiredCoal = LoadRequirement("BoatSpeedLevel", speedRequiredCoal, boatSpeedLevelText);
        speedRequiredGold = LoadRequirement("BoatSpeedLevel", speedRequiredGold, boatSpeedLevelText);
        speedRequiredCredits = LoadRequirement("BoatSpeedLevel", speedRequiredCredits, boatSpeedLevelText);

        gunRequiredWood = LoadRequirement("WaterGunLevel", gunRequiredWood, waterGunLevelText);
        gunRequiredIron = LoadRequirement("WaterGunLevel", gunRequiredIron, waterGunLevelText);
        gunRequiredGold = LoadRequirement("WaterGunLevel", gunRequiredGold, waterGunLevelText);
        gunRequiredCredits = LoadRequirement("WaterGunLevel", gunRequiredCredits, waterGunLevelText);

        durabRequiredWood = LoadRequirement("BoatDurabilityLevel", durabRequiredWood, boatDurabilityLevelText);
        durabRequiredStone = LoadRequirement("BoatDurabilityLevel", durabRequiredStone, boatDurabilityLevelText);
        durabRequiredIron = LoadRequirement("BoatDurabilityLevel", durabRequiredIron, boatDurabilityLevelText);
        durabRequiredCredits = LoadRequirement("BoatDurabilityLevel", durabRequiredCredits, boatDurabilityLevelText);

        buyBoatRequiredWood = LoadRequirement("BoatLevel", buyBoatRequiredWood, boatLevelText);
        buyBoatRequiredStone = LoadRequirement("BoatLevel", buyBoatRequiredStone, boatLevelText);
        buyBoatRequiredCoal = LoadRequirement("BoatLevel", buyBoatRequiredCoal, boatLevelText);
        buyBoatRequiredIron = LoadRequirement("BoatLevel", buyBoatRequiredIron, boatLevelText);
        buyBoatRequiredGold = LoadRequirement("BoatLevel", buyBoatRequiredGold, boatLevelText);
        buyBoatRequiredGem = LoadRequirement("BoatLevel", buyBoatRequiredGem, boatLevelText);
        buyBoatRequiredCredits = LoadRequirement("BoatLevel", buyBoatRequiredCredits, boatLevelText);

        RefreshRequirementTexts();
    }
}