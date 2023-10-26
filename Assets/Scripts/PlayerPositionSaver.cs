using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionSaver : MonoBehaviour
{
     private Vector3 savedPlayerPosition;
    private string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SavePlayerPosition()
    {
     // Save the player's position to a Vector3 variable.
        savedPlayerPosition = GameObject.FindWithTag("Player").transform.position;
    }

    public void LoadPlayerPosition()
    {
        // Load the player's position from the saved Vector3 variable and set it.
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = savedPlayerPosition;
        }
        else
        {
            Debug.LogWarning("Player not found in the scene.");
        }
    }
}