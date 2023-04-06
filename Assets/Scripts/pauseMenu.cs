using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerHUD;
    public GameObject Controller;
    public GameObject SecondCamera;

   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (GameIsPaused)

            {
                Resume();
            }
            else

            {
                Pause();
            }


        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerHUD.SetActive(true);
        Controller.SetActive(true);
        SecondCamera.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerHUD.SetActive(false);
        Controller.SetActive(false);
        SecondCamera.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()

    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
