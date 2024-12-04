using UnityEngine;

public class CameraRightClickControl : MonoBehaviour
{
    public Vector3 adjustedPosition;
    public float transitionSpeed = 5f;

    private Vector3 originalPosition;
    private bool isAdjusted = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAdjusted = !isAdjusted;
        }

        Vector3 targetPosition = isAdjusted ? adjustedPosition : originalPosition;

        Quaternion targetRotation = isAdjusted ? Quaternion.identity : transform.localRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * transitionSpeed);

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * transitionSpeed);
    }
}
