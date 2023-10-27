using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Button back_btn; // Reference to the back button in the Inspector
    public Button feed_btn; // Reference to the Feed button in the Inspector
    public Button play_btn;
    public Button sleep_btn;
    public Button clean_btn;

    public string targetSceneName = "Map";

    // METHOD THAT HIDES AND SHOWS UI OBJECTS
    public void ToggleUIElementsForScene(string sceneName)
    {
        Debug.Log("Toggling UI elements for scene: " + sceneName);


        // MAP SCENE
        if (sceneName == "Map")
        {
            Debug.Log("Switching to Map scene");

            if (back_btn != null)
            {
                back_btn.gameObject.SetActive(false);
            }

            if (feed_btn != null)
            {
                feed_btn.gameObject.SetActive(false);
            }

            if (play_btn != null)
            {
                play_btn.gameObject.SetActive(false);
            }

            if (sleep_btn != null)
            {
                sleep_btn.gameObject.SetActive(false);
            }

            if (clean_btn != null)
            {
                clean_btn.gameObject.SetActive(false);
            }

        }
        // HOME SCENE
        if (sceneName == "Home")
        {
            Debug.Log("Switching to Home scene");

            if (back_btn != null)
            {
                back_btn.gameObject.SetActive(true);
            }

            if (feed_btn != null)
            {
                feed_btn.gameObject.SetActive(true);
            }

            if (play_btn != null)
            {
                play_btn.gameObject.SetActive(false);
            }

            if (sleep_btn != null)
            {
                sleep_btn.gameObject.SetActive(true);
            }

            if (clean_btn != null)
            {
                clean_btn.gameObject.SetActive(false);
            }

        }
        // HOT SPRING SCENE
        if (sceneName == "HotSpring")
        {
            Debug.Log("Switching to Hotspring scene");

            if (back_btn != null)
            {
                back_btn.gameObject.SetActive(true);
            }

            if (feed_btn != null)
            {
                feed_btn.gameObject.SetActive(false);
            }

            if (play_btn != null)
            {
                play_btn.gameObject.SetActive(false);
            }

            if (sleep_btn != null)
            {
                sleep_btn.gameObject.SetActive(false);
            }

            if (clean_btn != null)
            {
                clean_btn.gameObject.SetActive(false);
            }

        }

          // Minigame Menu
        if (sceneName == "MiniGameMenu")
        {
            Debug.Log("Switching to MiniGameMenu scene");

            if (back_btn != null)
            {
                back_btn.gameObject.SetActive(true);
            }

            if (feed_btn != null)
            {
                feed_btn.gameObject.SetActive(false);
            }

            if (play_btn != null)
            {
                play_btn.gameObject.SetActive(false);
            }

            if (sleep_btn != null)
            {
                sleep_btn.gameObject.SetActive(false);
            }

            if (clean_btn != null)
            {
                clean_btn.gameObject.SetActive(false);
            }
        }

         // Minigame Menu
        if (sceneName == "Whack")
        {
            Debug.Log("Switching to Whack scene");

            if (back_btn != null)
            {
                back_btn.gameObject.SetActive(true);
            }

            if (feed_btn != null)
            {
                feed_btn.gameObject.SetActive(false);
            }

            if (play_btn != null)
            {
                play_btn.gameObject.SetActive(false);
            }

            if (sleep_btn != null)
            {
                sleep_btn.gameObject.SetActive(false);
            }

            if (clean_btn != null)
            {
                clean_btn.gameObject.SetActive(false);
            }
        }

    }

    // Singleton instance
    private static HealthBar instance;

    public const float MaxValue = 100f; // Maxvalue of the % in the bars

    // UI Elements
    public Image[] needBars;        // Assign UI images for hunger, fun, energy, dirtyness in the Inspector
    public Image[] needIcons;       // Assign UI images for icons associated with each need in the Inspector
    public Image cappyHappyImage;   // Assign UI image for Cappy's happy state in the Inspector
    public Image cappySadImage;     // Assign UI image for Cappy's sad state in the Inspector
    public Text gameOverText;       // Assign UI Text component for game over text in the Inspector

    // Need Variables
    private float[] needs = new float[4]; // Index 0: hunger, 1: fun, 2: energy, 3: dirtyness

    private void Start()
    {
        InitializeUI();
        UpdateUI();
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

    public static HealthBar Instance
    {
        get { return instance; }
    }

    private void Update()
    {
        UpdateNeeds();
        CheckNeeds();
        UpdateUI();
    }


    private void InitializeUI()
    {
        // Initialize the initial values of needs
        for (int i = 0; i < needs.Length; i++)
        {
            needs[i] = MaxValue; // Set all needs to their maximum value (100%) initially
        }

        // Hide all need icons initially (These icons will act like alerts to let player know Cappy is hungry, etc.)
        for (int i = 0; i < needIcons.Length; i++)
        {
            needIcons[i].CrossFadeAlpha(0, 0.001f, true);
        }

        // Make Cappy happy from the start
        cappySadImage.gameObject.SetActive(false);

    }

    // Here we set how long it takes Cappy to be hungry, bored, etc.
    // The lower the number, the longer it takes for Cappy to be hungry, bored, etc
    public float[] decreaseRates = new float[] { 0.0f, 0.0f, 0.0f, 0.0f }; // Adjust these rates as needed. (Order: Hunger, Bored, Energy, Cleanliness)

    private void UpdateNeeds()
    {
        for (int i = 0; i < needs.Length; i++)
        {
            needs[i] -= decreaseRates[i] * Time.deltaTime;
            if (needs[i] < 0)
            {
                needs[i] = 0;
            }
        }
    }

    private void CheckNeeds()
    {
        // Check each need and update UI accordingly
        for (int i = 0; i < needs.Length; i++)
        {
            if (needs[i] <= 50)
            {
                // Show the need icon (e.g., make it visible)
                needIcons[i].CrossFadeAlpha(1, 0.05f, true);
            }
            else
            {
                // Hide the need icon (e.g., make it invisible)
                needIcons[i].CrossFadeAlpha(0, 0.05f, true);
            }
        }

        // Check if Cappy is happy or sad based on specific conditions
        if (needs[0] <= 60 || needs[1] <= 30 || needs[2] <= 20 || needs[3] <= 40)
        {
            // Cappy is sad
            cappyHappyImage.gameObject.SetActive(false);
            cappySadImage.gameObject.SetActive(true);
        }
        else
        {
            // Cappy is happy
            cappySadImage.gameObject.SetActive(false);
            cappyHappyImage.gameObject.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < needBars.Length; i++)
        {
            float ratio = needs[i] / MaxValue;
            needBars[i].rectTransform.localScale = new Vector3(ratio, 1, 1);

            // Define color thresholds
            float greenToOrangeThreshold = 0.7f; // Transition from green to orange below 70%
            float orangeToRedThreshold = 0.3f;   // Transition from orange to red below 30%

            Color originalColor = Color.green; // Green
            Color orangeColor = Color.yellow;  // Orange
            Color redColor = Color.red;        // Red

            Color barColor;

            if (ratio <= orangeToRedThreshold)
            {
                // Transition from green to orange
                barColor = Color.Lerp(originalColor, orangeColor, (ratio / orangeToRedThreshold));
            }
            else if (ratio <= greenToOrangeThreshold)
            {
                // Transition from orange to red
                barColor = Color.Lerp(orangeColor, redColor, (ratio - orangeToRedThreshold) / (greenToOrangeThreshold - orangeToRedThreshold));
            }
            else
            {
                // Remain in green
                barColor = originalColor;
            }

            // Invert the colors for the health bar
            needBars[i].color = Color.Lerp(redColor, originalColor, ratio);
        }
    }


    public void PerformAction(int actionIndex)
    {
        switch (actionIndex)
        {
            case 0: // Feed action
                needs[0] += 15; // Increase hunger
                break;

            case 1: // Play action
                needs[1] += 100; // Increase fun
                break;

            case 2: // Sleep action
                needs[2] += 100; // Increase energy
                break;

            case 3: // Clean action
                needs[3] += 8; // Decrease dirtyness
                break;

            // Add more cases for additional actions as needed

            default:
                // Handle unknown action or no action
                break;
        }

        // Ensure the needs values stay within the valid range
        for (int i = 0; i < needs.Length; i++)
        {
            if (needs[i] > MaxValue)
            {
                needs[i] = MaxValue;
            }
        }
        
    }


}
