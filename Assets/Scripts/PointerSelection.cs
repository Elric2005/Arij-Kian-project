using UnityEngine;
using TMPro;
using Unity.Netcode;

public class PointerSelection : MonoBehaviour
{
    public LineRenderer pointer;
    public Color pointerColor;
    public Color objectPointerColor;
    public LayerMask interactableObjectLayer;

    private Transform currentObject;
    private GameObject pointedObject;
    private Camera mainCamera;

    // Reference to RiddleManager (assuming it is attached to an object in the scene)
    public RiddleManager riddleManager;

    private void Start()
    {
        mainCamera = Camera.main;
        if (pointer == null)
        {
            pointer = GetComponent<LineRenderer>();
        }

        // Optionally, find the RiddleManager in the scene if not set in Inspector
        if (riddleManager == null)
        {
            riddleManager = FindObjectOfType<RiddleManager>();
        }
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Set the start position of the pointer
        pointer.SetPosition(0, transform.position);

        // Cast the ray to detect objects
        if (Physics.Raycast(ray, out hit, 10f, interactableObjectLayer))
        {
            // Set the end position of the pointer to the hit point
            pointer.SetPosition(1, hit.point);

            // Change the pointer color when it's over an interactable object
            pointer.startColor = objectPointerColor;
            pointer.endColor = objectPointerColor;

            // Highlight the object being pointed at
            if (currentObject != hit.transform)
            {
                if (currentObject != null)
                    ResetObjectHighlight(currentObject);

                currentObject = hit.transform;
                HighlightObject(currentObject);
                pointedObject = hit.transform.gameObject;
            }

            // Check if the trigger button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log($"Selected: {pointedObject.name}");

                // Check if the player is pointing at the fountain (for the Ending Scene)
                if (pointedObject.CompareTag("Fountain"))
                {
                    // Ensure that both players have completed their riddles before allowing to load the Ending Scene
                    if (riddleManager != null && riddleManager.GetCompletedRiddlesForPlayer(1) == 4 && riddleManager.GetCompletedRiddlesForPlayer(2) == 4)
                    {
                        Debug.Log("Both players have answered all riddles. Proceeding to the Ending Scene.");
                        SceneLoader.Instance.LoadEndingScene();
                    }
                }
                // If the player points at a riddle answer object
                else if (pointedObject.CompareTag("RiddleAnswer"))
                {
                    if (riddleManager != null)
                    {
                        riddleManager.CmdCheckAnswer(pointedObject);  // Check the answer through RiddleManager
                    }
                }
                // If the player points at the Restart button (to load the Menu Scene)
                else if (pointedObject.CompareTag("RestartButton"))
                {
                    SceneLoader.Instance.LoadMenuScene();
                }
            }
        }
        else
        {
            // Reset the pointer if no object is hit
            pointer.SetPosition(1, transform.position + transform.forward * 10f);
            pointer.startColor = pointerColor;
            pointer.endColor = pointerColor;

            // Reset the highlight for the previous object
            if (currentObject != null)
            {
                ResetObjectHighlight(currentObject);
                currentObject = null;
            }
        }
    }

    private void HighlightObject(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Highlight the object with a specific color (e.g., yellow)
            renderer.material.color = Color.yellow;
        }
    }

    private void ResetObjectHighlight(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Reset the object's material color to white (default color)
            renderer.material.color = Color.white;
        }
    }

    // Method to check if this player has pointed at a specific object (e.g., fountain)
    public bool HasPointedAtObject(GameObject targetObject)
    {
        return pointedObject == targetObject;
    }
}
