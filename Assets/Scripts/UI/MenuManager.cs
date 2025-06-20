using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//excuse the weird naming conventions im first learning this off a tutorial

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject settingsMenuCanvasGO;

    [SerializeField] private GameObject inventoryGO;

    //button scrolling 
    [SerializeField] private GameObject journalButton;
    [SerializeField] private GameObject mapButton;
    [SerializeField] private GameObject loadButton;
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject settingsButton;

    [SerializeField] private GameObject returnToTitleButton;

    //[SerializeField] private GameObject _settingsMenuFirst;
    //probably dont need this ^^^
    private GameObject previousButton;

    private bool isPaused;
    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//(InputManager.instance.MenuOpenCloseInput)
        //im scrapping the tutorial's new input system bcuz its too much for me to think abt
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
                previousButton = selected;
            }
        }
        if (isPaused && Input.GetKeyDown(KeyCode.X))
        {
            // Simulate back button press
            if (previousButton != null)
            {
                EventSystem.current.SetSelectedGameObject(previousButton);
            }
            else
            {
                OpenMainMenu();
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
        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(journalButton);
    }
    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
    }

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }
    public void OnInventoryPress()
    {
        OpenInventory();
    }
    // public void OnResumePress()
    // {
    //     Unpause();
    // }
    //I ALSO MIGHT NOT NEED THIS BUT IM KEEPING EVERYTHING IN CASE ^^^

    private void OpenSettingsMenuHandle()
    {
        settingsMenuCanvasGO.SetActive(true);

        inventoryGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(returnToTitleButton);



        //_mainMenuCanvasGO.SetActive(false);
        //I AM NOT INCLUDING THIS PART OF TUTORIAL ^^^
    }
    private void OpenInventory()
    {
        inventoryGO.SetActive(true);

        settingsMenuCanvasGO.SetActive(false);
    }

    // public void OnSettingsBackPress()
    // {
    //     OpenMainMenu();
    // }
    //I might not use this method either ^^
}
