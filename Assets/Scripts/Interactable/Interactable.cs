using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable {
    void InteractWith(GameObject player);
    string GetInteractionText();
}
