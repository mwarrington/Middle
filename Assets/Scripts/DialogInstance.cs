using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DialogInstance : ScriptableObject
{
    public bool HasBeenDisplayed,
                Repeatable;
    public string Speaker,
                  Content;
    public DialogInstance NextLine;
    public Menu NextMenu;
}

#if UNITY_EDITOR
public class MakeDialogInstance
{
    [MenuItem("Assets/Create/DialogInstance")]
    public static void CreateDialogInstance()
    {
        DialogInstance theDI = ScriptableObject.CreateInstance<DialogInstance>();

        AssetDatabase.CreateAsset(theDI, "Assets/Resources/DialogInstances/NewDI.asset");
        AssetDatabase.SaveAssets();

        Selection.activeObject = theDI;
    }
}
#endif