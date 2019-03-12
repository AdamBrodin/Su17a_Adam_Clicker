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

[RequireComponent(typeof(BoxCollider2D))]
public abstract class UpgradeBase : MonoBehaviour
{
    public enum UpgradeType
    {
        ClickUpgrade,
        AutoCookieUpgrade
    }

    public delegate void UpgradeClickedEventHandler(object source, float cost, float multiplier, UpgradeType upgrade);

    public abstract event UpgradeClickedEventHandler UpgradeClicked;

    protected Button button;

    protected GameController gameCon;

    public float upgradeCost, upgradeMultiplier, costMultiplier, costDifficultyMultiplier;

    protected abstract void OnUpgradeCompleted(object source, UpgradeType type);

    protected abstract void OnButton();

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate () { OnButton(); });

        gameCon = FindObjectOfType<GameController>();
        gameCon.UpgradeCompleted += OnUpgradeCompleted;
    }
}
