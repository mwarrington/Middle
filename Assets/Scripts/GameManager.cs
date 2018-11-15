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
}