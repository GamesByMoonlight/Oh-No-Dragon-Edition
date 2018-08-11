using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {
    public float scrollSpeed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Scrolling 
        GameObject currentChild;
        for( int i= 0; i< transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
        }
	}

    void ScrollChallenge (GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
}
