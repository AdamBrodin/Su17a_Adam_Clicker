using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Created by Adam Brodin
 * https://www.github.com/AdamBrodin
 * 
 */

[RequireComponent(typeof(Renderer))] // A renderer is required for OnBecameInvisible to work
public class PopupText : MonoBehaviour
{
    public float ySpeed; // Speed of the text movement

    private void Update()
    {
        float x = transform.position.y;
        transform.position = new Vector2(transform.position.x, x += ySpeed); // Move the text upwards at ySpeed
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy self if outside of rendered area (scene or game)
        print("Destroyed: " + gameObject.name);
    }
}
