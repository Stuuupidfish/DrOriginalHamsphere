using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class Inventory : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshPro;
    public static int currency;

    private int maxCurrency = 9999;
    private int maxInventorySize = 8;
    private Item[] inventorySlots;
    [SerializeField] private Item[][] inventory;


    public void LoadData(GameData data)
    {
        currency = data.currencyCount; // Load the currency count from the game data
    }
    public void SaveData(ref GameData data)
    {
        data.currencyCount = currency; // Save the current currency count to the game data
        Debug.Log("Saving currency: " + currency);
    }

    void Start()
    {
        //currency += 10;
        //BRO IDK WHY BUT IF I UNCOMMENT THE LIINE ABOVE I GET INFINITE ERRORS BEFORE THE GAME EVEN RUNS FROM THE PLAYER CONTROLLER SCRIPT
        inventorySlots = new Item[maxInventorySize];
        if (textMeshPro == null)
        {
            textMeshPro = GameObject.Find("LightCountText").GetComponent<TextMeshProUGUI>();
        }
        textMeshPro.text = currency.ToString();
        Debug.Log("Starting currency: " + currency);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text element with the current currency value
        if (textMeshPro != null)
        {
            textMeshPro.text = currency.ToString();
        }
    }
    public void AddCurrency(int amount)
    {
        currency += amount;
        if (currency > maxCurrency)
        {
            currency = maxCurrency;
        }
        Debug.Log("Currency added: " + amount + ", Total currency: " + currency);
    }

}
