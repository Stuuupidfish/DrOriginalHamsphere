using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : AIChase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
        if (getDetection() == true)
        {
            setIsPacing(false);
            bool right = transform.position.x < player.transform.position.x;
            if (GetComponent<TestEnemy>().changeVel <= 0) { 
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (right ? 1 : -1), 0); //alternate pathfinding method
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
