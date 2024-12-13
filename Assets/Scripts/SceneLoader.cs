using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    // Scene names
    public string menuScene = "Main Menu";
    public string abandonedCityScene = "Abandoned City";
    public string lushForestScene = "Lush Forest";
    public string endingScene = "Ending";

    
    private bool isHost = false; //setting here for role selecting later

   
    public PointerSelection hostPointerSelection;
    public PointerSelection clientPointerSelection;

    
    public RiddleManager hostRiddleManager;
    public RiddleManager clientRiddleManager;

   
    public GameObject fountainObject;

    void Awake()
    {
        // Making suer only one instance of SceneLoader exists
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
    public void LoadMenuScene() //loads initially and also used when restart button is raycasted at and pressed
    {
        
        SceneManager.LoadScene(menuScene);
    }

    // Method to load the Abandoned City scene for both host and client immediately after they select roles
    public void LoadAbandonedCityScene()
    {
        if (isHost)
        {
            // If host is selected, start the host and load the Abandoned City scene
            NetworkManager.Singleton.StartHost();
           
        }
        else
        {
            // If client is selected, start the client and load the Abandoned City scene
            NetworkManager.Singleton.StartClient();
            
        }

       
        SceneManager.LoadScene(abandonedCityScene);
    }

    // Method to load the Lush Forest scene only if both players have answered their riddles
    public void LoadLushForestScene()
    {
        if (hostRiddleManager.GetCompletedRiddlesForPlayer(1) == 4 && clientRiddleManager.GetCompletedRiddlesForPlayer(2) == 4)
        {
            SceneManager.LoadScene(lushForestScene);
        }
    
    }

    // Method to load the Ending scene only if both players have pointed at the fountain
    public void LoadEndingScene()
    {
        if (hostPointerSelection.HasPointedAtObject(fountainObject) && clientPointerSelection.HasPointedAtObject(fountainObject))
        {
            SceneManager.LoadScene(endingScene);
        }
    
    }


   
}
