using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, PlayerDoor.door.getLocation(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
