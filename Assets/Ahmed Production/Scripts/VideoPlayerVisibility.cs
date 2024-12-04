using UnityEngine;

public class VideoPlayerVisibility : MonoBehaviour
{
    public GameObject targetObject;

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}