using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
        // if direction is = to 0 then we know that the player is not currently dashing 
		if(direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow)){
                if (Input.GetKey(KeyCode.A)){
                    direction = 1;
                }
            } else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    direction = 2;
                }
            }else if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    direction = 3;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    direction = 4;
                }
            }

        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
	}
}
