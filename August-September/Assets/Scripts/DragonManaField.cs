using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonManaField : MonoBehaviour {

    Mana DragonMana;
    public DragonType.eDragonType ThisDragonType;

    Image image;
    Color color;


	// Use this for initialization
	void Start () {
        DragonMana = GetComponentInParent<Mana>();
        image = GetComponent<Image>();
        color = image.color;
	}
	
	// Update is called once per frame
	void Update () {
        float pctFull = DragonMana.GetMana(ThisDragonType) / 100f;

        switch (ThisDragonType)
            {
            case DragonType.eDragonType.AirDragon:
            case DragonType.eDragonType.EarthDragon:
                transform.localScale = new Vector3(1f, pctFull, 1f);
                break;
                
            case DragonType.eDragonType.WaterDragon:
            case DragonType.eDragonType.FireDragon:
                transform.localScale = new Vector3(pctFull, 1f, 1f);
                break;
        }
        


        if (pctFull == 1)
        {
            color.a = Mathf.Abs(Mathf.Sin(Time.time * 1.65f));  // Trying to get the pulses to match up with the music!!
            image.color = color;
        }
        else
        {
            color.a = 255;
            image.color = color;
        }
        
    }
}
