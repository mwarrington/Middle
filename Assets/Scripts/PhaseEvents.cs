using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

//Phase events contain data on when dialog boxes should be opened from menu selections based on the phase
public class PhaseEvents : ScriptableObject
{
    public List<PhaseEvent> events = new List<PhaseEvent>();
    public int MyPhaseIndex;

    public bool ContainsLoadType(DialogLoadType loadType)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if(events[i].LoadType == loadType)
            {
                return true;
            }
        }

        return false;
    }
}

public class PhaseEvent
{
    public DialogLoadType LoadType;
    public CameraLocations EventLocation;
}