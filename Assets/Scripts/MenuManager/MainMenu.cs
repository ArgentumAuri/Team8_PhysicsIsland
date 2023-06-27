using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMa : MonoBehaviour
{
    public GameObject loading;

    private void Start()
    {
        loading.SetActive(false);
    }
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadScene()
    {
        loading.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Ceil(Mathf.Clamp01(operation.progress /0.9f) * 100);
            loading.GetComponentInChildren<Text>().text = progressValue.ToString()+"%";
            yield return null;
        }
        loading.SetActive(false);
    }
}
