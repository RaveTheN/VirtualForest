using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecordLastPosition : MonoBehaviour
{


    public Transform MyTransform = null;
    public Vector3 LastPos = Vector3.zero;
    public Quaternion LastRot = Quaternion.identity;


    //SavePosition before going to Pause Menu
    void SaveData()
    {
        //Get the path in which Unity saves persistent data.  It consist of a Javascript Object Notation (JSON)
        string OutputPath = Application.persistentDataPath + "/saveFile.json";
        LastPos = MyTransform.position;
        LastRot = MyTransform.rotation;

        //Write the converted string into ObjectPosition file
        StreamWriter writer = new StreamWriter(OutputPath);
        writer.WriteLine(JsonUtility.ToJson(this));                        //Save THIS class data into text file
        writer.Close();
        Debug.Log("The output path is " + OutputPath);

    }

    void RetreiveData()
    {
        //Gets the strign containing the encoded data of position and rotation
        string InputPath = Application.persistentDataPath + "/saveFile.json";
        StreamReader reader = new StreamReader(InputPath);
        string JSONString = reader.ReadToEnd();
        Debug.Log("The encoded string is " + JSONString);
        JsonUtility.FromJsonOverwrite(JSONString, this);                //Decode JSON and "pack" into THIS class
        reader.Close();

        MyTransform.position = LastPos;                                    //Set previously saved POS
        MyTransform.rotation = LastRot;                                    //Set previously saved ROT
    }
    // Use this for initialization
    void Awake()
    {
        MyTransform = GetComponent<Transform>();
    }

    void Start()
    {
        RetreiveData();
    }

    // It is called when the scene is cut off
    void OnDestroy()
    {
        SaveData();
    }
}