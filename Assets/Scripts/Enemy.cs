using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    Gun[] guns;

    // Start is called before the first frame update
    void Start()
    {
        // A gun is a child of the ship, so we can find all of the gun components
        // and add them to the Guns Array
        guns = GetComponentsInChildren<Gun>();
        //guns[0].autoShoot = true;
        Debug.Log("I'm in the Enemy Start() Method\n");
        Debug.Log($"Enemy autoshoot = {guns[0].autoShoot}");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
