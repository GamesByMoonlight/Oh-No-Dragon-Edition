using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour {

    public float mobSpeed = 10;
    public UICounter counter;

    public PlayerMovementAnimated player;

	// Update is called once per frame
	void Update () {
        Vector2 newPosition = transform.position;

        newPosition.x += mobSpeed * Time.deltaTime;

        transform.position = newPosition;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            EventManager.TriggerPlayerDeath();
            
        }
    }
}
