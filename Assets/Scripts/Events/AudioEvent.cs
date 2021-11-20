using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class AudioEvent : GameEvent
{
    private AudioScriptableObject audioScriptableObject;
    private AudioController audioController;

    public AudioEvent(AudioScriptableObject audioScriptableObject, int delayInMiliSeconds = 0) : base(delayInMiliSeconds)
    {
        this.audioScriptableObject = audioScriptableObject;
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    protected internal override bool HasEnded()
    {
        return !audioController.IsPlaying(audioScriptableObject.audioClip);
    }

    protected internal override bool IsReady()
    {
        return (audioController != null && audioScriptableObject != null);
    }

    protected internal override void Run()
    {
        audioController.PlayAudioClip(audioScriptableObject);
    }
}
