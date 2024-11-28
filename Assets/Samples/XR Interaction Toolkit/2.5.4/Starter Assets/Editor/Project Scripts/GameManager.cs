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
    void Start()
    {
        
        SpawnPlayers();
        riddleManager = FindObjectOfType<RiddleManager>();
        riddleManager.ShowRiddle();
    }

    // Update is called once per frame
    private void Update_game(int playerID)
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
}
