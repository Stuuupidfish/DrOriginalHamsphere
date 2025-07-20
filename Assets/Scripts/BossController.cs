using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // make variables for states
    public int phase;
    int speed;
    int health;
    public GameObject player;
    BossMachine machine;
    // Start is called before the first frame update
    void Start()
    {
        machine = new BossMachine(this);
        health = 200;
        phase = 1;
        machine.Init(machine.bossIdle);
    }

    public void updateVel(int speed)
    {
        Vector2 direction = player.transform.position - transform.position;
        double angle = (float)Math.Atan(direction.y / direction.x);
        bool right = transform.position.x < player.transform.position.x;
        // Debug.Log(getDetection() + " subclass");
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(angle) * speed * (right ? 1 : -1), (float)Math.Sin(angle) * speed * (right ? 1 : -1)); //alternate pathfinding method

    }

    // Update is called once per frame
    void Update()
    {
        machine.Update();
    }
}
