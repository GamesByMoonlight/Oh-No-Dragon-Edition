using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManaField : MonoBehaviour {

    Mana DragonMana;
    public DragonType.eDragonType ThisDragonType;
    public SpriteRenderer OnFireSprite;
	// Use this for initialization
	void Start () {
        DragonMana = GetComponentInParent<Mana>();
        OnFireSprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float pctFull = DragonMana.GetMana(ThisDragonType);
        float Offset = -1.4f + pctFull * 1.4f;
        transform.localPosition = new Vector3(0, Offset, 0);
        if (pctFull >= 1)
        {
            OnFireSprite.enabled = true;
        }
        else
        {
            OnFireSprite.enabled = false;
        }

    }
}
