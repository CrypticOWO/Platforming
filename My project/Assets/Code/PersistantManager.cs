using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantManager : MonoBehaviour
{
    private static bool created = false;

    void Awake()
    {
        // Check if an instance of the PersistantManager already exists
        if (!created)
        {
            // This ensures that the GameObject this script is attached to persists through scenes.
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            // An extra instance was created, destroy it
            Destroy(this.gameObject);
        }

        // Optionally, handle different types of objects
        HandleUI();
        HandlePlayer();
        HandleMainCamera();
    }

    // Example methods to handle different types of objects
    void HandleUI()
    {
        GameObject uiObject = GameObject.Find("UI");
        if (uiObject != null)
        {
            DontDestroyOnLoad(uiObject);
        }
    }

    void HandlePlayer()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            DontDestroyOnLoad(playerObject);
        }
    }

    void HandleMainCamera()
    {
        GameObject cameraObject = GameObject.Find("MainCamera");
        if (cameraObject != null)
        {
            DontDestroyOnLoad(cameraObject);
        }
    }

    // Use this method to load a new scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}