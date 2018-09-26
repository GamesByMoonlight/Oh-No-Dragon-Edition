using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerAdjustment : MonoBehaviour {

    Transform parentTransform;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        parentTransform = transform.parent.GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (parentTransform.position.y <= -3.4f)
        {
            spriteRenderer.sortingOrder = 9;
        }
        else
        {
            spriteRenderer.sortingOrder = 7;
        }
	}
}
