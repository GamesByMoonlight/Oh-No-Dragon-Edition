﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public float delayOnPlayerDeath = 3f;
    public float delayOnLevelFinish = 3f;

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
        Debug.Log("LoadLevelOnPlayerDeath called");

        // If PlayerLives.Lives is greater than zero
            // Load the same scene
            // Otherwise load the title screen
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
