using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "AudioScriptableObject", menuName = "ScriptableObjects/AudioScriptableObject", order = 0)]
public class AudioScriptableObject : ScriptableObject
{
    public AudioClip audioClip;
    public float volume;
}