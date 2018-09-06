using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    public float timer = 1.5f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer);
	}
	
}
