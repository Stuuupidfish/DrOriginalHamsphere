using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//excuse the weird naming conventions im first learning this off a tutorial

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuCanvasGO;
    #region MAIN BUTTON CANVAS GAME OBJECTS
    [SerializeField] private GameObject settingsMenuCanvasGO;
    [SerializeField] private GameObject inventoryGO;
    [SerializeField] private GameObject journalCanvasGO;
    [SerializeField] private GameObject mapCanvasGO;
    [SerializeField] private GameObject loadCanvasGO;
    #endregion

    #region MAIN AND SUB-BUTTONS
    [SerializeField] private GameObject journalButton;
    [SerializeField] private GameObject questsButton;
    [SerializeField] private GameObject acheivementsButton;
    [SerializeField] private GameObject bestiaryButton;
    [SerializeField] private GameObject mapButton;

    [SerializeField] private GameObject loadButton;

    [SerializeField] private GameObject inventoryButton;

    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject returnToTitleButton;
    #endregion


    private GameObject previousButton;
    private bool isPaused;
    private GameObject lastPreviewedButton;

    private void Start()
    {
        mainMenuCanvasGO.SetActive(false);

        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
        journalCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
    }
    private void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
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
        if (selected != null && selected != lastPreviewedButton)
        {
            // Update the last previewed button
            lastPreviewedButton = selected;
            if (selected == journalButton)
            {
                OpenJournal();
            }
            else if (selected == inventoryButton)
            {
                OpenInventory();
            }
            else if (selected == mapButton)
            {
                OpenMap();
            }
            else if (selected == loadButton)
            {
                OpenLoad();
            }
            else if (selected == settingsButton)
            {
                OpenSettingsMenuHandle();
            }
        }
        
        if (isPaused && Input.GetKeyDown(KeyCode.Z))
            {
                if (selected != null)
                {
                    // Simulate button press
                    ExecuteEvents.Execute<IPointerClickHandler>(selected, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    if (selected == journalButton)
                    {
                        previousButton = selected;
                    }
                    else if (selected == mapButton)
                    {
                        previousButton = selected;
                    }
                    else if (selected == loadButton)
                    {
                        previousButton = selected;
                    }
                    else if (selected == inventoryButton)
                    {
                        previousButton = selected;
                    }
                    else if (selected == settingsButton)
                    {
                        previousButton = selected;
                    }
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
    #region PAUSE AND UNPAUSE METHODS 
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
    #endregion

    private void OpenMainMenu()
    {
        mainMenuCanvasGO.SetActive(true);

        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);

        journalCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(journalButton);
    }
    private void CloseAllMenus()
    {
        mainMenuCanvasGO.SetActive(false);

        settingsMenuCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
        journalCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
    }
    #region BUTTON PRESS METHODS
    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
        EventSystem.current.SetSelectedGameObject(returnToTitleButton);
    }
    public void OnInventoryPress()
    {
        OpenInventory();
    }
    public void OnJournalPress()
    {
        OpenJournal();
        EventSystem.current.SetSelectedGameObject(questsButton);
    }
    public void OnMapPress()
    {
        OpenMap();
    }
    public void OnLoadPress()
    {
        OpenLoad();
    }
    #endregion


#region OPEN MENU PAGES METHODS
    private void OpenSettingsMenuHandle()
    {
        settingsMenuCanvasGO.SetActive(true);

        journalCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
    }
    private void OpenInventory()
    {
        inventoryGO.SetActive(true);

        journalCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);

        //other stuff to do with inventory will b implemented later
    }
    private void OpenJournal()
    {
        journalCanvasGO.SetActive(true);

        settingsMenuCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);
    }
    private void OpenMap()
    {
        mapCanvasGO.SetActive(true);

        journalCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        loadCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);

        //other stuff to do with map will b implemented later
    }
    private void OpenLoad()
    {
        loadCanvasGO.SetActive(true);

        journalCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        mapCanvasGO.SetActive(false);
        inventoryGO.SetActive(false);

        //other stuff to do with load will b implemented later
    }
    
#endregion
}
