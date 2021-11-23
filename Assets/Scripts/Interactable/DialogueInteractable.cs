using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class DialogueInteractable : MonoBehaviour, Interactable
{ 
    public DialogScriptableObject dialog;
    private EventController eventController;

    void Start()
    {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
    }

    public void InteractWith(GameObject player)
    {
        Debug.Log("Interacting with Note");
        eventController.AddEvent(new DialogueEvent(dialog));
    }
}
