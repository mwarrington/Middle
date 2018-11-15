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
            _theMenuManager.CurrentMenu.CurrentMenuOptionIndex = _theMenuManager.CurrentMenu.MenuOptionCount - 1;
        }

        _theMenuManager.CurrentMenu.Cursor.transform.position = new Vector3(_theMenuManager.CurrentMenu.Cursor.transform.position.x,
                                                                            _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].transform.position.y,
                                                                            _theMenuManager.CurrentMenu.Cursor.transform.position.z);

        _theMenuManager.CurrentMenu.CurrentMenuOption = _theMenuManager.CurrentMenu.AllOptions[_theMenuManager.CurrentMenu.CurrentMenuOptionIndex].gameObject;
    }

    //an Invoke machine
    public void MenuOptionSelect(List<KeyValuePair<MenuOptionType, Object>> menuEffects)
    {
        for (int i = 0; i < menuEffects.Count; i++)
        {
            switch(menuEffects[i].Key)
            {
                case MenuOptionType.LOADMENU:
                    LoadNewMenu(menuEffects[i].Value as GameObject);
                    //Invoke("LoadNewMenu", );
                    break;
                case MenuOptionType.LOADDIALOG:
                    LoadDialog(menuEffects[i].Value as DialogInstance);
                    _theMenuManager.CloseMenu();
                    _theGameManager.CurrentInputType = InputType.DIALOG;
                    //Invoke("LoadDialog", menuEffects[i].Value);
                    break;
                case MenuOptionType.LOADANIM:
                    //Invoke("CueAnimation", menuEffects[i].Value);
                    break;
            }
        }
    }

    private void LoadNewMenu(GameObject menuToLoad)
    {
        Instantiate(menuToLoad, _theMenuManager.CurrentMenu.CurrentMenuOption.transform.position, Quaternion.identity);
    }

    private void LoadDialog(DialogInstance dialogData)
    {
        //Talk to dialog manager to get the dialog starting
        _theGameManager.TheDialogManager.ToggleDialogBox(dialogData);
    }

    private void CueAnimation()
    {

    }
}