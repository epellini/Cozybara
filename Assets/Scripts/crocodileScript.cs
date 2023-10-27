using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crocodileScript : MonoBehaviour
{

    public CrocodileGenerator crocodileGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * crocodileGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextEnemy"))
        {
            crocodileGenerator.generateCrocodile();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }

    }
}
