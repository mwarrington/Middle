using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager _theGameManager;
    private MenuController _theMenuController;
    private PlayerController _thePlayerController;
    private DialogManager _theDialogManager;

    private void Start()
    {
        _theGameManager = FindObjectOfType<GameManager>();
        _theMenuController = _theGameManager.TheMenuManager.TheMenuController;
        _theDialogManager = _theGameManager.TheDialogManager;
    }

    void Update()
    {
        if (_theGameManager.CurrentInputType == InputType.MENU)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _theMenuController.MoveCursorUp();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _theMenuController.MoveCursorDown();
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                _theMenuController.MenuOptionSelect(_theGameManager.TheMenuManager.CurrentMenu.CurrentMenuOption.GetComponent<MenuOption>());
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _theGameManager.TheMenuManager.CloseMenu();
            }
        }
        else if(_theGameManager.CurrentInputType == InputType.PLAYER)
        {
            //Player Controller Inputs
        }
        else if(_theGameManager.CurrentInputType == InputType.DIALOG)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                _theDialogManager.ProgressDialog();
            }
            //Temp lines
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _theDialogManager.ToggleDialogBox();
            }
        }
        else if(_theGameManager.CurrentInputType == InputType.NONE)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                _theGameManager.TheMenuManager.LoadMenu(_theGameManager.BaseMenu, _theGameManager.TheMenuManager.BaseInstantiationPosition.transform.position);
            }
        }
    }
}