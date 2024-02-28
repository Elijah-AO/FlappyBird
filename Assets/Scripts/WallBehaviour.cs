using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    [SerializeField] PlayerBehaviour _PlayerBehaviour;
    public GameObject topWall; // Assign in the inspector
    public GameObject bottomWall; // Assign in the inspector

    private void SpawnObject(float xPosition)
    {
        GameObject bottomWallInstance = Instantiate(bottomWall, new Vector2(xPosition, 5.5f), Quaternion.identity);
        GameObject topWallInstance = Instantiate(topWall, new Vector2(xPosition, -5.5f), Quaternion.identity);
        float topDisplacement = Random.Range(2.5f, 8.5f);
        float bottomDisplacement = topDisplacement - 11f;
        
        Vector3 currentPositionTop = topWallInstance.transform.position;
        topWallInstance.transform.position = new Vector3(currentPositionTop.x, topDisplacement, currentPositionTop.z);

        Vector3 currentPositionBottom = bottomWallInstance.transform.position;
        bottomWallInstance.transform.position = new Vector3(currentPositionBottom.x, bottomDisplacement, currentPositionBottom.z);
    }
    public IEnumerator SpawnEm(){
        float xPosition = 12f;
        while (!_PlayerBehaviour._isJover){
            SpawnObject(xPosition);
            xPosition += 5f;
            yield return new WaitForSeconds(1f);
        }
    }
}
