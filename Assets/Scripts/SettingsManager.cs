using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static int tokens;
    public TextMeshPro settings_tokens_number;
    public TextMeshPro settings_square_number;
    public static int gridArea;

    // Start is called before the first frame update
    void Start()
    {
       tokens = PlayerPrefs.GetInt("Tokens", tokens);
       gridArea = PlayerPrefs.GetInt("GridArea", gridArea);

    }

    void Update()
    {
        if (gridArea < 10)
        {
            gridArea = 10;
            PlayerPrefs.SetInt("GridArea", gridArea);
            PlayerPrefs.Save();
        }

        settings_tokens_number.text = "" + tokens;
        settings_square_number.text = "" + gridArea;
    }

    public void AddOneToken() {
        if (tokens >= 0)
        {
            tokens++;
            PlayerPrefs.SetInt("Tokens", tokens);
            PlayerPrefs.Save();
        }
    }

    public void AddTenToken()
    {
        for (int i = 0; i < 10; i++)
        {
            AddOneToken();
        }
        
    
    }

    public void RemoveOneToken()
    {
        if (tokens > 0)
        {
            tokens--;
            PlayerPrefs.SetInt("Tokens", tokens);
            PlayerPrefs.Save();
        }
        
    }

    public void RemoveTenToken()
    {
        for (int i = 0; i < 10; i++)
        {
            RemoveOneToken();
        }
    }

    public void AddOneSquare()
    {
        if (gridArea >= 0)
        {
            gridArea++;
            PlayerPrefs.SetInt("GridArea", gridArea);
            PlayerPrefs.Save();
        }

    }

    public void RemoveOneSquare()
    {
        if (gridArea > 0)
        {
            gridArea--;
            PlayerPrefs.SetInt("GridArea", gridArea);
            PlayerPrefs.Save();
        }
    }

    public void AddTenSquare()
    {
        for (int i = 0; i < 10; i++)
        {
            AddOneSquare();
        }
    }

    public void RemoveTenSquare()
    {
        for (int i = 0; i < 10; i++)
        {
            RemoveOneSquare();
        }
    }
}

