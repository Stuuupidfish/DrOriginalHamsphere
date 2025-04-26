using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    // Shoots series of rigidbodies, adds force
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Now shall I shoot, and right is " + GetComponent<Player>().right);
            Instantiate(bullet, new Vector3((transform.position.x+1/*(0.5f*transform.localScale.x+0.5f)*/ * GetComponent<PlayerController>().direction), transform.position.y),Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(1200* GetComponent<PlayerController>().direction, 2));
        }
    }
}
