using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public 

    public int player1Progress = 0;
    public int player2Progress = 0;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    private RiddleManager riddleManager;

    
    public void Start()
    {
        SpawnPlayers();  
        riddleManager = FindObjectOfType<RiddleManager>();  

        // Show the riddles for both players
        riddleManager.InitializeRiddles(allRiddles[0])); 
        riddleManager.InitializeRiddles(allRiddles[3]));
    }

    
    public void CorrectRiddleAnswered(int playerID)
    {
        if (playerID == 1)
        {
            player1Progress++;  
            Fountain.Instance.UpdateWaterLevel(player1Progress, riddleManager.riddles.Count, playerID);
        }
        else if (playerID == 2)
        {
            player2Progress++; 
            Fountain.Instance.UpdateWaterLevel(player2Progress, riddleManager.riddles.Count, playerID);
        }
    }

    // Method to spawn players at their spawn points
    private void SpawnPlayers()
    {
        if (player1Prefab != null && player1SpawnPoint != null)
        {
            // Instantiate Player 1 at the spawn point
            Instantiate(player1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Player 1 spawn point is not assigned");
        }

        if (player2Prefab != null && player2SpawnPoint != null)
        {
            // Instantiate Player 2 at the spawn point
            Instantiate(player2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Player 2 spawn point is not assigned");
        }
    }
    if (player1progress == 4) && (player2progress == 4) {
    SceneManager.LoadScene("Lush Forest");
}    




}

