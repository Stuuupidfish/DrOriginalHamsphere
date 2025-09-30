using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    private RectTransform contentRect;
    private RectTransform viewportRect;
    // Start is called before the first frame update

    void Awake()
    {
        contentRect = scrollRect.content;
        viewportRect = scrollRect.viewport;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
        }
    }
}
