using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    private bool isActive = false;
    private float timeVisible = 2.0f; // Time the mole stays visible
    private float timeHidden = 1.0f; // Time the mole stays hidden

    private void Start()
    {
        DeactivateMole();
        StartCoroutine(MoleBehavior());
    }

    IEnumerator MoleBehavior()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeHidden);
            ActivateMole();
            yield return new WaitForSeconds(timeVisible);
            DeactivateMole();
        }
    }

    void ActivateMole()
    {
        isActive = true;
        // Implement mole pop-up visuals (e.g., animation)
    }

    public void DeactivateMole()
    {
        isActive = false;
        // Implement mole hide visuals (e.g., animation)
    }

    public bool IsMoleActive()
    {
        return isActive;
    }
}
