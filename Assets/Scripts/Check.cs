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

            transform.parent.GetComponent<PlayerController>().ground = true;
            //Debug.Log("grounded");
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {

            transform.parent.GetComponent<PlayerController>().ground = false;
            //D//ebug.Log("Ungrounded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
