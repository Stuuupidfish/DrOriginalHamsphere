using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : AIChase
{
    // Start is called before the first frame update
    private bool isGrounded;
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
        if (getDetection() == true )
        {
            setIsPacing(false);
            if (isGrounded)
            {
                bool right = transform.position.x < player.transform.position.x;
                if (GetComponent<TestEnemy>().changeVel <= 0)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (right ? 1 : -1), transform.GetComponent<Rigidbody2D>().velocity.y); //alternate pathfinding method
                }
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "ground") {

            isGrounded = true;
            //Debug.Log("grounded enemy");
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            isGrounded = false;
            //D//ebug.Log("Ungrounded enemy");
        }
    }
    
}
