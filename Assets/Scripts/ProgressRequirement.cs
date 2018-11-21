using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ProgressRequirement : ScriptableObject
{
    public List<KeyValuePair<string, bool>> MenuActionRequirements = new List<KeyValuePair<string, bool>>();
}

#if UNITY_EDITOR
public class MakeProgressRequirement
{
    class PRWindow : EditorWindow
    {
        int reqCount = 1;
        List<string> menuActions = new List<string>();

        [MenuItem("Assets/Create/ProgressRequirement")]
        public static void OpenPRWindow()
        {
            EditorWindow.GetWindow(typeof(PRWindow));
        }

        private void OnGUI()
        {
            reqCount = EditorGUILayout.IntField("Requirements", reqCount);
            EditorGUILayout.Space();

            if (reqCount < 1)
                reqCount = 1;

            if(reqCount > menuActions.Count)
            {
                for (int i = 0; i < reqCount - menuActions.Count; i++)
                {
                    menuActions.Add("");
                }
            }
            else if(reqCount < menuActions.Count)
            {
                for (int i = 0; i < menuActions.Count - reqCount; i++)
                {
                    menuActions.RemoveAt(menuActions.Count - 1);
                }
            }

            for (int i = 0; i < reqCount; i++)
            {
                menuActions[i] = EditorGUILayout.TextField("Menu Action " + (i + 1), menuActions[i]);
            }
            EditorGUILayout.Space();

            if(GUILayout.Button("Create"))
            {
                CreateProgressRequirement(menuActions);
            }
        }

        public static void CreateProgressRequirement(List<string> menuActions)
        {
            ProgressRequirement thePR = ScriptableObject.CreateInstance<ProgressRequirement>();

            for (int i = 0; i < menuActions.Count; i++)
            {
                thePR.MenuActionRequirements.Add(new KeyValuePair<string, bool>(menuActions[i], false));
            }

            AssetDatabase.CreateAsset(thePR, "Assets/Resources/ProgressRequirements/NewPR.asset");
            AssetDatabase.SaveAssets();

            Selection.activeObject = thePR;
        }
    }
}
#endif