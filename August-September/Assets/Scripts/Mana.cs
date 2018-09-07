using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float ManaRed;
    public float ManaBlue;
    public float ManaGreen;
    public float ManaYellow;

    public float ManaRedMax;
    public float ManaBlueMax;
    public float ManaGreenMax;
    public float ManaYellowMax;

    public float ManaRedBarL; // bar length
    public float ManaBlueBarL;
    public float ManaGreenBarL;
    public float ManaYellowBarL;

    public float ManaRedBarP;  //percentage of Mana 
    public float ManaBlueBarP;
    public float ManaGreenBarP;
    public float ManaYellowBarP;
    // Use this for initialization

    public void ResetAllMana()
    {   
         ManaRed =0;
        ManaBlue =0;
        ManaGreen=0;
        ManaYellow=0;
}

    public int SetMana(DragonType.eDragonType dragonType, int AddManaAmount)
    {
        // to Subtract mana use a negative integer
        int ReturnedManaTotal=0;

        switch (dragonType)
        {
            case DragonType.eDragonType.AirDragon:    
                    ManaYellow += AddManaAmount;
                    return (int)ManaYellow;         
            case DragonType.eDragonType.EarthDragon:
                ManaGreen += AddManaAmount;
                return (int)ManaGreen;      
            case DragonType.eDragonType.FireDragon:
                ManaRed += AddManaAmount;
                return (int)ManaRed;
            case DragonType.eDragonType.WaterDragon:
                ManaBlue += AddManaAmount;
                return (int)ManaBlue;
        }
        return ReturnedManaTotal;
    }


    public float GetMana(DragonType.eDragonType dragonType)
    {
        float pct=0;

        switch (dragonType)
        {
            case DragonType.eDragonType.AirDragon:
                pct = ManaYellowBarP;
                break;
            case DragonType.eDragonType.EarthDragon:
                pct = ManaGreenBarP;
                break;
            case DragonType.eDragonType.FireDragon:
                pct = ManaRedBarP;
                break;
            case DragonType.eDragonType.WaterDragon:
                pct = ManaBlueBarP;
                break;
        }
        return pct;
    }


    // Update is called once per frame
    void Update()
    {
        if (ManaRed <= ManaRedMax)
        {
            ManaRedBarP = ManaRed / ManaRedMax;
            ManaRedBarL = ManaRedBarP;
         }
        if (ManaBlue <= ManaBlueMax)
        {
            ManaBlueBarP = ManaBlue / ManaBlueMax;
            ManaBlueBarL = ManaBlueBarP * 100;
        }
        if (ManaGreen <= ManaGreenMax)
        {
            ManaGreenBarP = ManaGreen / ManaGreenMax;
            ManaGreenBarL = ManaGreenBarP * 100;
        }
        if (ManaYellow <= ManaYellowMax)
        {
            ManaYellowBarP = ManaYellow / ManaYellowMax;
            ManaYellowBarL = ManaYellowBarP * 100;
           // Debug.Log(  ManaYellowBarP);
        }

        if (ManaRed > ManaRedMax)
            ManaRed = ManaRedMax;
        if (ManaBlue > ManaBlueMax)
            ManaBlue = ManaBlueMax;
        if (ManaGreen > ManaGreenMax)
            ManaGreen = ManaGreenMax;
        if (ManaYellow > ManaYellowMax)
            ManaYellow = ManaYellowMax;

        if (ManaRed < 0)
            ManaRed = 0;
        if (ManaBlue < 0)
            ManaBlue = 0;
        if (ManaGreen < 0)
            ManaGreen = 0;
        if (ManaYellow < 0)
            ManaYellow = 0;


    }
}
