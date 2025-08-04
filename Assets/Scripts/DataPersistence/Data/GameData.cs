using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int currencyCount;

    // Constructor to initialize GameData with default values
    // ie new game
    // 
    public GameData()
    {
        currencyCount = 0; // Default value for a new game
    }
}
