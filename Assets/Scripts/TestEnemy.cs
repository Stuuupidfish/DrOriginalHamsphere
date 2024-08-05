using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int testEnemyHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testEnemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "enemykill")
        {
            testEnemyHealth -= 2;
            
        }
    }
}
