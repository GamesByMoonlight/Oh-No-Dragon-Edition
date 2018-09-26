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

    public GameObject[] DestroyedTileParticles;

    public float baseSpeed;
    public float animBaseSpeed;
    private Rigidbody2D playerRigidBody;
    
    //Can player move? If he is dead, he can not.
    public static bool canMove;

    // To track movement from input
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;
    Tilemap tm;
    public float frameCount = 0;
    public int count = 0;
    
        
    Animator anim;
    DragonType dragonType;

    void Awake()
    {
        //defines animator
        anim = GetComponentInChildren<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        tm = GameObject.FindGameObjectWithTag("Tiles").GetComponent<Tilemap>();
        dragonType = GetComponent<DragonType>();
        canMove = true;
        
    }

    void Update()
    {

        if (canMove)
        {
            playerRigidBody.velocity = new Vector2(0, 0);
            GetPlayerInput();
            movement = new Vector2(movePlayerHorizontal, movePlayerVertical);
            playerRigidBody.velocity = movement * baseSpeed;
        }            
        
            

        //returns value to animator. when animBaseSpeed is greater than 0.25 animation changes from idle to walking
        anim.SetFloat("animBaseSpeed", playerRigidBody.velocity.magnitude);

    }

    void GetPlayerInput()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
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
                        CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
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
                        CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
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
                        CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
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
                        CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
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
                    CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
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
                    CreateParticles(tm.layoutGrid.CellToWorld(tm.layoutGrid.WorldToCell(Smashpoint)));
                }
            }
            return;
        }

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

            case DragonType.eDragonType.EarthDragon:
                {
                    if (crashingTile.name == "rockTile 1" | crashingTile.name == "rockTile")
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
                        crashingTile.name == "TilesetExample_13")
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
            case DragonType.eDragonType.SuperDragon:
                {
                    dragonType.PlayAnimation();
                    return true;
                }

        }

        return false;
    }

    //death sequence starts death animation, stops player from moving, and calls DestroyMe
    public void ImDying()
    {
        canMove = false;
        playerRigidBody.velocity = new Vector2(0, 0);
        anim.SetTrigger("Death");
        StartCoroutine("DestroyMe");
    }

    void EndLevelRoutine()
    {
        canMove = false;

        Vector2 currentPosition = transform.position;
        Vector2 endPosition = new Vector2(currentPosition.x + 5.5f, -3.5f); // This finds a position roughly behind mama dragon

        playerRigidBody.isKinematic = true;
        playerRigidBody.velocity = endPosition - currentPosition;  // It just kind of pushes itself that direction

        StartCoroutine(EndOfAutomatedMovement());
    }

    IEnumerator EndOfAutomatedMovement()
    {
        yield return new WaitForSeconds(1.2f);
        playerRigidBody.velocity = new Vector2(0f, 0f);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    //After death animation this disables sprite renderer and calls TriggerLevelEnd
    
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1.2f);
        dragonType.ClearSprite();
        Instantiate(Splatter, transform.position, Quaternion.identity);
    }

    


    void CreateParticles(Vector3 locationOfEffect)
    {
        locationOfEffect += new Vector3(0.5f, 0.5f, 0f);

        switch (dragonType.DragonTypeV)
            {
            case DragonType.eDragonType.FireDragon:
                Instantiate(DestroyedTileParticles[0], locationOfEffect, Quaternion.identity);
                break;
            case DragonType.eDragonType.WaterDragon:
                Instantiate(DestroyedTileParticles[2], locationOfEffect, Quaternion.identity);
                break;
            case DragonType.eDragonType.EarthDragon:
                Instantiate(DestroyedTileParticles[1], locationOfEffect, Quaternion.identity);
                break;
        }
        


        return;
    }


    public delegate void AddManaEventHandler(DragonType.eDragonType dragonType);
    public event AddManaEventHandler ManaAdded;
    ScoreKeeper sk;


    void DragonPowerUp(DragonType.eDragonType dragonType)
    {
        if (ManaAdded != null)
        {
            
            ManaAdded(dragonType);
            sk = FindObjectOfType<ScoreKeeper>();
            if (sk != null)
                sk.AddScore();
            else
                Debug.LogWarning("Scorekeeper object missing, cannot add score.");
        }
    }

    void OnEnable()
    {
        EventManager.OnPlayerDeath += ImDying;
        EventManager.OnLevelEnd += EndLevelRoutine;
    }

    void OnDisable()
    {
        EventManager.OnPlayerDeath -= ImDying;
        EventManager.OnLevelEnd -= EndLevelRoutine;
    }

}
