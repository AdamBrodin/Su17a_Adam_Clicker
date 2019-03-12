using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementList : MonoBehaviour
{
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////// TODO --- NOT WORKING ATM
    /// </summary>
    public Achievement[] achievement;
    public GameObject entry;

    private void Start()
    {
        Vector2 currentPos = transform.position;
        float y = currentPos.y;

        for(int i = 0; i < achievement.Length; i++)
        {
            if(achievement[i].isUnlocked)
            {
                Vector2 newPos = new Vector2(transform.position.x, y += 100);
                GameObject g = Instantiate(entry, new Vector2(transform.position.x, transform.position.y), transform.rotation, transform);
                g.GetComponentInChildren<TextMeshProUGUI>().SetText(achievement[i].popupTitle + ": " + achievement[i].popupDescription);
                g.GetComponent<PopupText>().ySpeed = 0;
                y = newPos.y;
            }
        }
    }
}
