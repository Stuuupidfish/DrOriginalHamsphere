using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour
{
    int increasing;
    public GameObject player;
    Vector2 scalpelDirection;
    //public int direction;
    // Start is called before the first frame update
    void Start()
    {
        increasing = 1;
        //transform.localScale = new Vector2(transform.parent.GetComponent<PlayerController>().dir * Math.abs(transform.localScale.x), transform.localScale.y);
        scalpelDirection = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            scalpelDirection.y += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            scalpelDirection.y -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            scalpelDirection.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            scalpelDirection.x -= 1;
        if (scalpelDirection.x == 0 && scalpelDirection.y == 0)
            scalpelDirection = new Vector2(GetComponent<PlayerController>().direction, 0);

        // up arrow +90, down arrow -90
        if (scalpelDirection.y == 1)
        {
            transform.Rotate(new Vector3(0, 0, 90));
            //transform.position = new Vector2(0+0.5f*,);
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if (scalpelDirection.y != 0)
        {*/
            transform.parent.GetComponent<PlayerController>().canHit = false;
            if (transform.localScale.x > 1.0 || transform.localScale.x < -1.0)
            {
                increasing = transform.localScale.x > 1.0 ? -1 : 1;
            }
            if (transform.localScale.x <= 0)
            {
                transform.parent.GetComponent<PlayerController>().canTurn = true;
                transform.parent.GetComponent<PlayerController>().canHit = true;
                Destroy(gameObject);
            }
            float degree = Time.deltaTime * 300;
            transform.localScale = new Vector2(.05f * increasing * degree + transform.localScale.x, .025f * degree * increasing + transform.localScale.y);
            transform.position = new Vector2(.5f * .05f * increasing * degree * transform.parent.GetComponent<PlayerController>().direction + transform.position.x, transform.position.y);
        /*}*/
        if (scalpelDirection.y == 1)
        { 
            // 

        }
    }

    // private Vector2 scalpelDir()
    // {
    //     Vector2 scalpelDirection = new Vector2(0,0);
    //     if (Input.GetKey(KeyCode.UpArrow))
    //         scalpelDirection.y += 1;
    //     if (Input.GetKey(KeyCode.DownArrow))
    //         scalpelDirection.y -= 1;
    //     if (Input.GetKey(KeyCode.RightArrow))
    //         scalpelDirection.x += 1;
    //     if (Input.GetKey(KeyCode.LeftArrow))
    //         scalpelDirection.x -= 1;
    //     if (scalpelDirection.x == 0 && scalpelDirection.y == 0)
    //         scalpelDirection = new Vector2(GetComponent<PlayerController>().direction, 0);
    //     return scalpelDirection;
    // }
}
