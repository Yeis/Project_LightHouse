using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseController : MonoBehaviour
{
    public float speed;
    private GameObject lampGameObject;
    // Start is called before the first frame update
    void Start()
    {
        //The lamp is always te first object
        lampGameObject = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        lampGameObject.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.World);
        //lampGameObject.transform.
    }
}
