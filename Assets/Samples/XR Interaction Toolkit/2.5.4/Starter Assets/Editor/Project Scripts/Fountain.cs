using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public static Fountain Instance;

    public Transform player1WaterTransform;
    public Transform player2WaterTransform;
    public float maxWaterHeight;


    // Start is called before the first frame update
    public void UpdateWaterLevel(int playerProgress, int totalRiddles, int playerID)
    {
        float progressRatio = (float)playerProgress / totalRiddles;
        AdjustWaterLevelVisual(progressRatio, playerID);
    }

    private void AdjustWaterLevelVisual(float level, int playerID)
    {
        if (playerID == 1)
        {
            Vector3 newScale = player1WaterTransform.localScale;
            newScale.y = level * maxWaterHeight;
            player1WaterTransform.localScale = newScale;
        }
        else if (playerID == 2)
        {
            Vector3 newScale = player2WaterTransform.localScale;
            newScale.y = level * maxWaterHeight;
            player2WaterTransform.localScale = newScale;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
