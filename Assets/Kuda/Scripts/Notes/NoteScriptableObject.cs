using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NoteScriptableObject", menuName = "Scriptable Objects/NoteScriptableObject")]
public class NoteScriptableObject : ScriptableObject
{
    public List<string> notesList = new();
    public Queue<string> notesQueue = new();
}
