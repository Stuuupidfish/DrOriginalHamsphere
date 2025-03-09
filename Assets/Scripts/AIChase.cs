using System.Collections;
using System.Collections.Generic;
using System;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    private bool detected;
    private Vector2 direction; 
    // Start is called before the first frame update
    void Start()
    {
        
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

        Debug.Log(getDetection() + " masterclass");
    }
    public bool getDetection()
    {
        return detected;
    }
    public Vector2 getDirection()
    {
        return direction;
    }
}
