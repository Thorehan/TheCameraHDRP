using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private Transform rayOriginTransform;

    private Interactable currentInteractable;

    void Update()
    {
        CheckForInteractableObjects();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.BaseInteract();
        }
    }

    void CheckForInteractableObjects()
    {
        RaycastHit hit;
        Vector3 rayOrigin = rayOriginTransform != null ? rayOriginTransform.position : transform.position + Vector3.up * 0.5f;
        Vector3 rayDirection = transform.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, interactRange, interactableLayer))
        {
            currentInteractable = hit.collider.GetComponent<Interactable>();
            if (currentInteractable != null)
            {
                playerUI.GetComponent<PlayerUI>().UpdateText(currentInteractable.promptMessage);
            }
        }
        else
        {
            currentInteractable = null;
            playerUI.GetComponent<PlayerUI>().UpdateText("");
        }

        Debug.DrawRay(rayOrigin, rayDirection * interactRange, Color.red);
    }
}