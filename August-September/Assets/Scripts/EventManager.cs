﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void EndLevel();
    public delegate void PlayerDeath();
    public delegate void ResetMana();

    public static event EndLevel OnLevelEnd;
    public static event PlayerDeath OnPlayerDeath;
    public static event ResetMana OnManaReset;

    public static EventManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void TriggerLevelEnd()
    {
        if (OnLevelEnd != null)
        {
            OnLevelEnd();
        }
    }

    public static void TriggerPlayerDeath()
    {

        PlayerLives.RemoveLife();

        if (OnPlayerDeath!= null)
        {
            OnPlayerDeath();
        }
    }

    public static void TriggerManaReset()
    {
        if (OnManaReset != null)
        {
            OnManaReset();
        }
    }
}
