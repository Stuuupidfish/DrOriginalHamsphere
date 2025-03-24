using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public PlayerController playerController;
    private int currentHealth;
    private int startHealth;
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
        if (currentHealth >= 0)
        {
            textMeshPro.text = currentHealth.ToString() + "/" + startHealth.ToString();
        }
        else
        {
            textMeshPro.text = "0/" + startHealth.ToString();
        }
    }
}
