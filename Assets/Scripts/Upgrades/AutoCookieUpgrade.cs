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

public class AutoCookieUpgrade : UpgradeBase
{
    public override event UpgradeClickedEventHandler UpgradeClicked;

    private void Start()
    {
        upgradeCost = 10; // Default cost
        upgradeMultiplier = 1.3f; // Default improvement per upgrade
        costMultiplier = 1.5f; // Default cost multiplier per upgrade (50% more expensive each time)
        costDifficultyMultiplier = 1.05f; // 5% more costMultiplier per upgrade
    }

    protected override void OnUpgradeCompleted(object source, UpgradeType type)
    {
        if(type == UpgradeType.AutoCookieUpgrade)
        {
            upgradeCost *= costMultiplier;
            costMultiplier *= costDifficultyMultiplier;
            button.GetComponentInChildren<Text>().text = "Upgrade: $" + (int)upgradeCost;
            print(this.name + " Upgrade Cost: " + upgradeCost + " Upgrade Multiplier: " + upgradeMultiplier + " Cost Multiplier: " + costMultiplier + " Cost Difficulty Multiplier: " + costDifficultyMultiplier);
        }
    }

    protected override void OnButton()
    {
        UpgradeClicked?.Invoke(this, upgradeCost, upgradeMultiplier, UpgradeType.AutoCookieUpgrade);
    }
}
