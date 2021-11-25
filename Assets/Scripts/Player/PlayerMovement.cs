using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController controller;
    public float speed = 12;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject spawnPoint;

    Vector3 velocity;
    bool isGrounded;
    public float gravity = -9.81f;

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        // falling check
        if (transform.position.y < -65) {
            CharacterController characterController = GetComponent<CharacterController>();
            characterController.enabled = false;
            transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 2, spawnPoint.transform.position.z);
            characterController.enabled = true;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
