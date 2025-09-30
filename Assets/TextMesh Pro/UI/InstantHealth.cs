using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    void Start()
    {
        Canvas sceneCanvas = Instantiate(canvas);
        sceneCanvas.transform.Find("HEALTH").GetComponent<HealthBar>().playerController = GetComponent<PlayerController>();
    }
}
