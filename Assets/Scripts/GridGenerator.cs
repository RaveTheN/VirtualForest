using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridX = 10;
    public int gridZ = 10;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    int gridArea;
    // Start is called before the first frame update
    void Start()
    {

        gridX = PlayerPrefs.GetInt("GridArea", gridArea);
        gridZ = PlayerPrefs.GetInt("GridArea", gridArea);
        SpawnGrid();
    }


    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }

   void PickAndSpawn (Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
