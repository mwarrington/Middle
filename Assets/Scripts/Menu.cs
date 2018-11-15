using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int CurrentMenuOptionIndex;
    public int MenuOptionCount;
    public GameObject CurrentMenuOption;
    public GameObject Cursor;
    public List<MenuOption> AllOptions = new List<MenuOption>();
}