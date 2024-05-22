using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;
    //private float speed = 17f;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // This direction used, is the directon assigned in the Gun.cs script in the
        // Shoot() method
        velocity = direction * speed;
        //Debug.Log($" Update: x = {velocity.x}, y = {velocity.y}");
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        //Debug.Log($"Start Fixed: x = {pos.x}, y = {pos.y}");
        pos += velocity * Time.fixedDeltaTime;
        //Debug.Log($"End Fixed: x = {pos.x}, y = {pos.y}");
        transform.position = pos;
    }
}
