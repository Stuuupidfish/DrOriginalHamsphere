using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJuice : MonoBehaviour
{
    float t;
    void Start() {
        //Debug.Log(transform.position.x + " " + transform.position.y);
        t = 1000;
    }
    void Update() {
        t-= 1.0f*Time.deltaTime*1000;
        if (t <= 0) {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag != "enemykill") {
            Destroy(gameObject);
         }
    }
}
