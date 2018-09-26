using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour {

    GameObject player;       //Public variable to store a reference to the player game object

    private Rigidbody2D rigidBody;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    bool followPlayer = true;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovementAnimated>().gameObject;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (followPlayer)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            //transform.position = player.transform.position + offset;
            Vector3 position;
            position.x = player.transform.position.x + offset.x;
            position.y = transform.position.y;
            position.z = transform.position.z;
            transform.position = position;
        }
        
    }


    void OnEnable()
    {
        EventManager.OnLevelEnd += StopFollowingPlayer;
    }

    void OnDisable()
    {
        EventManager.OnLevelEnd -= StopFollowingPlayer;
    }

    void StopFollowingPlayer()
    {
        followPlayer = false;

        rigidBody.velocity = new Vector2(-3f, 0f);
        Invoke("StopCamera", 1f);
    }

    void StopCamera()
    {
        rigidBody.velocity = Vector2.zero;
    }
}
