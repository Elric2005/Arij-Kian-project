using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Progress = 0;
    public int player2Progress = 0;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    private RiddleManager riddleManager;

    // Start is called before the first frame update
    public void Start()
    {
        SpawnPlayers();  // Spawn the players at their designated spawn points
        riddleManager = FindObjectOfType<RiddleManager>();  // Find the RiddleManager in the scene

        // Show the riddles for both players
        riddleManager.ShowRiddle(1); // Show riddle for Player 1
        riddleManager.ShowRiddle(2); // Show riddle for Player 2
    }

    // This method is called when a player answers a riddle correctly
    public void Update_game(int playerID)
    {
        if (playerID == 1)
        {
            player1Progress++;  // Increase Player 1's progress
            Fountain.Instance.UpdateWaterLevel(player1Progress, riddleManager.riddles.Count, playerID);
        }
        else if (playerID == 2)
        {
            player2Progress++;  // Increase Player 2's progress
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
            Debug.LogError("Player 1 prefab or spawn point is not assigned!");
        }

        if (player2Prefab != null && player2SpawnPoint != null)
        {
            // Instantiate Player 2 at the spawn point
            Instantiate(player2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Player 2 prefab or spawn point is not assigned!");
        }
    }
}

