using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG_Movement : MonoBehaviour {

    // Objects used for moving the Quad. The Quad is the 3d object that holds the background image.
    public GameObject playerObj;
    private Vector2 startOffset;

    // Objects used for scrolling the background texture in place as the player moves.
    public float xScrollSpeed;
    public float yScrollSpeed;
    Material material;
    private Vector2 matOffset;


    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }


    // Use this for initialization
    void Start () {

        // Get the initial camera location.
        startOffset = transform.position - playerObj.transform.position;

        matOffset = new Vector2(xScrollSpeed, yScrollSpeed);

    }
	
	// Update is called once per frame
	void Update () {

        // Move the Quad to overlap the camera.
        Vector3 position;
        position.x = playerObj.transform.position.x + startOffset.x;
        position.y = transform.position.y;
        position.z = transform.position.z;
        transform.position = position;

        
        //material.mainTextureOffset += matOffset * Time.deltaTime;

        material.mainTextureOffset = new Vector2((playerObj.transform.position.x - startOffset.x) * xScrollSpeed, 0);

    }
}
