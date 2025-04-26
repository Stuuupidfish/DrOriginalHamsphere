using System.Collections;
using System.Collections.Generic;
using System;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
//using System.Threading;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    private bool detected;
    private Vector2 direction; 
    private float idleCenter;
    private bool movingRight;
    private float paceRange = 2f;
    private  bool isPacing;

    // Start is called before the first frame update
    void Start()
    {
        idleCenter = transform.position.x;
    }

    // Update is called once per frame
    //I REMOVED UPDATE HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    //im trying stuff ok
    public void detectPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        
        if (distance < 5)
        {
            detected = true;
        }
        else
        {
            detected = false;
        }

        //Debug.Log(getDetection() + " masterclass");
    }
    public bool getDetection()
    {
        return detected;
    }
    public Vector2 getDirection()
    {
        return direction;
    }
    public void idleMovement1()
    {
        if (movingRight)
        {
            // Move right
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            
            // If the enemy reaches the maximum range, change direction
            if (transform.position.x >= idleCenter + paceRange)
            {
                movingRight = false;  // Change direction to left
            }
        }
        else
        {
            // Move left
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            
            // If the enemy reaches the minimum range, change direction
            if (transform.position.x <= idleCenter - paceRange)
            {
                movingRight = true;  // Change direction to right
            }
        }
    }
    public void updateIdleCenter()
    {
        idleCenter = transform.position.x;
    }
    public void setIsPacing(bool pace)
    {
        isPacing = pace;
    }
    public bool getIsPacing()
    {
        return isPacing;
    }
}
