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

    public void ToggleDialogBox(DialogInstance dialogData)
    {
        DialogBox.SetActive(!DialogBox.activeSelf);

        if (DialogBox.activeSelf)
        {
            if (dialogData)
                CurrentInstance = dialogData;
            ApplyDialogInstance();
        }
    }

    public void ProgressDialog()
    {
        if (_menuNext)
        {
            _menuNext = false;
            ToggleDialogBox(null);
            _menuManager.LoadMenu(CurrentInstance.NextMenu, 0);
        }
        else if (CurrentInstance)
            ApplyDialogInstance();
        else
            ToggleDialogBox(null);
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
}