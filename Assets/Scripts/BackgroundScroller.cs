using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Created by Adam Brodin
 * https://www.github.com/AdamBrodin
 * 
 */

[RequireComponent(typeof(Renderer))] // Requires a renderer to work
public class BackgroundScroller : MonoBehaviour
{
    #region Variables
    public float scrollSpeed = 5f; // The speed of which the background moves
    private Renderer sr;
    private Vector2 newPosition;
    #endregion
    void Start()
    {
        sr = GetComponent<Renderer>(); // Get the renderer from the gameObject
    }

    void Update()
    {
        newPosition = new Vector2(Time.time * scrollSpeed, 0); // Creates a new position for the background

        sr.material.mainTextureOffset = newPosition; // Moves the background
    }
}
