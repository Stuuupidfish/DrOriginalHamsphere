using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ATTACH BOTH RIGHT AND LEFT CHECK

public class Check : MonoBehaviour
{
    public int dir;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "enemy") {
            
            player.GetComponent<Player>().kb(dir);
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
