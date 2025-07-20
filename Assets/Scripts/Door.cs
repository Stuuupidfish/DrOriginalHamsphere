using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int num;
    public Door connection;
    public string scene;
    public int exit; // 0= right, 1 = up, 2= left, 3=down

    // when player touches door, change scene and find numbered door, then launch out in that direction 

    public Vector2 getLocation () {
        return transform.position;
    }

    // should the thing that creates the player be on door or an init object?
    //Init object:
    // should have variable for coins and items
}
