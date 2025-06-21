using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{

    public void SwitchSceneStomach()
    {
        SceneManager.LoadScene("MouthEsophagus");
    }
    public void quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    public void load()
    {
        //NOT DONE
    }
    public void returnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
