using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMana : MonoBehaviour {

    Mana DragonManaTest;

	// Use this for initialization
	void Start () {
        DragonManaTest = GetComponentInParent<Mana>();

    }

    public int returnMana;
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown("z"))
        {
           //returnMana =  DragonManaTest.SetMana(DragonType.eDragonType.AirDragon, 20);

     
            DragonManaTest.ResetAllMana();
       
        }


    }
}
