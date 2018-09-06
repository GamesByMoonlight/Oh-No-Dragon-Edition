using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void EndLevel();

    public static event EndLevel OnLevelEnd;

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

    public void TriggerLevelEnd()
    {
        Debug.Log("Level End Triggered");

        if (OnLevelEnd != null)
        {
            OnLevelEnd();
        }
    }
}
