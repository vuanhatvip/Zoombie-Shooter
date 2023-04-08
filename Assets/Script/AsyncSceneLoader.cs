using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private ProgressBar progressBar;

    public void LoadScene()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadScene_Couroutine());
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator LoadScene_Couroutine()
    {
        AsyncOperation loadingTask = SceneManager.LoadSceneAsync(sceneName);
        //yield return loadingTask;
        do
        {
            progressBar.SetProgress(loadingTask.progress);
            yield return null;
        } while (!loadingTask.isDone);
        Debug.Log("New Scene Loaded");
        //Destroy(gameObject);
    }
}
