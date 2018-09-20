using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour {

    public int lives { get; set; }
    public Text playerLives;

    // Use this for initialization
    void Start () {
        lives = 3;
        playerLives.color = Color.blue;
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerLives.text =  lives.ToString();
    }

    public void removeLife()
    {
        lives -= lives;
        playerLives.text =  lives.ToString();

    }



}
