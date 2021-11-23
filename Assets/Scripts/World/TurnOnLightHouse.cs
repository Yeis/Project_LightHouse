using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class TurnOnLightHouse : MonoBehaviour, Interactable
{
    public int buttonNumber;
    public GameObject lightHouseLight;
    List<DialogScriptableObject> dialogs;
    List<AudioScriptableObject> audios;

    private EventController eventController;

    // Start is called before the first frame update
    void Start()
    {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
    }

    public void InteractWith(GameObject player)
    {
        //Primer Faro entonces el orden de acciones es
        //1- Prender Faro
        //2- Audio
        //3- Dialogos
        if(buttonNumber == 1) {
            lightHouseLight.SetActive(true);
            foreach (AudioScriptableObject audio in audios)
            {
                eventController.AddEvent(new AudioEvent(audio));
            }
            foreach (DialogScriptableObject dialog in dialogs)
            {
                eventController.AddEvent(new DialogueEvent(dialog));
            }
        }
    }
}
