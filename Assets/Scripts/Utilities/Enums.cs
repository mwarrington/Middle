using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    DIALOG,
    MENU,
    PLAYER,
    NONE
}

public enum EmotionalStates
{
    DISGUSTED,
    DEPRESSED
}

public enum PhysicalHealthStates
{
    INTENSEPAIN,
    NEUTRAL
}

public enum MenuOptionType
{
    LOADDIALOG,
    LOADMENU,
    LOADANIM,
    CHANGECAMERA
}

public enum CameraLocations
{
    UP,
    FORWARD,
    LEFT,
    RIGHT,
    DECK,
    DREAM
}

public enum DialogLoadType
{
    CAMERACHANGE,
    MENU
}