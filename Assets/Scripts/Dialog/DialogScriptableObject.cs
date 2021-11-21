using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DialogScriptableObject", menuName = "ScriptableObjects/DialogScriptableObject", order = 0)]
public class DialogScriptableObject : ScriptableObject {
    
    public List<string> sentences;
    public float textSpeed;
    public float timeBetweenLines;
    public TMP_FontAsset fontAsset;
    public int fontSize;

    public bool hasEnded = false;

}