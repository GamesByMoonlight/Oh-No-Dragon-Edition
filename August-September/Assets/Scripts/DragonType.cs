using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonType : MonoBehaviour
{
    public enum eDragonType { AirDragon, WaterDragon, FireDragon, EarthDragon };

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private eDragonType _DragonType;

    public eDragonType DragonTypeV
    {
        get { return _DragonType; }
        set { _DragonType = value; }
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ChangeDragonColor();
    }

     void Update()
    {
        
        if (Input.GetButtonDown("SwitchToAirDragon"))
        {
            DragonTypeV = eDragonType.AirDragon;
            ChangeDragonColor();
        }
        if (Input.GetButtonDown("SwitchToWaterDragon"))
        {
            DragonTypeV = eDragonType.WaterDragon;
            ChangeDragonColor();
        }

        if (Input.GetButtonDown("SwitchToFireDragon"))
        {
            DragonTypeV = eDragonType.FireDragon;
            ChangeDragonColor();
        }

        if (Input.GetButtonDown("SwitchToEarthDragon"))
        {
            DragonTypeV = eDragonType.EarthDragon;
            ChangeDragonColor();
        }

    }

    private void ChangeDragonColor()
    {
        switch (DragonTypeV)
        {
            case eDragonType.AirDragon:
                spriteRenderer.color = Color.yellow;
                break;
            case eDragonType.EarthDragon:
                spriteRenderer.color = Color.green;
                break;
            case eDragonType.FireDragon:
                spriteRenderer.color = Color.red;
                break;
            case eDragonType.WaterDragon:
                spriteRenderer.color = Color.blue;
                break;
        }
    }

    public void PlayAnimation()
    {
        Debug.Log("PlayAnimation");
        switch (DragonTypeV)
        {
            case eDragonType.AirDragon:
                anim.SetTrigger("Air");
                break;
            case eDragonType.EarthDragon:
            case eDragonType.WaterDragon:
                anim.SetTrigger("Water");
                break;
            case eDragonType.FireDragon:
                anim.SetTrigger("Fire");
                break;
        }
    }
    //DragonType.eDragonType d;

    //d = DragonType.eDragonType.AirDragon;

    //    switch (d)
    //    {
    //        case DragonType.eDragonType.AirDragon:
    //        {
    //                break;

    //        }
    //    }
}

