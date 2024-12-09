// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;

// public class TwoPlayerNetworkManager : NetworkManager

//     public override void OnServerConnect(NetworkConnection conn)
//     {
//         base.OnServerConnect(conn);
//         Debug.Log("A player has connected to the server.");

//         if (NetworkServer.connections.Count > 2)
//         {
//             conn.Disconnect();
//             Debug.Log("More than two players connected.");
//         }
//     }

//     public override void OnServerDisconnect(NetworkConnection conn)
//     {
//         base.OnServerDisconnect(conn);
//         Debug.Log("A player has disconnected from the server.");
//     }

//     public override void OnStartServe r()
//     {
//         base.OnStartServer();
//         Debug.Log("Server has started.");
//     }

//     public override void OnStopServer()
//     {
//         base.OnStopServer();
//         Debug.Log("Server has stopped.");
//     }
//      public override void OnStopServer()
//     {
//         base.OnStopServer();
//         Debug.Log("Server has stopped.");
//     }

//     public override void OnClientConnect(NetworkConnection conn)
//     {
//         base.OnClientConnect(conn);
//         Debug.Log("Client connected to server.");
//     }

//     public override void OnClientDisconnect(NetworkConnection conn)
//     {
//         base.OnClientDisconnect(conn);
//         Debug.Log("Client disconnected from server.");
//     }

//     public void StartHostButton()
//     {
//         StartHost();
//         Debug.Log("Host started.");
//     }

//     public void StartClientButton(string ipAddress)
//     {
//         networkAddress = ipAddress;
//         StartClient();
//         Debug.Log("Client connecting to " + ipAddress);
//     }
// }

// [Serializable]
// public class Player : NetworkBehaviour
// {
//     public float moveSpeed = 5f;

//     void Update()
//     {
//         if (!isLocalPlayer)
//             return;

//         float horizontal = Input.GetAxis("Horizontal");
//         float vertical = Input.GetAxis("Vertical");

//         Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
//         transform.Translate(movement);
//     }

//     public override void OnStartLocalPlayer()
//     {
//         base.OnStartLocalPlayer();
//         GetComponent<Renderer>().material.color = Color.blue;
//     }
// }

// public class UIManager : MonoBehaviour
// {
//     public TwoPlayerNetworkManager networkManager;
//     public string ipAddress = "127.0.0.1";

//     void OnGUI()
//     {
//         if (GUILayout.Button("Start Host"))
//         {
//             networkManager.StartHostButton();
//         }

//         if (GUILayout.Button("Start Client"))
//         {
//             networkManager.StartClientButton(ipAddress);
//         }
//     }
// }


// public class Networking : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
