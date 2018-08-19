using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Penguin : MonoBehaviour {
    public float movementSpeed = 1.0F;
    Rigidbody2D rb;
    Tilemap tm;
    GameObject temp;
    Vector3Int penguinLocation;

   // public GameObject penguin;

	// Use this for initialization
	void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
        temp = GameObject.FindGameObjectWithTag("Tiles");
        tm = temp.GetComponent<Tilemap>();
	}
	

	// Update is called once per frame
	void Update () {
        penguinLocation.x = (int)rb.transform.position.x;
        penguinLocation.y = (int)rb.transform.position.y;
        penguinLocation.z = (int)rb.transform.position.z;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * (movementSpeed * 2.5f));
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * (movementSpeed * 2.5f));
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * (movementSpeed * 2.5f));
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * (movementSpeed * 2.5f));
            
            Debug.Log(tm.GetType().ToString());
            Debug.Log(rb.transform.position.ToString());
            Debug.Log(tm.layoutGrid.WorldToCell(rb.transform.position));
            
        }
       

        
    }

   
}
