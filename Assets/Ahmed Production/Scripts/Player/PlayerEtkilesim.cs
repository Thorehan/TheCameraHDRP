using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEtkilesim : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private InputManager inputManager;
    
    void Start()
    {
        cam = GetComponent<PlayerMouseLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            EtkilesimScript etkilesim = hitInfo.collider.GetComponent<EtkilesimScript>();
            if (hitInfo.collider.GetComponent<EtkilesimScript>() != null)
            {
                playerUI.UpdateText(etkilesim.promptMessage);

                if (inputManager.onFoot.Etkilesim.triggered)
                {
                    etkilesim.BaseEtkilesim();
                }
            }
        }
    }
}
