using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    // Scene names
    public string menuScene = "Menu";
    public string abandonedCityScene = "AbandonedCity";
    public string lushForestScene = "LushForest";
    public string endingScene = "Ending";

    // Player Role (host or client)
    private bool isHost = false;

    // References to PointerSelection scripts
    public PointerSelection hostPointerSelection;
    public PointerSelection clientPointerSelection;

    // RiddleManager references for checking riddles completion
    public RiddleManager hostRiddleManager;
    public RiddleManager clientRiddleManager;

    // Fountain game object reference
    public GameObject fountainObject;

    void Awake()
    {
        // Ensure only one instance of SceneLoader exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to load the Menu scene
    public void LoadMenuScene()
    {
        Debug.Log("Loading Menu Scene...");
        SceneManager.LoadScene(menuScene);
    }

    // Method to load the Abandoned City scene for both host and client immediately after they select roles
    public void LoadAbandonedCityScene()
    {
        if (isHost)
        {
            // If host is selected, start the host and load the Abandoned City scene
            NetworkManager.Singleton.StartHost();
            Debug.Log("Host selected. Loading Abandoned City Scene...");
        }
        else
        {
            // If client is selected, start the client and load the Abandoned City scene
            NetworkManager.Singleton.StartClient();
            Debug.Log("Client selected. Loading Abandoned City Scene...");
        }

        // Proceed to load the scene
        SceneManager.LoadScene(abandonedCityScene);
    }

    // Method to load the Lush Forest scene only if both players have answered their riddles
    public void LoadLushForestScene()
    {
        if (hostRiddleManager.GetCompletedRiddlesForPlayer(1) == 4 && clientRiddleManager.GetCompletedRiddlesForPlayer(2) == 4)
        {
            SceneManager.LoadScene(lushForestScene);
        }
        else
        {
            Debug.Log("Not all riddles answered yet.");
        }
    }

    // Method to load the Ending scene only if both players have pointed at the fountain
    public void LoadEndingScene()
    {
        if (hostPointerSelection.HasPointedAtObject(fountainObject) && clientPointerSelection.HasPointedAtObject(fountainObject))
        {
            SceneManager.LoadScene(endingScene);
        }
        else
        {
            Debug.Log("Both players have not pointed at the fountain yet.");
        }
    }

   
}
