using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Changed every BulletType1 to Bullet, a new base class
    public Bullet bullet;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // This takes your gun's direction, and multiplies it by a right vector, so there is 
        // only direction in the x direction, and normalizes it, so it's size is 1 pointing 
        // in the x direction with respect to it's rotation. 
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject gameObject = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet gameObjectBullet = gameObject.GetComponent<Bullet>();
        gameObjectBullet.direction = direction;
    }
}
