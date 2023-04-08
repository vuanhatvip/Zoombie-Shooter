using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private GameObject loadingCanvas;
    [SerializeField]
    private ProgressBar progressBar;
    [SerializeField]
    private float fakeLoadingDuration;
    [SerializeField]
    private GameObject pressAnyKeyText;

    float fakeProgress;
    float startTime;

    private void Start()
    {
        loadingCanvas.SetActive(false);
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadScene_Couroutine());
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator LoadScene_Couroutine()
    {
        Prepare();
        AsyncOperation loadingTask = SceneManager.LoadSceneAsync(sceneName);
        //yield return loadingTask;
        //do
        //{
        //    progressBar.SetProgress(loadingTask.progress);
        //    yield return null;
        //} while (!loadingTask.isDone);
        while (!loadingTask.isDone || fakeProgress < 1f)
        {
            yield return null;
            UpdateFakeProgress(loadingTask);
            progressBar.SetProgress(fakeProgress);
        }
        yield return WaitForAnyKey();
        //Debug.Log("New Scene Loaded");
        ResumeGame();
        Destroy(gameObject);
    }

    private IEnumerator WaitForAnyKey()
    {
        pressAnyKeyText.SetActive(true);
        yield return new WaitUntil(() => Input.anyKeyDown);
    }

    private void UpdateFakeProgress(AsyncOperation loadingTask)
    {
        float elapsedTime = (Time.time - startTime) / fakeLoadingDuration;
        fakeProgress = Mathf.Min(loadingTask.progress, elapsedTime);
    }

    private void Prepare()
    {
        loadingCanvas.SetActive(true);
        progressBar.SetProgress(0);
        pressAnyKeyText.SetActive(false);
        fakeProgress = 0f;
        startTime = Time.time;
    }

    private void ResumeGame()
    {
        var flow = FindAnyObjectByType<GameFlow>();
        if (flow)
        {
            flow.ResumeGame();
        }
    }
}
