using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision triggered");
        if (col.GetComponent<PlayerMovementAnimated>()){
            FindObjectOfType<EventManager>().TriggerLevelEnd();
        }
    }
}
