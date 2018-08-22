using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float baseSpeed;
    private Rigidbody2D playerRigidBody;


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
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        movement = new Vector2(movePlayerHorizontal, movePlayerVertical);

        // Move Character
        playerRigidBody.velocity = movement * baseSpeed;

    }

        // Update is called once per frame
   //     void Update () {
   //     float xTranslation = Input.GetAxis("Horizontal") * baseSpeed;
  //      float yTranslation = Input.GetAxis("Vertical") * baseSpeed;
 ////       transform.Translate(xTranslation, yTranslation, 0);
   // }
}
