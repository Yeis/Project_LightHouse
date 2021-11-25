using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class TurnOnLightHouse : MonoBehaviour, Interactable
{
    public int buttonNumber;
    public List<GameObject> objectsToActive;
    public List<DialogScriptableObject> dialogs;
    public List<AudioScriptableObject> audios;

    private EventController eventController;
    public AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
        animator =  GetComponent<Animator>();
    }

    public void InteractWith(GameObject player)
    {
        //ALways trigger animation
        animator.SetTrigger("FixLightHouse");
        foreach (var go in objectsToActive)
        {
            go.SetActive(true);
        }
        //Primer Faro entonces el orden de acciones es
        //1- Prender Faro
        //2- Audio
        //3- Dialogos
        foreach (AudioScriptableObject audio in audios)
        {
            eventController.AddEvent(new AudioEvent(audio));
        }
        foreach (DialogScriptableObject dialog in dialogs)
        {
            eventController.AddEvent(new DialogueEvent(dialog));
        }
        //Final
        if(buttonNumber == 3) {
            eventController.AddEvent(new EndEvent());
            audioSource.pitch = 0.2f;
        }

        // if(buttonNumber == 1) {
        //     foreach (AudioScriptableObject audio in audios)
        //     {
        //         eventController.AddEvent(new AudioEvent(audio));
        //     }
        //     foreach (DialogScriptableObject dialog in dialogs)
        //     {
        //         eventController.AddEvent(new DialogueEvent(dialog));
        //     }
        // //
        // } else if(buttonNumber == 2) {

        // }
    }

    public string GetInteractionText()
    {
        return "Press E to Fix LightHouse";
    }
}
