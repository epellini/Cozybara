using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileGenerator : MonoBehaviour
{
    public GameObject crocodile;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateCrocodile();
    }

    public void generateCrocodile()
    {
        GameObject CrocodileIns = Instantiate(crocodile, transform.position, transform.rotation);

        CrocodileIns.GetComponent<crocodileScript>().crocodileGenerator = this;
    }

    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }

}
