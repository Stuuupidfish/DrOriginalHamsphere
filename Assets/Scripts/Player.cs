
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

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();

    }
 
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Z) == true)
        // {
        //    jumpKeyWasPressed = true;
        // //    Debug.Log("Z was pressed");
        // }

        horizontalInput = Input.GetAxis("Horizontal") * 5f;

        if (playerHealth <= 0)
        {
            gameOver = true;
            Debug.Log("YOU DIED");
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            grounded = true;
        }

    }

    //fixed update is called every physics update
    void FixedUpdate()
    {
        //Debug.Log(jumpKeyWasPressed);
        rigidbodyComponent.velocity = new Vector2(horizontalInput, rigidbodyComponent.velocity.y);
        
        if (!grounded)
        {
            //Debug.Log("DONT JUMP");
            return;
            
        }
   

    
        if (Input.GetKeyDown(KeyCode.Z) && grounded)
        {
            float jumpPower = 7f;

            rigidbodyComponent.velocity = new Vector2(rigidbodyComponent.velocity.x, jumpPower);
            // jumpKeyWasPressed = false;
            grounded = false;
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

