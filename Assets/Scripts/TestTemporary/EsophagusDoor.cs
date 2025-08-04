using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EsophagusDoor : MonoBehaviour
{
    //hi this is temporary stuff i know ur trying to build a universal door class
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("go to stomach");
            SceneManager.LoadScene("S1");
        }
    }

 
}
