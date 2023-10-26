using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string targetSceneName;

    public void GoBack()
    {
         // Save the player's position in the current scene.
        FindObjectOfType<PlayerPositionSaver>().SavePlayerPosition();
        
        // Load the target scene.
        SceneManager.LoadScene(targetSceneName);
    }
}
