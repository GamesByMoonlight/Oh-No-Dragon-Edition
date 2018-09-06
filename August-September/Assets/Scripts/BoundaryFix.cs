using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position -= new Vector3(0, .001f, 0);

        // If this isn't done, the collider doesn't match up to the grid properly.
        // I don't know why this works...
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
