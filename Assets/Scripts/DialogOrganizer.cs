using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOrganizer : MonoBehaviour
{
    public DialogInstance CurrentInstance;

    public DialogInstance FindCurrentDialog(PersonManager dialogSubject, CameraLocations location, MenuOptionType menuOptionType) //Date and time as other params possibly
    {
        string path = "Resources/";
        if(!dialogSubject)
        {
            //Load the no on to talk to dialog
            //CurrentInstance = (DialogInstance)Resources.Load("path");
            //return CurrentInstance;
        }
        else
        {
            switch (location)
            {
                case CameraLocations.DECK:
                    path += "Deck/";
                    break;
                case CameraLocations.DREAM:
                    path += "Dream/";
                    break;
                case CameraLocations.UP:
                    path += "BelowDeckUp/";
                    break;
                case CameraLocations.FORWARD:
                    path += "BelowDeckForward/";
                    break;
                case CameraLocations.RIGHT:
                    path += "BelowDeckRight/";
                    break;
                case CameraLocations.LEFT:
                    path += "BelowDeckLeft/";
                    break;
            }

            path += dialogSubject.Name + "/";

            CurrentInstance = (DialogInstance)Resources.Load(path);
        }

        return CurrentInstance;
    }
}