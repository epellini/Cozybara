using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSponge : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 lastMousePosition;

     private HealthBar healthBar;


    private void Start()
    {
        originalPosition = transform.position;
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void OnMouseDown()
    {
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = newMousePosition - lastMousePosition;
        transform.position += offset;
        lastMousePosition = newMousePosition;
    }

    private void OnMouseUp()
    {
        // Reset the object's position to the original position
        transform.position = originalPosition;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("he");

            if (healthBar != null)
            {
                healthBar.PerformAction(3); // Trigger the cleaning action
            }
        }
    }

}
