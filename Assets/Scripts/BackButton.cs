using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void GoBack()
    {
        // Load the target scene.
        Debug.Log("Pressed back button");
          SceneManager.LoadScene("Map");
    }
}
