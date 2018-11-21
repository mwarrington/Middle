using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private MenuManager _theMenuManager;
    private GameManager _theGameManager;

    private void Start()
    {
        _theMenuManager = FindObjectOfType<MenuManager>();
        _theGameManager = FindObjectOfType<GameManager>();
    }

    public void MoveCursorDown()
    {
        _theMenuManager.CurrentMenu.CurrentMenuOptionIndex++;

        if(_theMenuManager.CurrentMenu.CurrentMenuOptionIndex == _theMenuManager.CurrentMenu.AllOptions.Count)
        {
            _theMenuManager.CurrentMenu.CurrentMenuOptionIndex = 0;
        }

        _theMenuManager.CurrentMenu.Cursor.transform.position = new Vector3(_theMenuManager.CurrentMenu.Cursor.transform.position.x,
                                                                            _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].transform.position.y,
                                                                            _theMenuManager.CurrentMenu.Cursor.transform.position.z);

        _theMenuManager.CurrentMenu.CurrentMenuOption = _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].gameObject;
    }

    public void MoveCursorUp()
    {
        _theMenuManager.CurrentMenu.CurrentMenuOptionIndex--;

        if (_theMenuManager.CurrentMenu.CurrentMenuOptionIndex < 0)
        {
            _theMenuManager.CurrentMenu.CurrentMenuOptionIndex = _theMenuManager.CurrentMenu.AllOptions.Count - 1;
        }

        _theMenuManager.CurrentMenu.Cursor.transform.position = new Vector3(_theMenuManager.CurrentMenu.Cursor.transform.position.x,
                                                                            _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].transform.position.y,
                                                                            _theMenuManager.CurrentMenu.Cursor.transform.position.z);

        _theMenuManager.CurrentMenu.CurrentMenuOption = _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].gameObject;
    }
    
    public void MenuOptionSelect(MenuOption theMenuOption)//List<KeyValuePair<MenuOptionType, Object>> menuEffects)
    {
        for (int i = 0; i < theMenuOption.MyMenuEffects.Count; i++)
        {
            switch(theMenuOption.MyMenuEffects[i].Key)
            {
                case MenuOptionType.LOADMENU:
                    LoadNewMenu((theMenuOption.MyMenuEffects[i].Value as GameObject).GetComponent<Menu>());
                    //Invoke("LoadNewMenu", );
                    break;
                case MenuOptionType.LOADDIALOG:
                    LoadDialog();
                    _theMenuManager.CloseMenu();
                    _theGameManager.CurrentInputType = InputType.DIALOG;
                    //Invoke("LoadDialog", menuEffects[i].Value);
                    break;
                case MenuOptionType.LOADANIM:
                    //Invoke("CueAnimation", menuEffects[i].Value);
                    break;
                case MenuOptionType.CHANGECAMERA:
                    ChangeCamera(theMenuOption.LocationToMove);
                    break;
            }
        }

        _theGameManager.CheckProgress(theMenuOption.MenuAction);
    }

    private void LoadNewMenu(Menu menuToLoad)
    {
        _theMenuManager.LoadMenu(menuToLoad, _theMenuManager.CurrentMenu.CurrentMenuOption.transform.position);
    }

    private void LoadDialog()
    {
        //Talk to dialog manager to get the dialog starting
        _theGameManager.TheDialogManager.FindCurrentDialog(_theGameManager.CurrentLocation, _theGameManager.PhaseIndex, _theGameManager.DialogSubject);
        _theGameManager.TheDialogManager.ToggleDialogBox();
    }

    private void CueAnimation()
    {

    }

    private void ChangeCamera(CameraLocations cameraLocations)
    {
        _theGameManager.TheCameraManager.ChangeView(cameraLocations);
        _theMenuManager.CloseAllMenus();
    }
}