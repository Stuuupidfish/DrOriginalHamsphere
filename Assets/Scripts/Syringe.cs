using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    // Shoots series of rigidbodies, adds force
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    private int bulletForce = 700;
    private Vector2 playerVelocity;
    public PlayerController player;
    void Start()
    {
        playerVelocity = player.currentVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = player.currentVelocity();
        Vector2 shootDirection = new Vector2(0,0);
        if (Input.GetKey(KeyCode.UpArrow))
            shootDirection.y += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            shootDirection.y -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            shootDirection.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            shootDirection.x -= 1;
        if (shootDirection.x == 0 && shootDirection.y == 0)
            shootDirection = new Vector2(GetComponent<PlayerController>().direction, 0);

        //Debug.Log(GetComponent<PlayerController>().direction);
        if (Input.GetKey(KeyCode.A))
        {
            shootDirection.Normalize(); // Normalize to prevent faster diagonal shots
            GameObject b = Instantiate(bullet, transform.position + (Vector3)(shootDirection * 0.7f), Quaternion.identity);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = playerVelocity;
            rb.AddForce(shootDirection * bulletForce);
            // Debug.Log("Now shall I shoot, and right is " + GetComponent<Player>().right);
            //Instantiate(bullet, new Vector3((transform.position.x+1/*(0.5f*transform.localScale.x+0.5f)*/ * GetComponent<PlayerController>().direction), transform.position.y),Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce* GetComponent<PlayerController>().direction, 2));
            
        }
    }
}
