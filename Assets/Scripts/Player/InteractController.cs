using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractController : MonoBehaviour {

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private TextMeshProUGUI interactText;
    [SerializeField]
    private RectTransform interactTextRoot;

    private Interactable pickUpItem;


    void Update() {
        InteractRay();

        if (HasItemTargetted()) {
            interactTextRoot.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                pickUpItem.InteractWith(gameObject);
            }
        } else {
            interactTextRoot.gameObject.SetActive(false);
        }
    }

    private void InteractRay() {
        Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 14f, Color.red);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 14f, layerMask)) {
            var hitItem = hitInfo.collider.GetComponent<Interactable>();
            if (hitItem == null) { pickUpItem = null; } else if (hitItem != null && hitItem != pickUpItem) {
                pickUpItem = hitItem;
                interactText.text = pickUpItem.GetInteractionText();
            }
        } else {
            pickUpItem = null;
        }
    }

    private bool HasItemTargetted() {
        return pickUpItem != null;
    }
}
