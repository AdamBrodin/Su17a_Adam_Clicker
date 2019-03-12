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

public class GameController : MonoBehaviour
{
    #region Variables
    private AutoCookieUpgrade autoCookieUpgrade;
    public delegate void UpgradeCompletedEventHandler(object source, UpgradeBase.UpgradeType upgradeType);
    public event UpgradeCompletedEventHandler UpgradeCompleted;
    public TextMeshProUGUI amountOfCookiesText, cookiesPerSecText;
    public GameObject popupBox;
    private Cookie cookie;
    private ClickUpgrade clickUpgrade;
    private bool textOnCooldown; // Bool to check if another text can appear to avoid spam
    public float _amountOfCookies, cookiesPerClick = 1f, cookiesPerSec = 0.5f, infoDelay = 2f; // Default values
    public float amountOfCookies // Seperate variable to make the UI text update automatically as seen beloww
    {
        get
        {
            return _amountOfCookies;
        }

        set
        {
            _amountOfCookies = value;

            int i = (int)_amountOfCookies; // Make the float round to nearest integer instead of float for better apperance

            amountOfCookiesText.text = i.ToString() + " cookies"; // Set the text to _amountOfCookies
        }
    }
    #endregion
    private void Awake()
    {
        cookie = FindObjectOfType<Cookie>(); // Finds the GameObject which uses the cookie class
        clickUpgrade = FindObjectOfType<ClickUpgrade>(); // Finds the GameObject which uses the clickUpgrade class
        autoCookieUpgrade = FindObjectOfType<AutoCookieUpgrade>();
    }

    private void Start()
    {
        StartCoroutine(BackgroundCookies());
        cookie.CookieClicked += OnCookieClicked;
        clickUpgrade.UpgradeClicked += OnUpgradeClicked;
        autoCookieUpgrade.UpgradeClicked += OnUpgradeClicked;
    }

    private void OnUpgradeClicked(object source, float cost, float multiplier, UpgradeBase.UpgradeType upgradeType)
    {
        if(amountOfCookies >= cost)
        {
            switch(upgradeType)
            {
                case UpgradeBase.UpgradeType.ClickUpgrade:
                    cookiesPerClick *= multiplier;
                    break;
                case UpgradeBase.UpgradeType.AutoCookieUpgrade:
                    cookiesPerSec *= multiplier;
                    cookiesPerSecText.text = cookiesPerSec.ToString() + "/sec";
                    break;
            }

            amountOfCookies -= cost;
            UpgradeCompleted.Invoke(this, upgradeType);
        }
        else if(amountOfCookies < cost) // If the upgrade cannot be afforded
        {
            if(!textOnCooldown) { StartCoroutine(ShowInfoText("Insufficient Funds")); }
            Debug.Log("Insufficient Funds");
        }
    }

    private void OnCookieClicked(object source, EventArgs args)
    {
        amountOfCookies += cookiesPerClick;
    }

    private IEnumerator BackgroundCookies() // Automatically gather cookies in the background
    {
        yield return new WaitForSeconds(1f);
        amountOfCookies += cookiesPerSec;
        StartCoroutine(BackgroundCookies());
    }

    private IEnumerator ShowInfoText(string information)
    {
        textOnCooldown = true;

        GameObject g = Instantiate(popupBox, GameObject.Find("Canvas").transform);

        g.GetComponentInChildren<TextMeshProUGUI>().SetText(information); // Change the text of the object

        yield return new WaitForSeconds(infoDelay);

        textOnCooldown = false;
    }
}
