using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XmasLight : MonoBehaviour
{
    //public TextMeshProUGUI textMeshPro; //= GameObject.Find("LightCountText").GetComponent<TextMeshProUGUI>();
    // public static int lightCount = 0; // Static variable to keep track of the number of lights
    // Start is called before the first frame update
    private Inventory inventory; // Reference to the Inventory script
    private bool isCollected = false; // To prevent multiple collections
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isCollected && col.gameObject.CompareTag("Player"))
        {
            isCollected = true; // Set the flag to true to prevent multiple collections
            Debug.Log("Player collected a light!");


            //lightCount++;
            inventory.AddCurrency(1); // Add to the inventory's currency
            //textMeshPro.text = lightCount.ToString();
            Destroy(gameObject);
        }
    }
    
}
