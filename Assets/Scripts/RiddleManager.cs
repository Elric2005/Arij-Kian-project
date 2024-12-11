using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityEngine.UI;  // Import Unity Netcode for multiplayer functionality

public class RiddleManager : MonoBehaviour
{
    // Reference to the RiddleText GameObject (which holds the TMP_Text component)
    public GameObject RiddleTextObject;  // Ensure this is correctly assigned in Unity Inspector

   
    [SerializeField] private TextMeshProUGUI riddleText; //have to serialize to show up in inspector

   

    // Array of riddles for both players
    private Riddle[] allRiddles;

    // Assigned riddles for this player
    private Riddle[] assigned_riddles;

    // Current riddle for this player
    private Riddle current_riddle;

    // Player ID, assigned dynamically based on host vs client
    public int playerId;
    private int currentRiddleIndex = 0;

    [System.Serializable]
    public class Riddle
    {
        public string riddleText;
        public GameObject answerObject;  // The object that is the correct answer for this riddle
    }

    private void Start()
    {
        // Determine playerId (Host gets 1, Client gets 2)
        if (NetworkManager.Singleton.IsServer)  // If this is the host (server)
        {
            playerId = 1;  // Host is Player 1
        }
        else if (NetworkManager.Singleton.IsClient)  // If this is a client (non-host player)
        {
            playerId = 2;  // Client is Player 2
        }

        // Get the TMP_Text component from the RiddleTextObject (assigned in the Inspector)
         riddleText = RiddleTextObject.GetComponent<TextMeshProUGUI>();

        // Initialize the riddles
        InitializeRiddles();
    }

    // Initialize riddles based on playerId (host vs client)
    public void InitializeRiddles()
    {
        assigned_riddles = new Riddle[4];  // 4 riddles per player
        allRiddles = new Riddle[8];  // 8 total riddles in the game

        // Define riddles for Player 1 (host) and Player 2 (client)
        if (playerId == 1)
        {
            // Assign riddles 0-3 to the host (Player 1)
            for (int i = 0; i < 4; i++)
            {
                assigned_riddles[i] = allRiddles[i];
            }
        }
        else if (playerId == 2)
        {
            // Assign riddles 4-7 to the client (Player 2)
            for (int i = 0; i < 4; i++)
            {
                assigned_riddles[i] = allRiddles[i + 4];
            }
        }

        // Display the first riddle for the player
        DisplayRiddle(assigned_riddles[currentRiddleIndex]);
    }

    // Display the current riddle for the player
    public void DisplayRiddle(Riddle riddle)
    {
        current_riddle = riddle;
        riddleText.text = riddle.riddleText;  // Update the TMP_Text component with the riddle text
    }

    // Check if the player's answer is correct
    public void CmdCheckAnswer(GameObject pointedObject)
    {
        if (pointedObject == current_riddle.answerObject)
        {
            // Notify the GameManager that the player answered correctly
            GameManager.Instance.CorrectRiddleAnsweredRpc(playerId);  // Use the Singleton Instance of GameManager

            // Move to the next riddle if available
            if (currentRiddleIndex < assigned_riddles.Length - 1)
            {
                currentRiddleIndex++;
                DisplayRiddle(assigned_riddles[currentRiddleIndex]);
            }
            else
            {
                Debug.Log("All riddles completed for Player " + playerId);
            }
        }
        else
        {
            Debug.Log("Incorrect answer");
        }
    }

    // Fill out the riddles with their respective text and answer objects
    private void Awake()
    {
        // Initialize the riddles array with the text and corresponding answer objects
        allRiddles[0] = new Riddle
        {
            riddleText = "I carry the mark of danger, and my contents can bring decay,\nSealed tight to keep poison at bay, in my metal casing I lay.",
            answerObject = GameObject.Find("biohazard barrel")
        };
        allRiddles[1] = new Riddle
        {
            riddleText = "Once I stood tall, but now I am scattered across the ground,\nCrumpled remains of what used to be, all that's left after a structure came down.",
            answerObject = GameObject.Find("rubble")
        };
        allRiddles[2] = new Riddle
        {
            riddleText = "Left out in the rain, my skin is now rough and orange-red,\nI hold nothing but memories of better days, slowly wasting away instead.",
            answerObject = GameObject.Find("rusty_barrel")
        };
        allRiddles[3] = new Riddle
        {
            riddleText = "Once I reached for the sky, now I rest upon the forest floor,\nA bridge for insects and a seat for wanderers, my growing days are no more.",
            answerObject = GameObject.Find("tree_trunk")
        };
        allRiddles[4] = new Riddle
        {
            riddleText = "Empty casings that once held power, now left behind after the thunder,\nSilent and cold, I am the remains of what tore the world asunder.",
            answerObject = GameObject.Find("missile_shells")
        };
        allRiddles[5] = new Riddle
        {
            riddleText = "My branches reach out in twisted silence, but my leaves are long gone,\nStanding brittle and lifeless, a ghost of the vibrant life I once shone.",
            answerObject = GameObject.Find("dead_tree")
        };
        allRiddles[6] = new Riddle
        {
            riddleText = "Buried beneath the earth, I lie in wait with a deadly surprise,\nStep too close, and I’ll turn peace into chaos before your eyes.",
            answerObject = GameObject.Find("land_mine")
        };
        allRiddles[7] = new Riddle
        {
            riddleText = "Twisting through the ground, I carry things you don’t want to see,\nMarked with warnings, for I bring not water, but waste and danger beneath.",
            answerObject = GameObject.Find("Hazard Pipes")
        };
    }
}
