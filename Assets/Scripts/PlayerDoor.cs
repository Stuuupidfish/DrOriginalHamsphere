using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoor : MonoBehaviour
{
    public static int dir;
    public static int door;
    GameObject doors;
    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.Find("Doors");
        foreach(Transform currentDoor in doors.transform)
        {
            if (currentDoor.GetComponent<Door>().num == door)
            {
                // Teleport to this location
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "door") {
            door = col.gameObject.GetComponent<Door>().connection;
            dir = col.gameObject.GetComponent<Door>().exit;
            SceneManager.LoadScene(col.gameObject.GetComponent<Door>().scene);
        }
    }
}
