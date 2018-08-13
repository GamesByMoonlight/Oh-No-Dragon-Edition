using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float jumpPower = 10.0f;
    public float movementSpeed = 1.0f;
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
	// Use this for initialization
	void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.AddForce(Vector2.left * (movementSpeed*2.5f));
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.AddForce(Vector2.right * movementSpeed *2.5f );
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
