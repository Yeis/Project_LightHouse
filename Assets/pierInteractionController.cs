using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pierInteractionController : MonoBehaviour, Interactable {

    public GameObject player;

    [SerializeField]
    private BoatMovement movementController;
    [SerializeField]
    private GameObject boat;

    void Start() {

    }

    void Update() {

    }

    public void InteractWith(GameObject player) {
        //stop boat
        Rigidbody boatBody = boat.GetComponent<Rigidbody>();
        boatBody.velocity = new Vector3(0, 0, 0);

        player.transform.parent = null;
        player.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + 4, transform.localPosition.z);

        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = true;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = true;

        gameObject.layer = 6;
        boat.layer = 7;
        movementController.enabled = false;

    }
}
