using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonType : MonoBehaviour
{
    public enum eDragonType { AirDragon, WaterDragon, FireDragon, EarthDragon, SuperDragon };
    public GameObject poof;

    public float superPowerDuration = 5f;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public bool switchAvailable = true;


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
        if (switchAvailable && PlayerMovementAnimated.canMove)
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
            case
                eDragonType.SuperDragon:
                spriteRenderer.color = Color.white;
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
            case eDragonType.SuperDragon:
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

    public void TriggerSuperPower()
    {
        eDragonType dragonBeforeSuperPower = DragonTypeV;

        DragonTypeV = eDragonType.SuperDragon;
        ChangeDragonColor();

        switchAvailable = false;
        StartCoroutine(SuperPowerOver(dragonBeforeSuperPower));
    }

    IEnumerator SuperPowerOver(eDragonType dragonBeforeSuper)
    {
        yield return new WaitForSeconds(superPowerDuration);
        DragonTypeV = dragonBeforeSuper;
        ChangeDragonColor();
        SwitchingOk();
        EventManager.TriggerManaReset();
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

