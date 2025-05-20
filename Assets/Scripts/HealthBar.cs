using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;
//using Microsoft.Unity.VisualStudio.Editor;
public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public PlayerController playerController;

    [SerializeField] private Sprite[] bars;
    private static int currentHealth;
    
    private static int startHealth;
    // Start is called before the first frame update
    void Start()
    {

        // Check if playerController is assigned
        if (playerController == null)
        {
            Debug.LogError("PlayerController is not assigned in HealthBar script!");
            return;
        }

        // Check if playerController.hp is assigned
        if (playerController.hp == null)
        {
            Debug.LogError("HealthClass (hp) is not assigned in PlayerController!");
            return;
        }
        startHealth = playerController.hp.Health;  // Get the player's starting health
        currentHealth = startHealth;
        textMeshPro.text = currentHealth.ToString() + "/" + startHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        currentHealth = playerController.hp.Health;
        if (currentHealth <= 0)
        {
            GetComponent<Image>().sprite = bars[0];
        }
        else if (currentHealth <= (int)startHealth * 0.25)
        {
            //low
            GetComponent<Image>().sprite = bars[1];
        }
        else if (currentHealth <= (int)startHealth * 0.75)
        {
            GetComponent<Image>().sprite = bars[2];
            //ok health
        }
        if (currentHealth > startHealth * 0.75)
        {
            GetComponent<Image>().sprite = bars[3];
        }
        if (currentHealth > 0)
        {
            textMeshPro.text = currentHealth.ToString() + "/" + startHealth.ToString();
        }
        else
        {
            //death
            textMeshPro.text = "0/" + startHealth.ToString();
            currentHealth = 0;
        }

    
    }
}
