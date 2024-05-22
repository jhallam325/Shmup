using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Ship physics variables
    public float moveSpeed = 3f;
    public float moveSpeedFast = 3f;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;

    // Ship gun, each one fires one bullet
    Gun[] guns;
    bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        // A gun is a child of the ship, so we can find all of the gun components
        // and add them to the Guns Array
        guns = GetComponentsInChildren<Gun>();
        Debug.Log($" Start: Got all the guns loaded into the guns array");
    }

    // Update is called once per frame
    void Update()
    {
        // Add controller movements and maybe make it's own function
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        
        //Debug.Log($" Update: moveUp = {moveUp}");
        //Debug.Log($" Update: moveDown = {moveDown}");
        //Debug.Log($" Update: moveLeft = {moveLeft}");
        //Debug.Log($" Update: moveRight = {moveRight}");
        //Debug.Log($" Update: speedUp = {speedUp}");

        // Shooting controls
        shooting = (Input.GetKeyDown(KeyCode.Space) || 
                    Input.GetKeyDown(KeyCode.LeftControl) || 
                    Input.GetKeyDown(KeyCode.Mouse0));
        //Debug.Log($" Update: shooting = {shooting}");
        
        if (shooting)
        {
            // This will make you have to hit the button to shoot each bullet. Without declaring
            // shoot = false, then I could just hold down the button and continuously fire, which
            // is what I want for the mobile port.
            // This actually doesn't seem to do anything.
            shooting = false;

            // This calls each gun on the ship to fire a bullet. This is so we can have many bullets
            // fire at once.
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }
        
    }

    private void FixedUpdate()
    {
        
        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        float moveMagnitude;
        float ratio;
        Vector2 pos = transform.position;
        Vector2 move = Vector2.zero;

        //Debug.Log($"Start Fixed: x = {pos.x}, y = {pos.y}");
        if (speedUp)
        {
            moveAmount *= moveSpeedFast;// * moveAmount;
        }

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        // This gets the magnitude of the movement and if it is larger than how fast we should
        // be moving, I scale the movement to make sure that diagonal movements aren't any faster
        // than horizontal or vertical movement.
        // As an example, if I was moving 1 unit per second forward and 1 downward,
        // I would be moving sqrt(2) total in the diagonal direction. So, I scale that by multiplying
        // by 1/sqrt(2), the ratio if the speed (1) by the magnitude sqrt(2) and now my speed is 1, what
        // it should be.
        moveMagnitude = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2));
        if (moveMagnitude > moveAmount)
        {
            ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }


        pos += move;

        // set up a boundary that we can't cross programmatically instead of with collisions
        if (pos.x <= 1.5f)
        {
            pos.x = 1.5f;
        } 
        else if (pos.x >= 16f)
        {
            pos.x = 16f;
        }

        if (pos.y <= 0f)
        {
            pos.y = 0f;
        }
        else if (pos.y >= 10f)
        {
            pos.y = 10f;
        }

        transform.position = pos;
    }
}
