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
      
    }
    
    public void Start()
    {
       
        riddleManager = FindObjectOfType<RiddleManager>();  

       
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

}