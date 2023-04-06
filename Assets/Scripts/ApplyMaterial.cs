using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMaterial : MonoBehaviour
{
    public Material[] materialsToPickFrom;
    public MeshRenderer rendererMaterial;

    void Start()
    {
        ApplyMaterialToCube();
    }

    void ApplyMaterialToCube()
    {
        for (int i = 0; i < materialsToPickFrom.Length; i++)
        {
            int randomIndex = Random.Range(0, materialsToPickFrom.Length);
            rendererMaterial.material = materialsToPickFrom[randomIndex];
        }
    }
   
}
