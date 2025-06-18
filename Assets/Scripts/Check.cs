using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ATTACH BOTH RIGHT AND LEFT CHECK

public class Check : MonoBehaviour
{

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "ground") {
            if (transform.parent.GetComponent<PlayerController>().ground1) {
                transform.parent.GetComponent<PlayerController>().ground2 = true;
            }
            else
            {
                transform.parent.GetComponent<PlayerController>().ground1 = true; 
            }
            //figure out how to do two 
            //have two variables, jump if one of them is true. if collision is entered, make one true. on exit, set one to false. 
            //Debug.Log("grounded");
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            if (!transform.parent.GetComponent<PlayerController>().ground1)
            {
                transform.parent.GetComponent<PlayerController>().ground2 = false;
            }
            else
            {
                transform.parent.GetComponent<PlayerController>().ground1 = false;
            }
            //D//ebug.Log("Ungrounded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
