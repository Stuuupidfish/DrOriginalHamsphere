
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

//using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
//inherits from MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    // private bool jumpKeyWasPressed;
    private float horizontalInput;
 
    private Rigidbody2D rigidbodyComponent;
    
    private bool grounded;

    public int playerHealth = 200;

    public bool gameOver = false;

    public float jumpPower = 7f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();

    }
 
    // Update is called once per frame
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "jumpcheck")
        {
            grounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "jumpcheck")
        {
            grounded = false;
        }
    }
    //fixed update is called every physics update
    void Update()
    {
        //Debug.Log(jumpKeyWasPressed);
        horizontalInput = Input.GetAxis("Horizontal") * 5f;

        if (playerHealth <= 0)
        {
            gameOver = true;
            Debug.Log("YOU DIED");
        }
        rigidbodyComponent.velocity = new Vector2(horizontalInput, rigidbodyComponent.velocity.y);
        
        if (!grounded)
        {
            Debug.Log("DONT JUMP");
            return;
            
        }
        Debug.Log("Grounded is " + grounded);

    
        if (Input.GetKeyDown(KeyCode.Z) && grounded)
        {

            Debug.Log("jumping");
            rigidbodyComponent.velocity = new Vector2(rigidbodyComponent.velocity.x, jumpPower);
            //jumpKeyWasPressed = false;
        }

    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            playerHealth -= 50;
            //Destroy(other.gameObject);
            Debug.Log(playerHealth);
        }
    }


}

