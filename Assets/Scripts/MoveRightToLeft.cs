using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightToLeft : Enemy
{
    //public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started MoveRightToLeft Script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void FixedUpdate()
    //{
    //    Vector2 pos = transform.position;

    //    pos.x -= moveSpeed * Time.fixedDeltaTime;

    //    if (pos.x < -2)
    //    {
    //        Destroy(gameObject);
    //    }

    //    transform.position = pos;
    //}
}
