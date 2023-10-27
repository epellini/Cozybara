using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    public MusicTrack[] musicTracks; // Array to hold your music tracks
    public AudioSource musicSource;
    
    private string currentSceneName; // To store the current scene name

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get the initial scene name
        currentSceneName = SceneManager.GetActiveScene().name;
        
        // Play the music for the initial scene
        PlayMusicForScene(currentSceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = scene.name;
        PlayMusicForScene(currentSceneName);
    }

    public void PlayMusicForScene(string sceneName)
    {
        MusicTrack track = FindMusicTrack(sceneName);

        if (track != null)
        {
            musicSource.clip = track.clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogError("Music track not found for scene: " + sceneName);
        }
    }

    private MusicTrack FindMusicTrack(string sceneName)
    {
        return System.Array.Find(musicTracks, x => x.sceneName == sceneName);
    }
}
