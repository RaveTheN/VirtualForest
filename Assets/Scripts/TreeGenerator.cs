using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject tree;
    public float x;
    public float y;
    public float z;

    int treeNumber;
    void Start()
    {
        treeNumber = PlayerPrefs.GetInt("treeNumber", treeNumber);
        for ( int i = 0; i < treeNumber; i++)
        {

            if (PlayerPrefs.HasKey("x" + i) && PlayerPrefs.HasKey("y" + i) && PlayerPrefs.HasKey("z" + i))
            {

                x = PlayerPrefs.GetFloat("x" + i);
                y = PlayerPrefs.GetFloat("y" + i);
                z = PlayerPrefs.GetFloat("z" + i);
                Vector3 posVec = new Vector3(x, y, z);


                GameObject gameObject = Instantiate(tree, posVec, Quaternion.identity);
            }
        }
        
    }
    void Update()
    {
        
    }

  
}
