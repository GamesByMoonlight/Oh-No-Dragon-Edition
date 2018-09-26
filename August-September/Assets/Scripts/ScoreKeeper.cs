using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int SavedScore { get; set; }

    static ScoreKeeper instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }


    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    public void AddScore()
    {
        SavedScore += 10 ;
    }

public void ResetScore()
    {
        SavedScore = 0;
    }	

}
