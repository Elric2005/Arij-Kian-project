using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMenu : MonoBehaviour
{
    public GameObject menuGameObject;
    Canvas canvas;
    public GameObject mainCamera;
    public GameObject fountain; // Reference to the fountain GameObject for teleportation
    public Text riddleCounterText; // Reference to the Text UI element to display the riddle progress
    private int riddlesSolved = 0; // Track the number of riddles solved
    private int totalRiddles = 4; // Assuming there are 4 riddles per player
    
    public GameObject indicator; // Player's pointing indicator
    // public RiddleManager riddleManager; // Reference to the RiddleManager to interact with riddles
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = menuGameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        // Are the look direction and the palm pointing in opposite directions?
        if (Vector3.Dot(-transform.right, mainCamera.transform.forward) < -0.7f)
        {
            menuGameObject.transform.rotation = Quaternion.AngleAxis(90.0f, transform.up) * transform.rotation;
            menuGameObject.transform.position = transform.position - 0.1f * transform.right + 0.05f * transform.up;
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }

        // Update the riddle counter display
        riddleCounterText.text = $"{riddlesSolved}/{totalRiddles}";
    }

    // Function to teleport the player to the fountain
    public void TeleportToFountain()
    {
        if (fountain != null)
        {
            transform.position = fountain.transform.position; // Teleport to fountain
            Debug.Log("Teleported to the fountain!");
        }
        else
        {
            Debug.LogWarning("Fountain reference not set.");
        }
    }

    // Function to increment the riddle counter when the player solves a riddle
    // public void SolveRiddle(GameObject selectedObject)
    // {
    //     if (riddleManager.CheckAnswer(selectedObject))  // Check if the object is correct
    //     {
    //         riddlesSolved++;
    //         Debug.Log("Riddle solved! Progress: " + riddlesSolved + "/" + totalRiddles);
    //         FountainController.Instance.AddWater();  // Update fountain water level
    //     }
    //     else
    //     {
    //         Debug.Log("Incorrect answer. Hint may be generated for another player.");
    //     }
    // }

    // // Function to generate a hint for another player if the player fails a riddle
    // public void GenerateHint()
    // {
    //     riddleManager.GenerateHint();  // Trigger hint generation in RiddleManager
    // }
}


