using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothScaleOnRightClick : MonoBehaviour
{
    public Vector3 targetScale;

    private Vector3 originalScale;

    private bool isAtTarget = false;

    public float smoothSpeed = 5f;

    private bool isScaling = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isScaling)
        {
            isAtTarget = !isAtTarget;

            StartCoroutine(SmoothScale(isAtTarget ? targetScale : originalScale));
        }
    }

    System.Collections.IEnumerator SmoothScale(Vector3 target)
    {
        isScaling = true;

        while (Vector3.Distance(transform.localScale, target) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * smoothSpeed);
            yield return null;
        }

        transform.localScale = target;
        isScaling = false;
    }
}