using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Made through a youtube guide by Dapper Dino

public class MenuScript : MonoBehaviour
{
    public Button host;
    public Button client;
    public GameObject menuCanvas;
    public Transform leftHand; 
    public Transform rightHand; 
    public Transform mainCamera; 
    private bool isMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (facing_camera(leftHand))
        {
            Activate_menu(leftHand);
        }
        else if (facing_camera(rightHand))
        {
            Activate_menu(rightHand);
        }
        else
        {
            menuCanvas.SetActive(false);
            isMenuActive = false;
        }
        
    }
    
    private bool facing_camera(Transform hand)
    {
        Vector3 palm_direction = hand == rightHand ? -hand.right : hand.right;
        float dotProduct = Vector3.Dot(palm_direction, mainCamera.forward);
        return dotProduct > 0.5f;
    }
    private void Activate_menu(Transform hand)
    {
        if (!isMenuActive)
        {
            menuCanvas.SetActive(true);
            menuCanvas.transform.position = hand.position;
            menuCanvas.transform.rotation = hand.rotation;
            isMenuActive = true;
        }
    }
}
