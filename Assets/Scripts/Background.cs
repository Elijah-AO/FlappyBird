using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject background; // Reference to the background prefab
    [SerializeField] private GameObject ground;
    [SerializeField] private PlayerBehaviour playerBehaviour; // Reference to the player behavior script

    // Initial position for the background instantiation

    private void SpawnBackground(float startPosition)
    {
        // Instantiate the background at the given startPosition with no rotation
        GameObject backgroundInstance = Instantiate(background, new Vector3(startPosition, 0, 1.3f), Quaternion.identity);
        GameObject backgroundInstance2 = Instantiate(background, new Vector3(18f, 0, 1.3f), Quaternion.identity);
        GameObject groundInstance = Instantiate(ground, new Vector3(startPosition, -10f, -1.3f), Quaternion.identity);
        GameObject groundInstance2 = Instantiate(ground, new Vector3(18f, -10f, -1.3f), Quaternion.identity);
    }

    public IEnumerator SpawnEm()
    {
        float beginning = 0f; 
        // Keep spawning backgrounds as long as the condition is false
        while (!playerBehaviour._isJover)
        {            
            SpawnBackground(beginning);
            beginning += 18f; // Move the start position for the next background
            yield return new WaitForSeconds(2.5f); // Wait for 1.5 seconds before spawning the next background
        }
    }
}

