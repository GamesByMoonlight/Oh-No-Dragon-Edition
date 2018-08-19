using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {
    public float scrollSpeed = 5.0f;
    public GameObject[] challenges;
    //challenges generated per second
    public float frequency = 0.5f;
    public Transform challengesSpawnPoint;

    float counter = 0.0f;
	// Use this for initialization
	void Start () {
        GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {
        if(counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }
        //Scrolling 
        GameObject currentChild;
        for( int i= 0; i< transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if(currentChild.transform.position.x <= -20)
            {
                Destroy(currentChild);
            }
        }
	}

    void ScrollChallenge (GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        //Quaternion is a default rotation
        GameObject newChallenge =Instantiate(challenges[Random.Range(0, challenges.Length)],challengesSpawnPoint.position,Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;
        counter = 1.0f;
    }
}
