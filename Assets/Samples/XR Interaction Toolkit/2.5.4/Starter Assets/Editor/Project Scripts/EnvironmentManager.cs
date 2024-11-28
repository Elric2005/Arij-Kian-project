using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    public Color targetFogColor = Color.clear;
    public float fogFadeSpeed = 0.5f;
    public Material lushMaterial;
    public List<GameObject> barrenObjects;

    private Dictionary<int, bool> playerEnvironmentTransformed = new Dictionary<int, bool>();
    public void TransformEnvironment(int playerID)
    {
        if (!playerEnvironmentTransformed[playerID])
        {
            playerEnvironmentTransformed[playerID] = true;
            // Implement environment change for the specific player
            // This might involve layering or instancing environments per player,
            // which is complex. Alternatively, you can have the environment change
            // when both players have completed their riddles.

            if (playerEnvironmentTransformed[1] && playerEnvironmentTransformed[2])
            {
                // Both players have transformed their environments
                RemoveFog();
                ChangeTexturesToLush();
            }
        }
    }

    void RemoveFog()
    {
        StartCoroutine(FadeFog());
    }

    System.Collections.IEnumerator FadeFog()
    {
        while (RenderSettings.fogDensity > 0)
        {
            RenderSettings.fogDensity -= Time.deltaTime * fogFadeSpeed;
            yield return null;
        }
        RenderSettings.fog = false;
    }

    void ChangeTexturesToLush()
    {
        foreach (GameObject obj in barrenObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = lushMaterial;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
