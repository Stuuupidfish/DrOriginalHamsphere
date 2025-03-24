using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public PlayerMachine machine;
    public int speed;
    public bool ground;
    public int jumpForce;
    public float jumpFrame = 0;

//TRYING OUT C# GETTER AND SETTER STUFF
    public static int health = 200;
    public static int Health
    {
        get { return health; }
        set { health = value; }
    }

    void Start() {
        machine = new PlayerMachine(this);
        rb2d =  GetComponent<Rigidbody2D>();
        machine.Init(machine.idle);
    }
    void Update() {
        machine.Update();
        transform.rotation = Quaternion.identity;
        if (jumpFrame > 0) {
            jumpFrame -= 190*Time.fixedDeltaTime;        
        }
        if (((jumpFrame > 0 && Input.GetKey(KeyCode.Z)) || Input.GetKeyDown(KeyCode.Z)) && ground)
        {
            ground = false;
            machine.Transition(machine.air);
        }
    }
    public void move(float dir) {
        rb2d.velocity = new Vector2(dir*1.0f*speed, rb2d.velocity.y);
        
    }
    public void jump() {
        rb2d.AddForce(new Vector2(0, jumpForce));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("ouch");
            PlayerController.Health -= 10;;
        }
    }
}
