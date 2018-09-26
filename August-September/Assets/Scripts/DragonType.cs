using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonType : MonoBehaviour
{
    public enum eDragonType { AirDragon, WaterDragon, FireDragon, EarthDragon };
    public GameObject poof;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool switchAvailable = true;

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
        spriteRenderer.enabled = true;
        ChangeDragonColor();
    }

     void Update()
    {
        if (switchAvailable)
        {
            
            if (Input.GetButtonDown("SwitchToAirDragon") && DragonTypeV != eDragonType.AirDragon)
            {
                DragonTypeV = eDragonType.AirDragon;
                ChangeDragonColor();
                PauseSwitching();
            }
            if (Input.GetButtonDown("SwitchToWaterDragon") && DragonTypeV != eDragonType.WaterDragon)
            {
                DragonTypeV = eDragonType.WaterDragon;
                ChangeDragonColor();
                PauseSwitching();
            }

            if (Input.GetButtonDown("SwitchToFireDragon") && DragonTypeV != eDragonType.FireDragon)
            {
                
                DragonTypeV = eDragonType.FireDragon;
                ChangeDragonColor();
                PauseSwitching();

            }

            if (Input.GetButtonDown("SwitchToEarthDragon") && DragonTypeV != eDragonType.EarthDragon)
            {
                DragonTypeV = eDragonType.EarthDragon;
                ChangeDragonColor();
                PauseSwitching();
            }
        }
    }

    public void ClearSprite()
    {
        spriteRenderer.enabled = false;
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

        MakePuff();
        
    }

    public void PlayAnimation()
    {
        
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

    private void PauseSwitching()
    {
        switchAvailable = false;
        Invoke("SwitchingOk", 0.65f);
    }

    private void MakePuff()
    {
        GameObject puff = Instantiate(poof, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
        ParticleSystem particles = puff.GetComponent<ParticleSystem>();

        var color = particles.colorOverLifetime;

        Gradient particleColorGradient = new Gradient();
        particleColorGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(spriteRenderer.color, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0f, 1.5f) });

        color.color = particleColorGradient;
    }

    private void SwitchingOk()
    {
        switchAvailable = true;
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

    public void TriggerSuperPower()
    {

        Debug.Log(" SUPER POWERRRRRRRRRRRRRRRRRRRRRRR");
    }

}

