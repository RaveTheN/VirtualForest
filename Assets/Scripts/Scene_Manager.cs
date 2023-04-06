using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene_Manager : MonoBehaviour
{
    //this code has to be attached to a UI button component. Put it on a GameObject and assign it on the OnClick sectio, then select CheckTheAnswer
    public TMP_InputField PasswordField;

    public void CheckTheAnswer()//this method is called in the authentication page
    {
        string input = PasswordField.text;
        if (input.Equals("bocs"))
            SceneManager.LoadScene(1);
        else
            Debug.Log("Wrong Password");
        if (input == "The Right Answer") SceneManager.LoadScene("TheNextScene");
    }

    public void SetValues()//this method is called in settings page
    {
        SceneManager.LoadScene(2);
    }

    public void NewGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(3);
    }

    public void Admin()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void Comandi()
    {
        SceneManager.LoadScene(4);
    }


}

