using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0; // Make this non-static

    private void Start()
    {
        score = 0;
        UpdateUI();
    }

    public void IncreaseScore(int value) // Make this non-static
    {
        score += value;
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update the score text on the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
