using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * 
 * Created by Adam Brodin
 * https://www.github.com/AdamBrodin
 * 
 */

public class AchievementSystem : MonoBehaviour
{
    #region Variables
    private Cookie cookie;
    private GameController gameCon;
    private int totalClickAmount, totalUpgradesPurchased; // Total amount of clicks on the cookie (manually)
    public GameObject popupBox;
    public Achievement[] achievements;
    #endregion

    private void Awake()
    {
        cookie = FindObjectOfType<Cookie>(); // Finds the gameObject which uses the cookie class
        gameCon = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        cookie.CookieClicked += OnCookieClicked; // When the cookie is clicked on

        gameCon.UpgradeCompleted += OnUpgradeCompleted;
    }

    private void OnCookieClicked(object source, EventArgs args) // When the cookie is clicked on
    {
        totalClickAmount++;

        CheckForUnlock();
    }

    private void OnUpgradeCompleted(object source, UpgradeBase.UpgradeType upgradeType)
    {
        totalUpgradesPurchased++;

        CheckForUnlock();
    }


    private void CheckForUnlock() // Checks the game, every x seconds for a new achievement that has been unlocked
    {
        for(int i = 0; i < achievements.Length; i++) // Repeat for every achievement in the array ( < instead of <= because arrays starts at 0)
        {
            switch(achievements[i].achievementType)
            {
                case Achievement.achievementTypes.ClickAchievement:
                    if(totalClickAmount >= achievements[i].valueToUnlock && achievements[i].isUnlocked == false) // If the requirements for the achievement is reached and it hasn't been unlocked before
                    {
                        unlockAchievement(achievements[i]); // Unlock the achievement
                    }
                    break;
                case Achievement.achievementTypes.UpgradeAchievement:
                    if(totalUpgradesPurchased >= achievements[i].valueToUnlock && achievements[i].isUnlocked == false)
                    {
                        unlockAchievement(achievements[i]); // Unlock the achievement
                    }
                    break;
                default:
                    print("Error occurred: " + this);
                    break;
            }
        }
    }

    private void unlockAchievement(Achievement achievement)
    {
        print("Achievement Unlocked: " + achievement.popupTitle);
        achievement.isUnlocked = true; // Set it to unlock to prevent the same achievement unlocking multiple times
        GameObject g = Instantiate(popupBox, GameObject.Find("Canvas").transform); // Create a new popup on the screen
        g.GetComponent<PopupText>().ySpeed *= 0.5f; // Slower speed so you can see the achievement clearly
        g.GetComponentInChildren<TextMeshProUGUI>().SetText(achievement.popupTitle + ": " + achievement.popupDescription); // Change the text of the object
    }

}
