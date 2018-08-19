using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour {
    SpriteRenderer tempRend;
    // 
    float timer = 3;

    private void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;
	}
}
