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

    [SerializeField]
    private float ManaToAdd;

    public bool AllDragonsFull { get { return (ManaRed == ManaRedMax && ManaYellow == ManaYellowMax && ManaBlue == ManaBlueMax && ManaGreen == ManaGreenMax); } }

    void OnEnable()
    {
        FindObjectOfType<PlayerMovementAnimated>().ManaAdded += AddMana;
    }

    void OnDisable()
    {
        PlayerMovementAnimated player = FindObjectOfType<PlayerMovementAnimated>();
        if (player)
        {
            player.ManaAdded -= AddMana;
        }
    }

    //public float ManaRedBarL; // bar length
    //public float ManaBlueBarL;
    //public float ManaGreenBarL;
    //public float ManaYellowBarL;
    //
    //public float ManaRedBarP;  //percentage of Mana 
    //public float ManaBlueBarP;
    //public float ManaGreenBarP;
    //public float ManaYellowBarP;


    public void ResetAllMana()
    {   
        ManaRed =0;
        ManaBlue =0;
        ManaGreen=0;
        ManaYellow=0;
    }

    public void AddMana(DragonType.eDragonType dragonType)
    {
        
        switch (dragonType)
        {
            case DragonType.eDragonType.AirDragon:    
                ManaYellow += ManaToAdd;
                ManaYellow = Mathf.Clamp(ManaYellow, 0f, ManaYellowMax);
                return;         
            case DragonType.eDragonType.EarthDragon:
                ManaGreen += ManaToAdd;
                ManaGreen = Mathf.Clamp(ManaGreen, 0f, ManaGreenMax);
                return ;      
            case DragonType.eDragonType.FireDragon:
                ManaRed += ManaToAdd;
                ManaRed = Mathf.Clamp(ManaRed, 0f, ManaRedMax);
                return ;
            case DragonType.eDragonType.WaterDragon:
                ManaBlue += ManaToAdd;
                ManaBlue = Mathf.Clamp(ManaBlue, 0f, ManaBlueMax);
                return;
        }

        return;
    }


    public float GetMana(DragonType.eDragonType dragonType)
    {
        float pct=0;

        switch (dragonType)
        {
            case DragonType.eDragonType.AirDragon:
                pct = Mathf.Clamp((ManaYellow / ManaYellowMax) * 100, 0, 100);
                break;
            case DragonType.eDragonType.EarthDragon:
                pct = pct = Mathf.Clamp((ManaGreen / ManaGreenMax) * 100, 0, 100);
                break;
            case DragonType.eDragonType.FireDragon:
                pct = Mathf.Clamp((ManaRed / ManaRedMax) * 100, 0, 100);
                break;
            case DragonType.eDragonType.WaterDragon:
                pct = Mathf.Clamp((ManaBlue / ManaBlueMax) * 100, 0, 100);
                break;
        }
        return pct;
    }

    
}
