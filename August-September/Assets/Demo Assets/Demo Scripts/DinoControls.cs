using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoControls : MonoBehaviour {

    // variables that can be adjusted from the editor to tweak gameplay
    public float baseSpeed = 0.05f;
    public float jumpPower = 5f;

    // We will need to modify the RigidBody2D on jump, so this prepares us to use it
    private Rigidbody2D myRigidBody2D;

    void Start()
    {
        // GetComponent<>() will return the component that is on the same level as the script.  
        // Other methods can be used to get components on children or parent objects.

        myRigidBody2D = GetComponent<Rigidbody2D>();

        // Verify that myRigidBody was found.  If not, log an error in the console.
        // If you want to test, you can go to the "Dino" object, click the gear next to "Rigidbody 2D" and remove it
        if (myRigidBody2D == null)
        {
            Debug.LogError("Failed to find Rigidbody2D");
        }

    }

    void Update()
    {
        // function to let player move left/right at a fixed speed.  Would be better done with acceleration and max speed mechanics
        float translation = Input.GetAxis("Horizontal") * baseSpeed;
        transform.Translate(translation, 0, 0);

        // Simple reaction to the jump button being pressed
        // It should check to make sure the player is on the ground first
        if (Input.GetButtonDown("Jump"))
        {
           

            if (myRigidBody2D != null)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpPower);
            }
        }

    }
	
}
