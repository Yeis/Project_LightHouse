using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject pointsTo;
    public bool isActive;


    private void OnTriggerEnter(Collider other)
    {
        print("Detectamos algo");
        if(other.gameObject.tag == "Player" && isActive) {
           CharacterController cc =  other.gameObject.GetComponent<CharacterController>();
           cc.enabled = false;
           other.gameObject.transform.position = pointsTo.transform.position;
           cc.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        isActive= !isActive;
    }

}
