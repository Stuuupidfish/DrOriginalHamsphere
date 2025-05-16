using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int testEnemyHealth = 10;
    public int changeVel;
    [SerializeField] Rigidbody2D player; 
    // Start is called before the first frame update
    void Start()
    {
        int changeVel;
    }

    // Update is called once per frame
    void Update()
    {
        if (testEnemyHealth <= 0) {
            Destroy(gameObject);
        }
        if (changeVel >= 0)
        {
            changeVel--;

        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "enemykill")
        {
            testEnemyHealth -= 2;
            Debug.Log("Hit enemy");
            changeVel = 200;
            if (col.gameObject.GetComponent<Transform>().position.x != GetComponent<Transform>().position.x)
            {
                float dir = Math.Abs(GetComponent<Transform>().position.x - col.gameObject.GetComponent<Transform>().position.x) / (GetComponent<Transform>().position.x - col.gameObject.GetComponent<Transform>().position.x);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * 500, 0));
                //player.AddForce(new Vector2(dir * -1 * 500, 0));
            }
        }
    }
}
