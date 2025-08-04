using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler
{
    private string dataFilePath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataFilePath, string dataFileName)
    {
        this.dataFilePath = dataFilePath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataFilePath, dataFileName);
        GameData loadedData = null;
        // Check if the file exists before trying to read it
        if (File.Exists(fullPath))
        {
            try
            {
                // load serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                // Deserialize the JSON data to GameData object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load data from:" + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void Save(GameData gameData)
    {
        //path.combine accomodates different OSs
        string fullPath = Path.Combine(dataFilePath, dataFileName);
        try
        {
            // Create directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the game data to JSON
            string dataToStore = JsonUtility.ToJson(gameData, true);

            // Write the JSON data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save data to:" + fullPath + "\n" + e);
        }
    }
}
