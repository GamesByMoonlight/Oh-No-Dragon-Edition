using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaraControls : MonoBehaviour {

    public float baseSpeed;

	
	// Update is called once per frame
	void Update () {
        float xTranslation = Input.GetAxis("Horizontal") * baseSpeed;
        float yTranslation = Input.GetAxis("Vertical") * baseSpeed;
        transform.Translate(xTranslation, yTranslation, 0);
    }
}
