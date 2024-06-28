using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSineWave : Enemy
{
    float sinCenterY;
    public float amplitude = 2f;
    public float frequency = 0.5f;
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // This input the x position into f(x) = Asin(Bx) to get the height, or, f(x).
        float sinHeight = amplitude * Mathf.Sin(frequency * pos.x);

        if (inverted)
        {
            sinHeight *= -1;
        }

        // And now we have f(x) = Asin(Bx) + C
        pos.y = sinHeight + sinCenterY;

        transform.position = pos;
    }
}
