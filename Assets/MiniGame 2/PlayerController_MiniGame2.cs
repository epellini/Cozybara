using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_MiniGame2 : MonoBehaviour
{
    public bool jump;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            jump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jump) // Use '!' to check if 'jump' is false.
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f); // Use 'new Vector2'.
            jump = true;
        }
    }
}
