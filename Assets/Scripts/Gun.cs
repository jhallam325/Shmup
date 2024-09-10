using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Changed every BulletType1 to Bullet, a new base class
    public Bullet bullet;
    Vector2 direction;

    // why can't I call
    // Gun guns = GetComponentsInChildren<Gun>();
    // guns[0].autoShoot in the Enemy.cs script?
    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;

    // The gun will wait x seconds to start autoshooting
    public float shootDelaySeconds = 0.0f;

    float shootTimer = 0.0f;
    float delayTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // All of this is in the update method now, but I don't see why so I'm leaving it here.
        // This takes your gun's direction, and multiplies it by a right vector, so there is 
        // only direction in the x direction, and normalizes it, so it's size is 1 pointing 
        // in the x direction with respect to it's rotation. 
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoShoot)
        {
            // First we have to wait for the delay timer before we can begin to try and auto shoot
            if (delayTimer > shootDelaySeconds)
            {
                // Second, we now have a timer for how quickly these guys shoot.
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0.0f;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                // We haven't waited until it's time to shoot.
                // So, we increment the timer.
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject gameObject = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet gameObjectBullet = gameObject.GetComponent<Bullet>();
        gameObjectBullet.direction = direction;
    }
}
