using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {
    public float acceleration = 30.0f;
    public float rotationSpeed = 5.0f;
    public float minimumSpeed = 0.0f, maximumSpeed = 200.0f, currentSpeed;
    private Vector3 movement;
    private Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        currentSpeed = minimumSpeed;
    }

    void Update() {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //We are not pressing any button so we should deaccelerate
        if (movement.z == 0) {
            print("Not Moving");
            currentSpeed = Mathf.Max(minimumSpeed, currentSpeed - (acceleration * Time.deltaTime));
        } else {
            currentSpeed = Mathf.Min(maximumSpeed, currentSpeed + (acceleration * Time.deltaTime));
        }

    }

    void FixedUpdate() {
        if (movement.z > 0.0f) {
            rigidbody.velocity = transform.right * currentSpeed * Time.fixedDeltaTime;
        }
        if (movement.z < 0.0f) {
            rigidbody.velocity = -transform.right * currentSpeed * Time.fixedDeltaTime;
        }

        if (movement.x > 0.0f) {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.fixedDeltaTime * rotationSpeed, Space.World);
        }
        if (movement.x < 0.0f) {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.fixedDeltaTime * rotationSpeed, Space.World);
        }
    }

}
