using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Restart()
    {
        SceneManager.LoadScene("Menu");
        
    }

    // Update is called once per frame
    
}
