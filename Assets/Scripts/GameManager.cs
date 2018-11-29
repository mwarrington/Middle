using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogManager TheDialogManager;
    public CameraManager TheCameraManager;
    public InputManager TheInputManager;
    public MenuManager TheMenuManager;

    public InputType CurrentInputType;
    public KeyValuePair<string, bool> CurrentGoal = new KeyValuePair<string, bool>();
    public List<PhaseEvents> PhaseEvents = new List<PhaseEvents>();
    public Menu BaseMenu;
    public ProgressRequirement CurrentPR;
    public CameraLocations CurrentLocation;
    public string DialogSubject = "None";
    public int PhaseIndex;

    //Date and time fields

    public void CheckProgress(string menuAction)
    {
        for (int i = 0; i < CurrentPR.MenuActionRequirements.Count; i++)
        {
            if(menuAction == CurrentPR.MenuActionRequirements[i].Key && !CurrentPR.MenuActionRequirements[i].Value)
            {
                string menuActionName = CurrentPR.MenuActionRequirements[i].Key;
                CurrentPR.MenuActionRequirements.RemoveAt(i);
                CurrentPR.MenuActionRequirements.Insert(i, new KeyValuePair<string, bool>(menuActionName, true));
            }
        }
    }
}