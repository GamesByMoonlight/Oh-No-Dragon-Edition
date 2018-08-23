using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimated : MonoBehaviour {

    public float baseSpeed;
    private Rigidbody2D playerRigidBody;


    // To track movement from input
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;

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
