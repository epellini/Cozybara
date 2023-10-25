using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject[] objectsToHideInMenu;
    public GameObject[] objectsToHideInMap;
    public GameObject[] objectsToHideInHome;
    public GameObject[] objectsToHideInHotspring;
    public GameObject[] objectsToHideInMinigameMenu;
    public GameObject[] objectsToHideInMinigame1;
    public GameObject[] objectsToHideInMinigame2;

    private void Start()
    {
        // Register a callback for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
          DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene: " + scene.name);

        // Check the name of the loaded scene and hide objects accordingly
        switch (scene.name)
        {
            case "Menu":
                HideObjects(objectsToHideInMenu);
                break;
            case "Map":
                HideObjects(objectsToHideInMap);
                break;
            case "Home":
                HideObjects(objectsToHideInHome);
                break;
            case "Hotspring":
                HideObjects(objectsToHideInHotspring);
                break;
            case "MinigameMenu":
                HideObjects(objectsToHideInMinigameMenu);
                break;
            case "Minigame1":
                HideObjects(objectsToHideInMinigame1);
                break;
            case "Minigame2":
                HideObjects(objectsToHideInMinigame2);
                break;
            default:
                Debug.Log("No objects to hide for this scene: " + scene.name);
                break;
        }
    }

    private void HideObjects(GameObject[] objectsToHide)
    {
        // Hide the specified game objects
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }
}
