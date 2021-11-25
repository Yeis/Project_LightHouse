using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class TurnOnLightHouse : MonoBehaviour, Interactable {
    public int buttonNumber;
    public List<GameObject> objectsToActive;
    public List<DialogScriptableObject> dialogs;
    public List<AudioScriptableObject> audios;

    private EventController eventController;
    private UIController uIController;
    public AudioSource audioSource;
    private Animator animator;

    public GameObject player;
    public GameObject boat;
    private bool isActive;

    // Start is called before the first frame update
    void Start() {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
        uIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        animator = GetComponent<Animator>();
        isActive = true;
    }

    public void InteractWith(GameObject player) {
        //ALways trigger animation
        animator.SetTrigger("FixLightHouse");

        //Only activate buttons once
        if(!isActive) return;
        foreach (var go in objectsToActive) {
            go.SetActive(true);
        }
        //Primer Faro entonces el orden de acciones es
        //1- Prender Faro
        //2- Audio
        //3- Dialogos
        foreach (AudioScriptableObject audio in audios) {
            eventController.AddEvent(new AudioEvent(audio));
        }
        foreach (DialogScriptableObject dialog in dialogs) {
            eventController.AddEvent(new DialogueEvent(dialog));
        }
        if (buttonNumber == 2) {
            print("????????????????");
            uIController.BlackOut();
            CharacterController characterController = player.GetComponent<CharacterController>();
            characterController.enabled = false;

            player.transform.parent = boat.transform;
            player.transform.position = new Vector3(boat.transform.position.x, boat.transform.position.y + 2, boat.transform.position.z);

            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            boat.gameObject.layer = 0;

            BoatController boatController = boat.GetComponent<BoatController>();
            boatController.pier.layer = 7;
            boatController.movementController.enabled = true;

            uIController.FadeOut();
        }
        //Final
        if (buttonNumber == 3) {
            audioSource.pitch = 0.3f;
            eventController.AddEvent(new EndEvent());
        }
        isActive = false;
    }

    public string GetInteractionText() {
        return "Press E to Fix LightHouse";
    }
}
