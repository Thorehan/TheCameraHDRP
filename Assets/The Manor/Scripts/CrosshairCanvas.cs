using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCanvas : MonoBehaviour
{
    private RectTransform crosshair;
    public bool interactable;
    
    void Start()
    {
        crosshair = transform.GetChild(0).GetComponent<RectTransform>();
    }

    void Update()
    {
        if (interactable == false) {
            crosshair.sizeDelta = Vector2.Lerp(crosshair.sizeDelta, new Vector2(8, 8), Time.deltaTime * 4);
        } else {
            crosshair.sizeDelta = Vector2.Lerp(crosshair.sizeDelta, new Vector2(24, 24), Time.deltaTime * 4);
        }
    }
}
