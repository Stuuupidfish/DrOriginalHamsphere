using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField] private string fileName = "";
    [SerializeField] private bool useEncryption = false;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("wtf there should only be one instance");
        }
        Instance = this;

    }
    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        gameData = new GameData(); // Initialize a new GameData instance
    }
    public void LoadGame()
    {
        gameData = dataHandler.Load(); // Load game data from file
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        if (gameData == null)
        {
            Debug.LogError("No game data available to load");
            NewGame(); // Create a new game if none exists
        }
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData); // Load data for each IDataPersistence object
        }
        Debug.Log("Loaded currency: " + gameData.currencyCount);

    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData); // Save data for each IDataPersistence object
        }
        Debug.Log("saved currency: " + gameData.currencyCount);
        dataHandler.Save(gameData); // Save the game data to file
        Debug.Log("Game data saved to " + Application.persistentDataPath);
    }



    //IM PROBABLY GONNA REMOVE THIS IN THE FUTURE SINCE I WANT SLOT SAVES
    //THIS IS FOR TESTING
    private void OnApplicationQuit()
    {
        SaveGame();
    }



    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
