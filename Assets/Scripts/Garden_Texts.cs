using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Garden_Texts : MonoBehaviour {

    public TextMeshPro tokens_text;
    public TextMeshPro plantedCount_text;

    int tokens;
	
	void Update () {

        tokens = PlayerPrefs.GetInt("Tokens", tokens);

        tokens_text.text = "Gettoni: " + tokens;


        plantedCount_text.text = "Piantati " + ClickSpawner.treeNumber + " di " + (SettingsManager.gridArea * SettingsManager.gridArea + " alberi.");

    }
}
