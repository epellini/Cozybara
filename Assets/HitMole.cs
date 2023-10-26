using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMole : MonoBehaviour
{
    private ScoreManager scoreManager; // Reference to the ScoreManager script

    private void Start()
    {
        // Find the ScoreManager script in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager script not found in the scene.");
        }
    }

    private void OnMouseDown()
    {
        if (scoreManager != null)
        {
            // Increase the score via the ScoreManager instance
            scoreManager.IncreaseScore(1); // Increase the score by 1 (or your desired value)

            // Play a hit animation or sound
            PlayHitAnimation();

            // Deactivate the mole
            DeactivateMole();
        }
    }

    void PlayHitAnimation()
    {
        // Implement your hit animation or sound logic here
    }

    void DeactivateMole()
    {
        // Deactivate the mole
        gameObject.SetActive(false);
    }
}
