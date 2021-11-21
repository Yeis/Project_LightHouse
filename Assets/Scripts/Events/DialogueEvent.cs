using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class DialogueEvent : GameEvent
{
    private DialogScriptableObject dialogScriptableObject;
    private UIController uIController;

    public DialogueEvent(DialogScriptableObject dialogScriptableObject, int delayInMiliSeconds = 0) : base(delayInMiliSeconds)
    {
        this.dialogScriptableObject = dialogScriptableObject;
        this.dialogScriptableObject.hasEnded = false;
        uIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();

    }

    protected internal override bool HasEnded()
    {
        return this.dialogScriptableObject.hasEnded;
    }

    protected internal override bool IsReady()
    {
        return (uIController != null && dialogScriptableObject != null); 
    }

    protected internal override void Run()
    {
        uIController.DisplayDialog(this.dialogScriptableObject);
    }
}
