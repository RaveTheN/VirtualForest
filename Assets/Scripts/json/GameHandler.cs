using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("GameHandler.Start");

        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(9, 0);
        playerData.health = 80;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);

    }

    private class PlayerData
    {
        public Vector3 position;
        public int health;


    }
}
