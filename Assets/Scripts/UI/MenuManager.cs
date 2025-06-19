using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//excuse the weird naming conventions im first learning this off a tutorial

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;

    //button scrolling 
    [SerializeField] private GameObject _journalFirst;

    //[SerializeField] private GameObject _settingsMenuFirst;
    //probably dont need this ^^^


    private bool isPaused;
    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }
    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Z))
        {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            if (selected != null)
            {
                // Simulate button press
                ExecuteEvents.Execute<IPointerClickHandler>(selected, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        OpenMainMenu();
    }
    private void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        CloseAllMenus();
    }
    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_journalFirst);
    }
    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }
    // public void OnResumePress()
    // {
    //     Unpause();
    // }
    //I ALSO MIGHT NOT NEED THIS BUT IM KEEPING EVERYTHING IN CASE ^^^

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);

        //_mainMenuCanvasGO.SetActive(false);
        //I AM NOT INCLUDING THIS PART OF TUTORIAL ^^^
    }

    // public void OnSettingsBackPress()
    // {
    //     OpenMainMenu();
    // }
    //I might not use this method either ^^
}
