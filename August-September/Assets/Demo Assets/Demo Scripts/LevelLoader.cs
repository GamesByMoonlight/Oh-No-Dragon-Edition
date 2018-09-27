using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    float delayOnPlayerDeath = 3f;
    float delayOnLevelFinish = 4.5f;

    void OnEnable()
    {
        EventManager.OnLevelEnd += LoadNextLevel;
        EventManager.OnPlayerDeath += LoadLevelOnPlayerDeath;
    }

    void OnDisable()
    {
        EventManager.OnLevelEnd -= LoadNextLevel;
        EventManager.OnPlayerDeath -= LoadLevelOnPlayerDeath;
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(DelayedLevelLoad((sceneIndex + 1), delayOnLevelFinish));
    }

    void LoadLevelOnPlayerDeath()
    {
        // If PlayerLives.Lives is greater than zero
        if(PlayerLives.Lives > 0)
        {
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			StartCoroutine(DelayedLevelLoad((sceneIndex), delayOnPlayerDeath));
		}
        else
        {
	        int sceneIndex = 0;
			StartCoroutine(DelayedLevelLoad((sceneIndex), delayOnPlayerDeath));
		}
    }


    void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    void LoadLevel(int levelIndexToLoad)
    {
        SceneManager.LoadScene(levelIndexToLoad);
    }

    IEnumerator DelayedLevelLoad(int nextSceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);

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
