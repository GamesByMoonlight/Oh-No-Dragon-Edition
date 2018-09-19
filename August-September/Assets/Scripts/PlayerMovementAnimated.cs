using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;

public class PlayerMovementAnimated : MonoBehaviour {

    [SerializeField]
    public AudioSource audioS;


    //bones, body parts, remains.
    public GameObject Splatter;

    public float baseSpeed;
    public float animBaseSpeed;
    private Rigidbody2D playerRigidBody;
    
    //Can player move? If he is dead, he can not.
    private bool canMove;

    // To track movement from input
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;
    Tilemap tm;
    public float frameCount = 0;
    public int count = 0;
    

    //Added animator to script
    Animator anim;

    DragonType dragonType;

    Mana manaScript;

    void GetPlayerInput()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal :"+movePlayerHorizontal);
        //Debug.Log("Horizontal :" + movePlayerVertical);

    }

    // Use this for initialization
    void Awake()
    {
        //defines animator
        anim = GetComponentInChildren<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        tm = GameObject.FindGameObjectWithTag("Tiles").GetComponent<Tilemap>();
        dragonType = GetComponent<DragonType>();
        manaScript = FindObjectOfType<Mana>();
        canMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        
        movement = new Vector2(movePlayerHorizontal, movePlayerVertical);

        // Move Character if character is alive
        if(canMove)
            playerRigidBody.velocity = movement * baseSpeed;
        else
            playerRigidBody.velocity = new Vector2(0,0);

        //returns value to animator. when animBaseSpeed is greater than 0.25 animation changes from idle to walking
        anim.SetFloat ("animBaseSpeed", Mathf.Abs(movePlayerHorizontal) + Mathf.Abs(movePlayerVertical));
        //Debug.Log(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position));
        ////Debug.Log(tm.GetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position)));
        // tm.SetTile(tm.layoutGrid.WorldToCell(playerRigidBody.transform.position), tm.GetTile(new Vector3Int(-2,-3,0)));

        /*
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
        */
        //SetAnimation();

    }

    /*private void PlayFootSteps()
    {
        if(movePlayerHorizontal > 0.1f || animBaseSpeed > 0.1f)
        {
            audioS.enabled = true;
            audioS.loop = true;
        }
        if(movePlayerHorizontal < 0.1f && movePlayerVertical < 0.1f)
        {
            audioS.enabled = false;
            audioS.loop = false;
        }
    }
    */

    // Update is called once per frame
    //     void Update () {
    //     float xTranslation = Input.GetAxis("Horizontal") * baseSpeed;
    //      float yTranslation = Input.GetAxis("Vertical") * baseSpeed;
    ////       transform.Translate(xTranslation, yTranslation, 0);
    // }




    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Made contact with a tile");
      
        if (movePlayerHorizontal>0 && (movePlayerHorizontal > Mathf.Abs(movePlayerVertical) || movePlayerHorizontal == movePlayerVertical))
        {
            if(movePlayerHorizontal == movePlayerVertical)
            {
                //Debug.Log("Moving in the positive x direction");
                foreach (ContactPoint2D Smash in collision.contacts)
                {
                    //Debug.Log("In loop");
                    Vector3 Smashpoint = new Vector3(Smash.point.x + 1, Smash.point.y+1, 0);
                    


                    if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                    {
                        tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);

                    }

                }
            }
            else
            {
                //Debug.Log("Moving in the positive x direction");
                foreach (ContactPoint2D Smash in collision.contacts)
                {
                    //Debug.Log("In loop");
                    Vector3 Smashpoint = new Vector3(Smash.point.x + 1, Smash.point.y, 0);
                    
 
                    if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                    {
                        tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);

                    }
                }
            }
            return; 
        }else if (movePlayerHorizontal < 0 && (movePlayerHorizontal < Mathf.Abs(movePlayerVertical) || movePlayerHorizontal == movePlayerVertical))
        {
            if (movePlayerHorizontal == movePlayerVertical)
            {
                //Debug.Log("Moving in the negative x direction");
                foreach (ContactPoint2D Smash in collision.contacts)
                {
                    //Debug.Log("In loop");
                    Vector3 Smashpoint = new Vector3(Smash.point.x - 1, Smash.point.y -1, 0);
                    
                    if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                    {
                        tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);
                    }
                }
            }
            else
            {
                //Debug.Log("Moving in the negative x direction");
                foreach (ContactPoint2D Smash in collision.contacts)
                {
                    //Debug.Log("In loop");
                    Vector3 Smashpoint = new Vector3(Smash.point.x - 1, Smash.point.y, 0);
                    if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                    {
                        tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);

                    }
                }
            }
            return;
        }else if (movePlayerVertical < 0 && movePlayerVertical < Mathf.Abs(movePlayerHorizontal))
        {
            //Debug.Log("Moving in the negative y direction");
            foreach (ContactPoint2D Smash in collision.contacts)
            {
                //Debug.Log("In loop");
                Vector3 Smashpoint = new Vector3(Smash.point.x, Smash.point.y - 1, 0);
                
                if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                {
                    tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);

                }
            }
            return;
        }
        if (movePlayerVertical > 0 && movePlayerVertical > Mathf.Abs(movePlayerHorizontal))
        {
            //Debug.Log("Moving in the positive y direction");
            foreach (ContactPoint2D Smash in collision.contacts)
            {
                //Debug.Log("In loop");
                Vector3 Smashpoint = new Vector3(Smash.point.x, Smash.point.y+1, 0);
                
                if (DragonValidator(tm.GetTile(tm.layoutGrid.WorldToCell(Smashpoint))))
                {
                    tm.SetTile(tm.layoutGrid.WorldToCell(Smashpoint), null);

                }
            }
            return;
        }

    }

    //death sequence starts death animation, stops player from moving, and calls DestroyMe
    public void ImDying()
    {
        canMove = false;
        anim.SetTrigger("Death");
        StartCoroutine("DestroyMe");
    }

    //After death animation this disables sprite renderer and calls TriggerLevelEnd
    //needs to be modified to restart level instead of advancing to next
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1.2f);
        dragonType.ClearSprite();
        GameObject mySplatter = Instantiate(Splatter, transform.position, Quaternion.identity) as GameObject;
        FindObjectOfType<EventManager>().TriggerLevelEnd();
    }
    private bool DragonValidator(TileBase crashingTile)
    {
        if (crashingTile == null)
        {
            return false;
        }


        DragonType.eDragonType d;

        d = dragonType.DragonTypeV;

        switch (d)
        {
            
            case  DragonType.eDragonType.EarthDragon:
                {
                    if(crashingTile.name == "rockTile 1" | crashingTile.name == "rockTile")
                    {
                        dragonType.PlayAnimation();
                        DragonPowerUp(d);
                        return true;
                    }
                    break;
                }
            case DragonType.eDragonType.AirDragon:
                {
                    if (crashingTile.name == "singleSpikeTile" |
                        crashingTile.name == "centerSpikeTile" |
                        crashingTile.name == "leftSpikeTile" | 
                        crashingTile.name == "rightSpikeTile" |
                        crashingTile.name == "holeTile_single")
                    {
                        dragonType.PlayAnimation();
                        DragonPowerUp(d);
                        return true;
                    }
                    break;
                }
            case DragonType.eDragonType.WaterDragon:
                {
                    if (crashingTile.name == "horzwater" |
                        crashingTile.name == "vertWater" |
                        crashingTile.name == "waterBottom" |
                        crashingTile.name == "waterLeft" |
                        crashingTile.name == "waterRight" |
                        crashingTile.name == "waterTop" |
                        crashingTile.name == "elbowWater1" |
                        crashingTile.name == "elbowWater2" |
                        crashingTile.name == "elbowWater3" |
                        crashingTile.name == "elbowWater4" |
                        crashingTile.name == "TilesetExample_13" ) 
                    {
                        dragonType.PlayAnimation();
                        DragonPowerUp(d);
                        return true;
                    }
                    break;
                }
            case DragonType.eDragonType.FireDragon:
                {
                    if (crashingTile.name == "treeTile 1" |
                        crashingTile.name == "treeTile")
                    {
                        dragonType.PlayAnimation();
                        DragonPowerUp(d);
                        return true;
                    }
                    break;
                }

        }

        return false;
    }

    public delegate void AddManaEventHandler(DragonType.eDragonType dragonType);
    public event AddManaEventHandler ManaAdded;
    
    void DragonPowerUp(DragonType.eDragonType dragonType)
    {
        if (ManaAdded != null)
        {
            ManaAdded(dragonType);
        }
    }

}
