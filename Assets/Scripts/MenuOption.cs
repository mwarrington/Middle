using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    public string MenuAction;
    public GameObject MyObject;
    public List<MenuOptionType> MyMenuEffectsTypes = new List<MenuOptionType>();
    public List<Object> ThingToLoad = new List<Object>();
    public CameraLocations LocationToMove;

    public List<KeyValuePair<MenuOptionType, Object>> MyMenuEffects = new List<KeyValuePair<MenuOptionType, Object>>();

    private void Start()
    {
        MyObject = this.gameObject;
        for (int i = 0; i < MyMenuEffectsTypes.Count; i++)
        {
            MyMenuEffects.Add(new KeyValuePair<MenuOptionType, Object>(MyMenuEffectsTypes[i], ThingToLoad[i]));
        }
    }
}