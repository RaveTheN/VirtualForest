using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreesData", menuName = "Scripts/Trees Data")]
public class ScriptableTrees : ScriptableObject
{
    public string TreeName;
    public string OwnerName;
    public GameObject TreeModel;
    public string Coordinate;
    public Vector3 position;
}
