using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("collider triggered"); //debug to test where it is working
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("they touched!"); //debug to test where it is working
			Died(); //This function can later be changed to a function that displays a score/retry screen
		}
	}

	void Died()
	{
		SceneManager.LoadScene("01_1_Level 1"); //restarts only to 1st level, might have to update to restart to checkpoint or next level
	}
}
