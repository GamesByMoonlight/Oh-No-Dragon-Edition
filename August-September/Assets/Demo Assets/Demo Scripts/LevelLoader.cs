using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    void OnEnable()
    {
        EventManager.OnLevelEnd += LoadNextLevel;
    }

    void OnDisable()
    {
        EventManager.OnLevelEnd -= LoadNextLevel;
    }

    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevel(int levelIndexToLoad)
    {
        SceneManager.LoadScene(levelIndexToLoad);
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(DelayedLevelLoad(sceneIndex + 1));
    }

    IEnumerator DelayedLevelLoad(int nextSceneIndex)
    {
        yield return new WaitForSeconds(3f);

        if (nextSceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            LoadLevel(0);
        }
        else
        {
            LoadLevel(nextSceneIndex);
        }
        
    }

}
