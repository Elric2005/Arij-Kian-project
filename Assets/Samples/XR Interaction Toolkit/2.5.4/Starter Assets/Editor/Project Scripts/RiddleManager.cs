using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    public List<Riddle> riddles;
    public TextMesh player1RiddleTextUI;
    public TextMesh player2RiddleTextUI;
    public TextMesh player1HintTextUI;
    public TextMesh player2HintTextUI;

    private Dictionary<int, int> currentRiddleIndex = new Dictionary<int, int>();
    private Dictionary<int, int> attemptCount = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        currentRiddleIndex[1] = 0;
        currentRiddleIndex[2] = 0;
        attemptCount[1] = 0;
        attemptCount[2] = 0;

        ShowRiddle(1);
        ShowRiddle(2);
        
    }
      public void ShowRiddle(int playerID)
    {
        if (currentRiddleIndex[playerID] < riddles.Count)
        {
            if (playerID == 1)
            {
                player1RiddleTextUI.text = riddles[currentRiddleIndex[playerID]].riddleText;
                player1HintTextUI.text = "";
            }
            else if (playerID == 2)
            {
                player2RiddleTextUI.text = riddles[currentRiddleIndex[playerID]].riddleText;
                player2HintTextUI.text = "";
            }
            attemptCount[playerID] = 0;
        }
        else
        {
            // All riddles answered by this player
            EnvironmentManager.Instance.TransformEnvironment(playerID);
        }
    }
    public void CheckAnswer(GameObject playerPointedObject, int playerID)
    {
        if (IsCorrect(playerPointedObject, riddles[currentRiddleIndex[playerID]].answerObject))
        {
            // Correct Answer
            GameManager.Instance.Update_game(playerID);
            currentRiddleIndex[playerID]++;
            ShowRiddle(playerID);
        }
        else
        {
            // Incorrect Answer
            attemptCount[playerID]++;
            if (attemptCount[playerID] >= 3)
            {
                GenerateHint(playerID);
            }
        }
    }

    bool IsCorrect(GameObject playerPointedObject, GameObject correctAnswerObject)
    {
        return playerPointedObject.CompareTag(correctAnswerObject.tag);
    }

    void GenerateHint(int playerID)
    {
        if (playerID == 1)
        {
            player1HintTextUI.text = "Hint: " + riddles[currentRiddleIndex[playerID]].hint;
        }
        else if (playerID == 2)
        {
            player2HintTextUI.text = "Hint: " + riddles[currentRiddleIndex[playerID]].hint;
        }
    }
}



    // Update is called once per frame
    