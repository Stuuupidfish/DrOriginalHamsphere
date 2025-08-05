using System.Collections;
using System.Collections.Generic;

//using UnityEditor.SearchService;
//this thing above breaks the build and tbh idk why its here nor do i know if i need it or not

//using System.Numerics;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int currencyCount;
    public Vector2 playerPosition;
    public int health;
    //public Scene scene;

    // Constructor to initialize GameData with default values
    // ie new game
    // 
    public GameData()
    {
        currencyCount = 0; // Default value for a new game
        playerPosition = new Vector2(-19.54f, 4.33f); // Default player position
        health = 200; // Default health value
        //scene = Scene.ME1; // Default scene
    }
}
