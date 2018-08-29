using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1.5f);
	}
	
}
