using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

}
