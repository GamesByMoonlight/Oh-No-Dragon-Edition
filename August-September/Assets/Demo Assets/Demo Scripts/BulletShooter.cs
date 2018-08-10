using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [Tooltip("Prefab of the bullet to fire")]
    public GameObject bullet;
    [Tooltip("Shoots every X seconds")]
    public float fireRate;
    [Tooltip("Speed that the shot bullet moves")]
    public float bulletSpeed;
    
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("LaunchProjectile", fireRate, fireRate);
	}
	
	// Update is called once per frame
	void LaunchProjectile()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();

        if (bulletRB == null)
        {
            Destroy(newBullet);
            Debug.LogError("Instantiated bullets must have a RigidBody2D component");
            return;
        }

        // This sets the bullet to be childed to the turret that created it
        // It is not necessary, but keeps the heirarchy clean
        newBullet.transform.parent = transform.root;

        // Give the bullet a speed (which is why we need the Rigidbody2D, so the engine can simulate the physics)
        // I did the math wrong, so the bullets go backwards unless you use the inverse of bulletSpeed
        bulletRB.velocity = new Vector2(transform.parent.position.x - transform.position.x, 
                                        transform.parent.position.y - transform.position.y).normalized * (-bulletSpeed);
	}
}
