using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSponge : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 lastMousePosition;

    private void Start()
    {
        originalPosition = transform.position;
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
}
