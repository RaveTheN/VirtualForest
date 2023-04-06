using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraAlberi : MonoBehaviour
{

    public GameObject[] Tree;
    public int Tree_X_Min;
    public int Tree_X_Max;
    public int Tree_Z_Min;
    public int Tree_Z_Max;
    public float gridSpacingOffset = 1f;


    // Start is called before the first frame update
    void Start()
    {
       
        TreePlacement();
        

    }

    
    
    void TreePlacement ()
    {
        for (int x = Tree_X_Min; x < Tree_X_Max; x++)
        {

            
            for (int z = Tree_Z_Min; z < Tree_Z_Max; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset + Random.Range(-0.2f, 0.2f), 0.3f, z * gridSpacingOffset + Random.Range(-0.2f, 0.2f));
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }

          
        }

     

        void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
        {
            int randomIndex = Random.Range(0, Tree.Length);
            //in  the following gameObject rotation on Y axis is randomised in line
            GameObject.Instantiate(Tree[randomIndex], positionToSpawn, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
}

