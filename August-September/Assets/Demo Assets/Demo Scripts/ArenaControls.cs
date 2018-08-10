using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaControls : MonoBehaviour {

    public int playerNumber;
    public float baseSpeed;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            float xForce = Input.GetAxis("Horizontal") * baseSpeed;
            float yForce = Input.GetAxis("Vertical") * baseSpeed;
            Vector2 impulse = new Vector2(xForce, yForce);
            if (impulse.magnitude > 0)
                Debug.Log("Moving P1");
            myRigidBody.AddForce(impulse);

            if (Input.GetButton("LStickClick"))
            {
                myRigidBody.AddForce(impulse * 10);
            }
            
        }

        if (playerNumber == 2)
        {
            float xForce = Input.GetAxis("RHorizontal") * baseSpeed;
            float yForce = Input.GetAxis("RVertical") * baseSpeed;
            Vector2 impulse = new Vector2(xForce, yForce);
            if (impulse.magnitude > 0)
                Debug.Log("Moving P2");
            myRigidBody.AddForce(impulse);

            if (Input.GetButton("RStickClick"))
            {
                myRigidBody.AddForce(impulse * 10);
            }

        }

    }

}
