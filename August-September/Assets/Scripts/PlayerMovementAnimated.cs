using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovementAnimated : MonoBehaviour {

    public float baseSpeed;
    private Rigidbody2D playerRigidBody;


    // To track movement from input
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;
    Tilemap tm;
    public float frameCount = 0;
    public int count = 0;
    public int encroachingDoomSpeed = 10;

    //Added animator to script
    Animator anim;

    void GetPlayerInput()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
    }

    // Use this for initialization
    void Awake()
    {
        //defines animator
        anim = GetComponent<Animator>();
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

        //returns value to animator. when animBaseSpeed is greater than 0.25 animation changes from idle to walking
        anim.SetFloat ("animBaseSpeed", Mathf.Abs (movePlayerHorizontal));
        Debug.Log(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position));
        Debug.Log(tm.GetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position)));
        // tm.SetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position), tm.GetTile(new Vector3Int(-2,-3,0)));

        //Starting location of the black mass
        Vector3Int[] locationOfDeath = new Vector3Int[60];
        // an array of tile base objects to be placed at the starting location of the black mass
        TileBase[] DeathTiles = new TileBase[60];
        if (frameCount == encroachingDoomSpeed)
        {
            //reset timer
            frameCount = 0;
            for (int y = 0; y < DeathTiles.Length; y++)
            {
                //(-20, 23, 0) is the base location of the black mass as i increment the for loop i am decrasing the y location which is going to drop down in a straight line
                // The count is incremented each thime this loop is run increasing the x location by 1
                locationOfDeath[y] = new Vector3Int(-50 + count, 20 - y, 0);

                // if any of the positions we are iterating through match the player location speed up the the rate of doom faster then the player can run ie kill em
                if (locationOfDeath[y] == tm.layoutGrid.WorldToCell(playerRigidBody.transform.position))
                {
                    encroachingDoomSpeed = 1;
                }
                // because I cant generate tiles I placed a black tile out of the playable area this is grabbing that tile's TileBase to set it at the doom locaitons
                DeathTiles[y] = tm.GetTile(new Vector3Int(-113, -10, 0));
            }
            //finally I set my array of new doom tiles to be black tiles and increment the count
            tm.SetTiles(locationOfDeath, DeathTiles);
            count += 1;
        }
        frameCount += 1;
        //calls animation method
        SetAnimation();
    }

    //test animations for flying digging walking and breathing fire
    void SetAnimation()
    {
        if(Input.GetKey("z"))   
        {
            anim.SetBool("isFlying", true);
            anim.SetBool("isDigging", false);
            anim.SetBool("isFiring", false);
        }
        else if(Input.GetKey("x")) 
        {
            anim.SetBool("isFlying", false);
            anim.SetBool("isDigging", true);
            anim.SetBool("isFiring", false);
        }
        else if(Input.GetKey("c")) 
        {
            anim.SetBool("isFlying", false);
            anim.SetBool("isDigging", false);
            anim.SetBool("isFiring", true);
        }
        else
        {
            anim.SetBool("isFlying", false);
            anim.SetBool("isDigging", false);
            anim.SetBool("isFiring", false);
        }
    }

        // Update is called once per frame
   //     void Update () {
   //     float xTranslation = Input.GetAxis("Horizontal") * baseSpeed;
  //      float yTranslation = Input.GetAxis("Vertical") * baseSpeed;
 ////       transform.Translate(xTranslation, yTranslation, 0);
   // }
}
