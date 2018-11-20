using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject BaseInstantiationPosition;
    public MenuController TheMenuController;
    public Menu CurrentMenu;

    private GameManager _theGameManager;

    private void Start()
    {
        _theGameManager = FindObjectOfType<GameManager>();
    }

    public void LoadMenu(Menu newMenu, Vector3 instantiationPosition)
    {
        CurrentMenu = Instantiate(newMenu, instantiationPosition, Quaternion.identity); ;
        _theGameManager.CurrentInputType = InputType.MENU;
        CurrentMenu.transform.parent = Camera.main.transform;
    }

    public void CloseMenu()
    {
        GameObject.Destroy(CurrentMenu.gameObject);

        if(FindObjectsOfType<Menu>() == null)
        {
            _theGameManager.CurrentInputType = InputType.NONE;
        }
    }

    public void CloseAllMenus()
    {
        foreach (Menu menu in FindObjectsOfType<Menu>())
        {
            GameObject.Destroy(menu.gameObject);
        }

        _theGameManager.CurrentInputType = InputType.NONE;
    }
}