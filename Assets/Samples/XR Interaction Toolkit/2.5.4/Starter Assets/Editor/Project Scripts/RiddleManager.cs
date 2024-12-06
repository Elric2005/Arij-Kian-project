using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    // UI Elements for displaying the current riddle
    public TextMeshProUGUI riddleText;

    // Array of riddles for both players
    private Riddle[] allRiddles;

    // Assigned riddles for this player
    private Riddle[] assigned_riddles;
    private Riddle current_riddle;

    public GameManager gameManager;
    public int playerId;
    private int currentRiddleIndex = 0;

    [System.Serializable]
    public class Riddle
    {
        public string riddleText;
        public GameObject answerObject;
    }


    private void Start()
    {
        allRiddles = new Riddle[8];

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
                answerObject = GameObject.Find("land_mine")  // Replace with the actual name in your scene
            };
            allRiddles[7] = new Riddle
            {
                riddleText = "Twisting through the ground, I carry things you don’t want to see,\nMarked with warnings, for I bring not water, but waste and danger beneath.",
                answerObject = GameObject.Find("Hazard Pipes")  // Replace with the actual name in your scene
            };

            InitializeRiddles();
        }



    public void InitializeRiddles()
    {
        assigned_riddles = new Riddle[4];

        // Assign the first 4 riddles to Player 1 and the next 4 to Player 2
        if (playerId == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                assigned_riddles[i] = allRiddles[i];
            }
        }
        else if (playerId == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                assigned_riddles[i] = allRiddles[i + 4];
            }
        }

        // Display the first riddle for this player
        DisplayRiddle(assigned_riddles[currentRiddleIndex]);
    }

    // Display the current riddle for the player
    public void DisplayRiddle(Riddle riddle)
    {
        current_riddle = riddle;
        riddleText.text = current_riddle.riddleText;
    }

    // This requires the player to point to the gameobject

    public void CmdCheckAnswer(GameObject pointedObject)
    {
        if (pointedObject == current_riddle.answerObject)
        {
            // Notify GameManager of correct answer
            gameManager.CorrectRiddleAnswered(playerId);

            // Move to the next riddle if available
            if (currentRiddleIndex < assigned_riddles.Length - 1)
            {
                currentRiddleIndex++;
                DisplayRiddle(assigned_riddles[currentRiddleIndex]);
            }
            else
            {
                Debug.Log("All riddles have been completed by Player " + playerId);
            }
        }
        else
        {
            Debug.Log("Nothing discernable has been found");
        }
    }

    public class TextMeshProUGUI
    {
    }
}
