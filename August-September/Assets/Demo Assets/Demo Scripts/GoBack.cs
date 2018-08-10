using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Back"))
        {
            SceneManager.LoadScene(0);
        }
	}
}
