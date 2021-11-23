using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, Interactable
{

    public Transform pointsTo;

    public void InteractWith(GameObject player)
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.gameObject.transform.position = pointsTo.position;
        cc.enabled = true;
    }
}
