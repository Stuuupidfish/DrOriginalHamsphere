using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int textHealth = PlayerController.Health;
    private int startHealth = PlayerController.Health;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = textHealth.ToString() + "/" + startHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textHealth = PlayerController.Health;
        textMeshPro.text = textHealth.ToString() + "/" + startHealth.ToString();
    }
}
