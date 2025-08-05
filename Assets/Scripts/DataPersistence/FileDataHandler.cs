using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler
{
    private string dataFilePath = "";
    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "bug";




    public FileDataHandler(string dataFilePath, string dataFileName, bool useEncryption)
    {
        this.dataFilePath = dataFilePath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
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

                // If encryption is enabled, decrypt the data
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
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

            // If encryption is enabled, encrypt the data
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

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




    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
    



}
