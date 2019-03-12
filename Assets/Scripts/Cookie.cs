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

[RequireComponent(typeof(Animation))]
public class Cookie : MonoBehaviour
{
    #region Variables
    public delegate void CookieClickedEventHandler(object source, EventArgs args);
    public event CookieClickedEventHandler CookieClicked;
    //private Animation anim; TODO
    private Button button;
    #endregion

    private void Awake()
    {
        //anim = GetComponent<Animation>(); TODO
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate () { OnButton(); }); // Add a listener for the button clicks
    }

    void OnButton() // When the cookie is clicked on
    {
        OnCookieClicked();
    }

    protected virtual void OnCookieClicked()
    {
        CookieClicked?.Invoke(this, EventArgs.Empty); // Invoke event if any listeners are found

        //anim.Play(); // Play the onCookieClick animation TODO
    }
}
