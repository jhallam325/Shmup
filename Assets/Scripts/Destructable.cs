using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    private bool canBeDestroyed = false; // wait until x pos = 15

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 15f)
        {
            canBeDestroyed = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            // Add points here?
        }
    }
}
