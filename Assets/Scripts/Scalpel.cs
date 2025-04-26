using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour
{
    int increasing;
    // Start is called before the first frame update
    void Start()
    {
        increasing = 1;
        //transform.localScale = new Vector2(transform.parent.GetComponent<PlayerController>().dir * Math.abs(transform.localScale.x), transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 1.0 || transform.localScale.x < -1.0) {
            increasing = transform.localScale.x > 1.0?-1:1;
        }
        if (transform.localScale.x < 0 ) {
            transform.parent.GetComponent<PlayerController>().canTurn = true;
            Destroy(gameObject);
        }
        transform.localScale = new Vector2(.05f * increasing + transform.localScale.x, .025f * increasing + transform.localScale.y);
        transform.position = new Vector2(.5f* .05f  *increasing* transform.parent.GetComponent<PlayerController>().direction + transform.position.x, transform.position.y);
    }
}
