using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class EnableGameObjectEvent : GameEvent
{
    private GameObject gameObject;
    private bool hasEnded;
    public EnableGameObjectEvent(GameObject gameObject)
    {
        this.gameObject = gameObject;
        hasEnded = false;
    }

    protected internal override bool HasEnded()
    {
        return this.hasEnded;
    }

    protected internal override bool IsReady()
    {
        return (gameObject != null && !hasEnded);
    }

    protected internal override void Run()
    {
       this.gameObject.SetActive(true);
       this.hasEnded = true;
    }
}
