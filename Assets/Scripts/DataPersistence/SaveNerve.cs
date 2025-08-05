using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveNerve : MonoBehaviour
{
    [SerializeField] private GameObject saveTextGO;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Save Game?");
            saveTextGO.SetActive(true);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        saveTextGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if not touching the save nerve, hide the text
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>().IsTouching(GetComponent<Collider2D>()))
        {
            saveTextGO.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Open save menu");

            }
        }

        
    }
}
