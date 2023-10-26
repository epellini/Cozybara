using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load.
    public float delay = 10f; // The delay in seconds before loading the new scene.

    private float timeElapsed = 0f;
    private bool hasLoadedScene = false;

    void Update()
    {
        // Increment the time elapsed.
        timeElapsed += Time.deltaTime;

        // Check if the specified delay has passed and if the scene has not been loaded yet.
        if (timeElapsed >= delay && !hasLoadedScene)
        {
            // Load the specified scene.
            SceneManager.LoadScene(sceneToLoad);
            hasLoadedScene = true; // Ensure the scene is only loaded once.
        }
    }
}
