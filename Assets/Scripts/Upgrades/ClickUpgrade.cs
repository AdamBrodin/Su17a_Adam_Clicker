using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 
 * Created by Adam Brodin
 * https://www.github.com/AdamBrodin
 * 
 */

public class ClickUpgrade : UpgradeBase
{
    #region Variables
    public override event UpgradeClickedEventHandler UpgradeClicked;
    #endregion

    private void Start()
    {
        // Default values
        upgradeCost = 10; // Cost of upgrade
        upgradeMultiplier = 1.4f; // 40% improvement each upgrade
        costMultiplier = 1.45f; // 45% more expensive each upgrade
        costDifficultyMultiplier = 1.02f; // 2% more costMultiplier per upgrade
    }

    protected override void OnUpgradeCompleted(object source, UpgradeType type)
    {
        if(type == UpgradeType.ClickUpgrade)
        {
            upgradeCost *= costMultiplier;
            costMultiplier *= costDifficultyMultiplier;
            button.GetComponentInChildren<Text>().text = "Upgrade: $" + (int)upgradeCost;
            print(this.name + " Upgrade Cost: " + upgradeCost + " Upgrade Multiplier: " + upgradeMultiplier + " Cost Multiplier: " + costMultiplier + " Cost Difficulty Multiplier: " + costDifficultyMultiplier);
        }
    }

    protected override void OnButton() // When the button is clicked on
    {
        UpgradeClicked?.Invoke(this, upgradeCost, upgradeMultiplier, UpgradeType.ClickUpgrade); // If event != null, continue
    }



}
