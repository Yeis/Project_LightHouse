using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour, Interactable {

    public GameObject player;

    void Start() {

    }

    void Update() {

    }

    public void InteractWith(GameObject player) {
        Debug.Log(transform.position.x);
        player.transform.position = this.transform.position;
    }
}
