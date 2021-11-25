using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pierInteractionController : MonoBehaviour, Interactable {

    public GameObject player;

    [SerializeField]
    private BoatMovement movementController;
    [SerializeField]
    private GameObject boat;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject selfPier;

    void Start() {

    }

    void Update() {

    }

    public void InteractWith(GameObject player) {
        //stop boat
        Rigidbody boatBody = boat.GetComponent<Rigidbody>();
        boatBody.velocity = new Vector3(0, 0, 0);
        boatBody.rotation = Quaternion.identity;

        player.transform.parent = null;
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = true;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = true;
        playerMovement.spawnPoint = spawnPoint;

        gameObject.layer = 6;
        boat.layer = 7;
        movementController.enabled = false;

        BoatController boatController = boat.GetComponent<BoatController>();
        boatController.pier = selfPier;
    }

    public string GetInteractionText() {
        return "Get off";
    }

}