using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Rotate the object to always face the player.
///  It will point whatever is on the Z axis towards the player.  I think there's a way to do this better, but I couldn't find it.
///  This way *works*, so here it is.
/// </summary>

public class PlayerFinder : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {

        // In this case, the "Player" tag is used to find the player (instead of using a public reference)
        player = GameObject.FindGameObjectWithTag("Player");

        // Quick error catch
        if (player == null)
        {
            Debug.LogError("PlayerFinder.cs failed to find player");
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Secondary error catch to prevent null references
		if (player)
        {

            Vector3 playerDirection = player.transform.position - transform.position;

            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

            transform.rotation = newRotation;
        }
	}
}
