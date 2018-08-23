using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {

    public float baseSpeed;
    private Rigidbody2D playerRigidBody;
    Tilemap tm;
    public float frameCount = 0;
    public int count = 0;
    public int encroachingDoomSpeed = 1;


    // To track movement from input
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;

    void GetPlayerInput()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
    }

    // Use this for initialization
    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        tm = GameObject.FindGameObjectWithTag("Tiles").GetComponent<Tilemap>();

    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        movement = new Vector2(movePlayerHorizontal, movePlayerVertical);


        // Move Character
        playerRigidBody.velocity = movement * baseSpeed;

        Debug.Log(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position));
        Debug.Log(tm.GetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position)));
       // tm.SetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position), tm.GetTile(new Vector3Int(-2,-3,0)));

        //Starting location of the black mass
        Vector3Int[] things = new Vector3Int[50];
        // an array of tile base objects to be placed at the starting location of the black mass
        TileBase[] morethings = new TileBase[50];
        if (frameCount == encroachingDoomSpeed)
        {
            //reset timer
            frameCount = 0;
            for (int x = 0; x < 50; x++)
            {
                //(-20, 23, 0) is the base location of the black mass as i increment the for loop i am decrasing the y location which is going to drop down in a straight line
                // The count is incremented each thime this loop is run increasing the x location by 1
                things[x] = new Vector3Int(0 + count, 2 - x, 0);
                things[x] = new Vector3Int(0 + count, 2 - x, 0);

                // if any of the positions we are iterating through match the player location speed up the the rate of doom faster then the player can run ie kill em
                if (things[x] == tm.layoutGrid.WorldToCell(playerRigidBody.transform.position))
                {
                    encroachingDoomSpeed = 1;
                }
                // because I cant generate tiles I placed a black tile out of the playable area this is grabbing that tile's TileBase to set it at the doom locaitons
                morethings[x] = tm.GetTile(new Vector3Int(-2, -3, 0));
            }
            //finally I set my array of new doom tiles to be black tiles and increment the count
            tm.SetTiles(things, morethings);
            count += 1;
        }
        frameCount += 1;

    }

        // Update is called once per frame
   //     void Update () {
   //     float xTranslation = Input.GetAxis("Horizontal") * baseSpeed;
  //      float yTranslation = Input.GetAxis("Vertical") * baseSpeed;
 ////       transform.Translate(xTranslation, yTranslation, 0);
   // }
}
