using UnityEditor;
using UnityEngine;

public class RemovePlayerPrefs : EditorWindow
{

    [MenuItem("Edit/Remove Player Prefs")]

    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}