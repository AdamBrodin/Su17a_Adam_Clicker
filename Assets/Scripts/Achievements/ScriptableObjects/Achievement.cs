using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Created by Adam Brodin
 * https://www.github.com/AdamBrodin
 * 
 */

[CreateAssetMenu(fileName = "Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public enum achievementTypes { ClickAchievement, UpgradeAchievement };
    public string popupTitle, popupDescription;
    public bool isUnlocked;
    public int valueToUnlock;
    public achievementTypes achievementType;
}
