using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour {

    private float SuperPowers;
    private DragonType eDragonType;
    private Mana mana;
    private void Start()
    {
        mana = FindObjectOfType<Mana>();
        eDragonType = FindObjectOfType<DragonType>();

    }

    // Update is called once per frame
    void Update () {
        SuperPowers = Input.GetAxis("SuperPower");
        if(SuperPowers>0)
        {
            if (mana.AllDragonsFull)
            {
                eDragonType.TriggerSuperPower();
            }
        }

    }
}
