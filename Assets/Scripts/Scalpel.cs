using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour
{
    int increasing;
    public PlayerController player;
    Vector2 scalpelDirection;
    public const float SIDEX = 0.06790472f; // capitals were supposed to be const but i cant have static const variables for some reason? lollll
    public const float SIDEY = 0.2171369f;
    public static Vector2 POSX = new Vector2(.58f,.01f);
    public static Vector2 POSY;
    //public PlayerController player;
    //public int direction;
    // Start is called before the first frame update
    void Start()
    {
        POSY = new Vector2(0.5f * (player.transform.localScale.x-SIDEY), 0- 0.5f * player.transform.localScale.y);
        increasing = 1;
        //transform.localScale = new Vector2(transform.parent.GetComponent<PlayerController>().dir * Math.abs(transform.localScale.x), transform.localScale.y);
        // PUt down transform here
        scalpelDirection = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scalpelDirection.y += 1;
            transform.localScale = new Vector2(SIDEY, SIDEX);
            transform.localPosition = new Vector2(POSY.x, -SIDEX);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            scalpelDirection.y -= 1;
            transform.localScale = new Vector2(SIDEY, SIDEX);
            transform.localPosition = new Vector2(POSY.x, -1*player.transform.localScale.x);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            scalpelDirection.x += 1;
            transform.localScale = new Vector2(SIDEX, SIDEY);
            transform.localPosition = POSX;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            scalpelDirection.x -= 1;
            transform.localScale = new Vector2(SIDEX, SIDEY);
            transform.localPosition = POSX;
        }
        if (scalpelDirection.x == 0 && scalpelDirection.y == 0)
            //scalpelDirection = new Vector2(GetComponent<PlayerController>().direction, 0);

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
        transform.parent.GetComponent<PlayerController>().canHit = false;
        float degree = Time.deltaTime * 300;
        if (scalpelDirection.y == 0)
        {
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
            transform.localScale = new Vector2(.05f * increasing * degree + transform.localScale.x, .025f * degree * increasing + transform.localScale.y);
            transform.position = new Vector2(.5f * .05f * increasing * degree * transform.parent.GetComponent<PlayerController>().direction + transform.position.x, transform.position.y);
        }
        if (scalpelDirection.y == 1)
        {
            if (transform.localScale.y > 1.0) {
                increasing = -1;
            }
            if (transform.localScale.y <= 0) {
                transform.parent.GetComponent<PlayerController>().canTurn = true;
                transform.parent.GetComponent<PlayerController>().canHit = true;
                Destroy(gameObject);
            }
            transform.localScale = new Vector2(.025f * increasing * degree + transform.localScale.x, .05f * degree * increasing + transform.localScale.y);
            transform.position = new Vector2(transform.position.x-.0125f*increasing*degree* transform.parent.GetComponent<PlayerController>().direction, .05f * increasing * degree + transform.position.y);

            // parallel to above
            // rotation to 90 degrees- 
            // if up, just follow rules already followed 

        }
        if (scalpelDirection.y == -1) {
            if (transform.localScale.y > 1.0)
            {
                increasing = -1;
            }
            if (transform.localScale.y <= 0)
            {
                transform.parent.GetComponent<PlayerController>().canTurn = true;
                transform.parent.GetComponent<PlayerController>().canHit = true;
                Destroy(gameObject);
            }
            transform.localScale = new Vector2(.025f * increasing * degree + transform.localScale.x, .05f * degree * increasing + transform.localScale.y);
            transform.position = new Vector2(transform.position.x - .0125f * increasing * degree * transform.parent.GetComponent<PlayerController>().direction, transform.position.y);
            //transform.localScale = new Vector2(.025);
        }
    }
}
