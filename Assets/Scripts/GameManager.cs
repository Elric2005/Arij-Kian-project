using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;
   // public 

    NetworkVariable<int> player1Progress = new NetworkVariable<int>(0);
    NetworkVariable<int> player2Progress = new NetworkVariable<int>(0);

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    

    private RiddleManager riddleManager;


    public override void OnNetworkSpawn(){
        player1Progress.OnValueChanged += Player1ProgressChanged;
    }

    public void Player1ProgressChanged(int oldVal, int newVal){
        //Update fountain?
    }
    
    public void Start()
    {
        // SpawnPlayers();  
        riddleManager = FindObjectOfType<RiddleManager>();  

        // Show the riddles for both players
       // riddleManager.InitializeRiddles(allRiddles[0]); 
       // riddleManager.InitializeRiddles(allRiddles[3]);
    }

    [Rpc(SendTo.Server)]
    public void CorrectRiddleAnsweredRpc(int playerID)
    {
        if (!IsServer) return;

        if (playerID == 1)
        {
            player1Progress.Value++;  
        }
        else if (playerID == 2)
        {
            player2Progress.Value++; 
        }

        if (player1Progress.Value == 4 && player2Progress.Value == 4) {
            NetworkManager.Singleton.SceneManager.LoadScene("Lush Forest", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    // Method to spawn players at their spawn points
//     private void SpawnPlayers()
//     {
//         if (player1Prefab != null && player1SpawnPoint != null)
//         {
//             // Instantiate Player 1 at the spawn point
//             Instantiate(player1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
//         }
//         else
//         {
//             Debug.LogError("Player 1 spawn point is not assigned");
//         }

//         if (player2Prefab != null && player2SpawnPoint != null)
//         {
//             // Instantiate Player 2 at the spawn point
//             Instantiate(player2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
//         }
//         else
//         {
//             Debug.LogError("Player 2 spawn point is not assigned");
//         }
//     }
// }    






}