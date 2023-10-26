using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script

     // Singleton instance
    private static UIManager instance;

    private void Start()
    {
        // Get a reference to the HealthBar script
        healthBar = FindObjectOfType<HealthBar>();

        DontDestroyOnLoad(gameObject);
        
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        // Check for scene changes and update UI elements accordingly
        if (SceneManager.GetActiveScene().name != healthBar.targetSceneName)
        {
            // Update the target scene in HealthBar
            healthBar.targetSceneName = SceneManager.GetActiveScene().name;

            // Toggle UI elements based on the new scene
            healthBar.ToggleUIElementsForScene(healthBar.targetSceneName);
        }
    }
}
