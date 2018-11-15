using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> InstantiationPositions = new List<GameObject>();
    public MenuController TheMenuController;
    public Menu CurrentMenu;

    private GameManager _theGameManager;

    private void Start()
    {
        _theGameManager = FindObjectOfType<GameManager>();
    }

    public void LoadMenu(Menu newMenu, int instantiationPosition)
    {
        CurrentMenu = Instantiate(newMenu, InstantiationPositions[instantiationPosition].transform.position, Quaternion.identity); ;
        _theGameManager.CurrentInputType = InputType.MENU;
    }

    public void CloseMenu()
    {
        GameObject.Destroy(CurrentMenu.gameObject);
    }
}