using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonType : MonoBehaviour
{
    public enum eDragonType { AirDragon, WaterDragon, FireDragon, EarthDragon };


    private eDragonType _DragonType;

    public eDragonType DragonTypeV
    {
        get { return _DragonType; }
        set { _DragonType = value; }
    }

     void Update()
    {
        
        if (Input.GetButtonDown("SwitchToAirDragon"))
        {
            DragonTypeV = eDragonType.AirDragon;
        }
        if (Input.GetButtonDown("SwitchToWaterDragon"))
        {
            DragonTypeV = eDragonType.WaterDragon;
        }

        if (Input.GetButtonDown("SwitchToFireDragon"))
        {
            DragonTypeV = eDragonType.FireDragon;
        }

        if (Input.GetButtonDown("SwitchToEarthDragon"))
        {
            DragonTypeV = eDragonType.EarthDragon;
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

