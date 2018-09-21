using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        PlayerLives.ResetLives(3);
	}



}
