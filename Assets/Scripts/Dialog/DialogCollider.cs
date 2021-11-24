using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class DialogCollider : MonoBehaviour
{
    [SerializeField]
    private List<DialogScriptableObject> dialogs;
    public bool isActive;
    private EventController eventController;
    void Start()
    {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            print("DialogueCollider");
            foreach (var dialog in dialogs)
            {
                eventController.AddEvent(new DialogueEvent(dialog));
            }
            isActive = false;
        }
    }
}
