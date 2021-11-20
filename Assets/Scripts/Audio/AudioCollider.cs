using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamTeam.Lighthouse.Core.Events;

public class AudioCollider : MonoBehaviour
{
    [SerializeField]
    private AudioScriptableObject audioScriptableObject;
    public bool isActive;
    private EventController eventController;
    // Start is called before the first frame update
    void Start()
    {
        eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            print("AudioCollider");
            eventController.AddEvent(new AudioEvent(audioScriptableObject));
        }
    }
}
