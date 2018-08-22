using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Penguin : MonoBehaviour {
    public float movementSpeed = 1.0F;
    Rigidbody2D rb;
    Tilemap tm;
    GameObject temp;
    Vector3Int penguinLocation;
    private TileBase TileImage;
    public float frameCount = 0;
    public int count = 0;
    public int encroachingDoomSpeed = 1;

    // public GameObject penguin;

    // Use this for initialization
    void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
        temp = GameObject.FindGameObjectWithTag("Tiles");
        tm = temp.GetComponent<Tilemap>();
       
    }
	

	// Update is called once per frame
	void Update () {
        Debug.Log(TileImage);
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
            //Vector3Int[] things = new Vector3Int[50];
            //TileBase[] morethings = new TileBase[50];
          //  Debug.Log(tm.GetType().ToString());
          // Debug.Log(rb.transform.position.ToString());
            Debug.Log(tm.layoutGrid.WorldToCell(rb.transform.position));
            Debug.Log(tm.GetTile(tm.layoutGrid.WorldToCell(rb.transform.position)));
            //tm.SetTile(tm.layoutGrid.WorldToCell(rb.transform.position),tm.GetTile(new Vector3Int(-5,-1,0)));
            tm.SetTile(tm.layoutGrid.WorldToCell(new Vector3Int (0,0,0)), tm.GetTile(new Vector3Int(-45, -2, 0)));
            //-45,2,0 = darkness
            BoundsInt bounds = new BoundsInt(10, 10, 10, 10, 10, 10);
            Debug.Log(bounds.size);
           
        }
        Vector3Int[] things = new Vector3Int[50];
        TileBase[] morethings = new TileBase[50];
        if (frameCount == encroachingDoomSpeed)
        {
            frameCount = 0;
            for (int x = 0; x < 50; x++)
            {
                things[x] = new Vector3Int(-20 + count, 23 - x, 0);
                things[x] = new Vector3Int(-20 + count, 23 - x, 0);
                if(things[x] == tm.layoutGrid.WorldToCell(rb.transform.position))
                {
                    encroachingDoomSpeed = 1;
                }
                morethings[x] = tm.GetTile(new Vector3Int(-45, -2, 0));
            }
            tm.SetTiles(things, morethings);
            count += 1;
        }
        frameCount += 1;
        


    }

   
}
