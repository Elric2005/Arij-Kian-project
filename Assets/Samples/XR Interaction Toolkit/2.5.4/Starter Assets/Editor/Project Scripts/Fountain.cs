using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fountain : MonoBehaviour
{
    public GameObject Water Polo;
    GameManager player1Progress;
    GameManager player2Progress;

    Water Polo = null
    public void water_fountain(){
        if (player1Progress > 0) && (player2Progress > 0){
            (Water Polo).SetActive(true);

        }

    }
    
}