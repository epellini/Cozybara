using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string sceneToLoad;
    public Tilemap tilemap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             Debug.Log("Player entered the trigger zone.");
            Vector3Int playerCell = tilemap.WorldToCell(other.transform.position);

            if (tilemap.GetTile(playerCell) != null)
            {
                Debug.Log("Player collided with a door tile.");
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not set for this door.");
        }
    }
}
