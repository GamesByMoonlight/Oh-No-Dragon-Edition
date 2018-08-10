using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
    {
        col.GetComponent<Canvas>().enabled = true;
    }
}
