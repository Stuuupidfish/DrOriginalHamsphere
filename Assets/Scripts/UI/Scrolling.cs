using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scrollRect.verticalNormalizedPosition += scrollSpeed * Time.deltaTime;
            Debug.Log("Scroll up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;
            Debug.Log("Scroll down");
        }
    }
}
