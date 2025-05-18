using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    //public int testEnemyHealth = 10;
    public int enemyHealth;
    private HealthClass hp;
    public float changeVel;
    [SerializeField] Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HealthClass>();
        hp.Health = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hp.Health);
        if (hp.Health <= 0)
        {
            Destroy(gameObject);
        }
        if (changeVel >= 0)
        {
            changeVel -= Time.deltaTime;

        }

        
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "enemykill" || col.gameObject.tag == "scalpel")
        {
            hp.takeDamage(2);
            //Debug.Log("Hit enemy");

            if (col.gameObject.tag == "scalpel")
            {
                changeVel = 0.1f;
                //float dir = Math.Abs(GetComponent<Transform>().position.x - col.gameObject.GetComponent<Transform>().position.x) / (GetComponent<Transform>().position.x - col.gameObject.GetComponent<Transform>().position.x);
                float dir = GetComponent<Transform>().position.x > col.gameObject.GetComponent<Transform>().position.x ? 1 : -1;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * 1000, 0));
                Debug.Log("knockback");
                
                //player.AddForce(new Vector2(dir * -1 * 500, 0));
            }
        }
    }
}
