using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Checker : MonoBehaviour
{
    private Camera playerCamera;
    private RiddleManager riddleManager;
    public int playerID;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        riddleManager = FindObjectOfType<RiddleManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerID == 1 && Input.GetMouseButtonDown(0)) || (playerID == 2 && Input.GetMouseButtonDown(1)))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject playerPointedObject = hit.collider.gameObject;
                riddleManager.CheckAnswer(playerPointedObject, playerID);
            }
        }

    }
    
}
        
    

