using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void GoToHelpScene()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void GoToStackGame()
    {
        SceneManager.LoadSceneAsync(9);
    }
}
