using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICounter : MonoBehaviour {

    public Text TimerText;
    private float startTime;
    private bool Finished = false;
    private ScoreKeeper SK;

    private int currentScore;

    void Start() {
        startTime = Time.time;
        SK = FindObjectOfType<ScoreKeeper>();
    }
    // Update is called once per frame
    void Update() {
        if (Finished)
        { return; }
        float t = Time.time - startTime;// time in seconds
    
        //string minuites = ((int)t / 60).ToString();
        string seconds = ((t % 60) * 50).ToString("f0"); // f2 for two decimals
        TimerText.text = seconds;
        currentScore = (int)(t % 60 * 50);    
    }

    public void Finish()
    {
        TimerText.color = Color.yellow;
        Finished = true;
        if (SK != null)
        {
            SK.SavedScore = currentScore;
        }
        
    }

}
