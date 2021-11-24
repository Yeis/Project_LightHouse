using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour, Interactable {

    public GameObject player;

    [SerializeField]
    private BoatMovement movementController;
    [SerializeField]
    private GameObject pier;


    void Start() {

    }

    void Update() {

    }

    public void InteractWith(GameObject player) {
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;

        player.transform.parent = this.transform;
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        gameObject.layer = 0;
        pier.layer = 7;
        movementController.enabled = true;
    }
}
