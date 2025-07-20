using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

// IN ORDER OF IMPORTANCE:
// FIX WALL STICKING [done yippee]
// FIX SCALPEL AND BULLETS AT SAME TIME [done yippee
// FIX STOPPING DURING SCALPEL [ok so now theres a chance that hamsphere will start sliding]
// ADD SCALPEL DIRECTIONS
// CREATE STOMACH BUG
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public PlayerMachine machine;
    public int speed = 5;
    public bool ground;
    public bool ground1;
    public bool ground2;
    public int jumpForce;
    public float jumpFrame = 0;
    public HealthClass hp;
    public int maxHealth;
    public bool canTurn;
    private bool canMove = true;
    public bool canHit;
    public GameObject scalpel; // set cooldown after bullets, until scalpel can hit again
    public float direction;
    int scalpelCooldown;

     void Start()
    {


        machine = new PlayerMachine(this);
        rb2d = GetComponent<Rigidbody2D>();
        machine.Init(machine.idle);

        hp.Health = maxHealth;
        Debug.Log(hp.Health);
        canHit = true;
        canTurn = true;
        direction = 1;
        scalpelCooldown = 200;
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), scalpel.GetComponent<BoxCollider2D>());

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Weapon"), true);
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }
    public Vector2 currentVelocity()
    {
        return rb2d.velocity;
    }
    void Update()
    {
        ground = ground1 || ground2;
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        machine.Update();
        transform.rotation = Quaternion.identity;
        if (jumpFrame > 0)
        {
            jumpFrame -= 190 * Time.fixedDeltaTime;
        }
        if (((jumpFrame > 0 && Input.GetKey(KeyCode.Z)) || Input.GetKeyDown(KeyCode.Z)) && ground)
        {
            ground = false;
            ground1 = false;
            ground2 = false;
            machine.Transition(machine.air);
        }
        if (Input.GetKeyDown(KeyCode.X) && canTurn)
        {
            Instantiate(scalpel, this.transform);
            canTurn = false;
            canHit = false;
        }

        canMove = !Input.GetKey(KeyCode.C);
        if (!canMove && ground)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (hp.ITime >= 0.5 * hp.MaxIframes)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (hp.Invincible)
        {
            hp.iFrames();
            //if u want overlap during i frames 
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
            GetComponent<SpriteRenderer>().color = Color.blue;

        }
        else
        {
            //if u want overlap during i frames
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
            GetComponent<SpriteRenderer>().color = Color.white;

        }
        


    }
    public void move(float dir)
    {
        if (canMove)
        {
            rb2d.velocity = new Vector2(dir * 1.0f * speed, rb2d.velocity.y);
            Vector3 newScale = transform.localScale;

            newScale.x *= (dir < -0.5f || dir > 0.5f) ? dir * (newScale.x / Math.Abs(newScale.x)) : 1.0f; // gets flattened
            if (Math.Abs(dir) > .5)
            {
                direction = dir;
            }
            transform.localScale = newScale;
        }
    }
    public void jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (!hp.Invincible)
            {
                //fix
            
                 //Debug.Log("turn on iFrames");
                hp.ITime = hp.MaxIframes;
                hp.Invincible = true;
                hp.takeDamage(collision.gameObject.GetComponent<EnemyProperties>().damage);
                //fix ^
                int dir = rb2d.position.x < collision.gameObject.GetComponent<Rigidbody2D>().position.x ? -1 : 1;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(700 * dir, 1000));

                
            }

        }
    }
    
    
}
