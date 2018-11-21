using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public DialogInstance CurrentInstance;
    //private DialogInstance NextDialogInstance;
    public GameObject DialogBox;
    public Text Speaker,
                Content;

    private MenuManager _menuManager;
    private bool _menuNext;

    private void Start()
    {
        _menuManager = FindObjectOfType<MenuManager>();
    }

    public void ToggleDialogBox()
    {
        DialogBox.SetActive(!DialogBox.activeSelf);

        if (DialogBox.activeSelf)
        {
            ApplyDialogInstance();
        }
    }

    public void ProgressDialog()
    {
        if (_menuNext)
        {
            _menuNext = false;
            ToggleDialogBox();
            _menuManager.LoadMenu(CurrentInstance.NextMenu, Vector3.zero);
        }
        else if (CurrentInstance)
            ApplyDialogInstance();
        else
            ToggleDialogBox();
    }

    private void ApplyDialogInstance()
    {
        Speaker.text = CurrentInstance.Speaker;
        Content.text = CurrentInstance.Content;

        if (CurrentInstance.NextLine)
            CurrentInstance = CurrentInstance.NextLine;
        else if (CurrentInstance.NextMenu)
        {
            _menuNext = true;
        }
        else
            CurrentInstance = null;
    }

    public void FindCurrentDialog(CameraLocations location, int phase, string dialogSubject) //Date and time as other params possibly
    {
        string path = "Resources/DialogInstances/";

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
            default:
                break;
        }

        path += "Phase " + phase;

        path += "/" + dialogSubject + "1";

        CurrentInstance = (DialogInstance)Resources.Load(path);
    }
}