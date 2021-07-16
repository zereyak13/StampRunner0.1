using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ElephantSDK;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    private void Awake()
    {
        Instance = this;

        Elephant.LevelStarted(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadThisScene()
    {
        StartCoroutine(AddDelay2());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(AddDelay());
    }
    IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(2f);

        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings -1)
        {
            Elephant.LevelCompleted(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Elephant.LevelCompleted(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator AddDelay2()
    {
        yield return new WaitForSeconds(2f);
        Elephant.LevelCompleted(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public int GetThisLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
