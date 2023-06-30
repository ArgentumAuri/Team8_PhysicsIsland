using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        if(Input.GetButtonDown("Cancel")|| Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused= false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMainScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(0);
    }
}
