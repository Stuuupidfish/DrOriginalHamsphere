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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        // double angle = (float)Math.Atan(direction.y / direction.x);

        if (distance < 5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            // transform.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed); alternate pathfinding method
        }


    }
}
