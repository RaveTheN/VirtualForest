using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesMaterial : MonoBehaviour
{
    public MeshRenderer[] renderers;

    void Start()
    {
        Color newColor = Random.ColorHSV(0f, .5f, 0f, .5f);
        ApplyMaterial(newColor, 0);
    }

    void ApplyMaterial(Color color, int targetMaterialIndex)
    {
        
        for (int i = 0; i < renderers.Length; i++)
        {
            Material generatedMaterial = new Material(Shader.Find("Standard"));
            generatedMaterial.SetColor("_Color", color);
            renderers[i].material = generatedMaterial;

        }
    }
}
