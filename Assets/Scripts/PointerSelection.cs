using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PointerSelection : MonoBehaviour
{
    public LineRenderer Pointer;
    public Color Pointer_color;
    public Color object_pointer;
    public LayerMask interactable_object;
    private Transform current_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        Pointer.SetPosition(0, transform.position);

        // Cast the ray
        if (Physics.Raycast(ray, out hit, 10f, interactable_object))
        {
            // Set laser to hit point
            Pointer.SetPosition(1, hit.point);

            // Change laser color
            Pointer.startColor = object_pointer;
            Pointer.endColor = object_pointer;

            // Highlight the object
            if (current_object != hit.transform)
            {
                if (current_object != null)
                    Reset_light(current_object);

                current_object = hit.transform;
                HighlightObject(current_object);
            }

            // Check if the trigger button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log($"Selected: {hit.transform.name}");
                Select(hit.transform.gameObject);
            }
        }
        else
        {
            // No hit; extend laser forward
            Pointer.SetPosition(1, transform.position + transform.forward * 10f);
            Pointer.startColor = Pointer_color;
            Pointer.endColor = Pointer_color;

            // Reset any previously highlighted object
            if (current_object != null)
            {
                Reset_light(current_object);
                current_object = null;
            }
        }
    }
    private void HighlightObject(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.yellow;  // Example highlight color
        }
    }

    // Reset the object's highlight
    private void Reset_light(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white;  // Reset to default color
        }
    }

    // Called when the object is selected
    private void Select(GameObject selectedObject)
    {
        // Perform the desired action with the selected object
        Debug.Log($"You selected {selectedObject.name}!");
    }

}
