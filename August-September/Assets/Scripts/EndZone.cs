using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovementAnimated>()){
            EventManager.TriggerLevelEnd();
        }
    }

    public void TurnOnFireParticles()
    {
        BroadcastMessage("PlayFireParticles");
    }
}
