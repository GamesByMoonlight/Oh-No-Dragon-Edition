using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICounter : MonoBehaviour {

    public Text TimerText;
    private bool Finished = false;
    private ScoreKeeper SK;
    private int currentScore;

    void Start() {
        StartCoroutine(FindScorekeeper());
        
    }

    IEnumerator FindScorekeeper()
    {
        yield return new WaitForFixedUpdate();
        SK = FindObjectOfType<ScoreKeeper>();
    }

    void Update() {
        if (Finished)
        { return; }

        if (SK != null)
        {
            TimerText.text = SK.SavedScore.ToString();
        }
       
    }

    

}
