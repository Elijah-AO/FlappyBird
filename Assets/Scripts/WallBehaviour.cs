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
        GameObject bottomWallInstance = Instantiate(bottomWall, new Vector2(xPosition, -2.5f), Quaternion.identity);
        GameObject topWallInstance = Instantiate(topWall, new Vector2(xPosition, 4.5f), Quaternion.identity);
        float randomScaleYBottom;
        float randomScaleYTop;
        int x = Random.Range(0,2);
        if (x == 0){
            randomScaleYTop = Random.Range(2f, 7f); // New random scale for Y
        // Randomize Y scale for bottomWall
            randomScaleYBottom = 7f-randomScaleYTop; 
        }
        else {
            randomScaleYBottom = Random.Range(2f, 7f); // New random scale for Y
            randomScaleYTop = 7f-randomScaleYBottom;}

        float originalScaleY = 1.0f; // Assuming original scale of prefab is 1 in Y
        float moveDownAmountTop = (randomScaleYTop / 2.0f) - (originalScaleY / 2.0f);
        // Calculate move adjustments for bottomWallInstance
        float moveUpAmountBottom = (randomScaleYBottom / 2.0f) - (originalScaleY / 2.0f);

        // Apply the random scale to the topWall instance
        topWallInstance.transform.localScale = new Vector3(0.5f, randomScaleYTop, 1);
        // Apply the random scale to the bottomWall instance
        bottomWallInstance.transform.localScale = new Vector3(0.5f, randomScaleYBottom, 1);

        // Adjust topWallInstance position so the top stays at the same position
        Vector3 currentPositionTop = topWallInstance.transform.position;
        topWallInstance.transform.position = new Vector3(currentPositionTop.x, currentPositionTop.y - moveDownAmountTop, currentPositionTop.z);

        // Adjust bottomWallInstance position so the bottom stays at the same position
        Vector3 currentPositionBottom = bottomWallInstance.transform.position;
        bottomWallInstance.transform.position = new Vector3(currentPositionBottom.x, currentPositionBottom.y + moveUpAmountBottom-1f, currentPositionBottom.z);
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
