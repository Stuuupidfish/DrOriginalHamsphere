using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlyingEnemy : AIChase 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
        double angle = (float)Math.Atan(getDirection().y / getDirection().x);
        bool right = transform.position.x < player.transform.position.x;
       // Debug.Log(getDetection() + " subclass");
        if (getDetection() == true)
        {
            setIsPacing(false);
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (GetComponent<TestEnemy>().changeVel <= 0)
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(angle) * speed * (right ? 1 : -1), (float)Math.Sin(angle) * speed * (right ? 1 : -1)); //alternate pathfinding method
            }
        }
        else 
        {
            if (getIsPacing() == false)
            {
                updateIdleCenter();
            }
            setIsPacing(true);
            idleMovement1();
        }

    }
}
