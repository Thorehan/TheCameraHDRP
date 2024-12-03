using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    Canvas canv;
    Canvas crosshairCanv;

    void Start()
    {
        canv = GetComponent<Canvas>();
        crosshairCanv = GameObject.Find("Crosshair").GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown("q")) {
            canv.enabled = !canv.enabled;
        }
        if (Input.GetKeyDown("z")) {
            crosshairCanv.enabled = !crosshairCanv.enabled;
        }
    }
}
