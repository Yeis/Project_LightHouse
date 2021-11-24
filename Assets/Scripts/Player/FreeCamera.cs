using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float sensitivity = 1f;
    Vector3 currentEulerAngles;

    private void Start() {
        currentEulerAngles = Camera.main.transform.eulerAngles;
    }
    void Update()
    {
        var c = Camera.main.transform;
        //modifying the Vector3, based on input multiplied by speed and time
        currentEulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sensitivity;
        c.eulerAngles = currentEulerAngles;

        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }
}

