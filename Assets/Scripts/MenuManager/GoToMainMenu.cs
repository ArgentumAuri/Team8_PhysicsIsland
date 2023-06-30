using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitToMainScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
