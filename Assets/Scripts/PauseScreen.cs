using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    private bool menuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GetKeyDown() only returns true in the first frame that is is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("paused=" + menuActive);
            menuActive = !menuActive;
            pausePanel.SetActive(menuActive);
            if (menuActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
