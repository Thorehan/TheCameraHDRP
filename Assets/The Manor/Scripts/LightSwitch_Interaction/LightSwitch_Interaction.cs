using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch_Interaction : MonoBehaviour
{
    [Tooltip("The lights which should be toggled pressing this switch.")]
    public Light[] lights;
    [Tooltip("The state of the switch")]
    public bool ON;
    [Tooltip("The maximum distance in which you can interact with the switch")]
    public float maxDistance = 2;
    public Transform switchTransform;
    [Tooltip("Material of the lamp when the lights are turned ON")]
    public Material materialON;
    [Tooltip("Material of the lamp when the lights are turned OFF")]
    public Material materialOFF;
    [Tooltip("Mesh Renderer of the flame")]
    public MeshRenderer[] flameRenderer;

    public CrosshairCanvas crosshairScript;

    private AudioSource sound;
    private bool responding;
    public Vector3 originRotation;
    public Vector3 openRotation;
    private float r;
    private bool crosshairChange;

    [Tooltip("The key you have to press in order to turn on/off the lights (use the 'Naming convention' of Unity).")]
    public string keyToPress = "e";

    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        responding = true;
        sound = switchTransform.GetComponent<AudioSource>();
        if (ON == true) {
            for (int i = 0; i < lights.Length; i++) {
                if (materialON != null) {
                    lights[i].GetComponentInParent<MeshRenderer>().material = materialON;
                }
            }
            for (int i = 0; i < flameRenderer.Length; i++) {
                if (flameRenderer[i] != null) {
                    if (flameRenderer[i].enabled == false) {
                        flameRenderer[i].enabled = true;
                    }
                }
            }
        } else {
            for (int i = 0; i < lights.Length; i++) {
                if (materialOFF != null) {
                    lights[i].GetComponentInParent<MeshRenderer>().material = materialOFF;
                }
            }
            for (int i = 0; i < flameRenderer.Length; i++) {
                if (flameRenderer[i] != null) {
                    if (flameRenderer[i].enabled == true) {
                        flameRenderer[i].enabled = false;
                    }
                }
            }
        }
        r = 0;
    }

    void Update()
    {
        r += Time.deltaTime * 5;
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.transform == this.transform) {
            if (Input.GetKeyDown(keyToPress) && responding == true) {
                ON = !ON;
                StartCoroutine(respondingRoutine());
                r = 0;
                if (sound.clip != null) {
                    sound.Play();
                }
            }
            if (crosshairScript != null) {
                if (crosshairChange == false) {
                    crosshairChange = true;
                    crosshairScript.interactable = true;
                }
            }
        } else {
            if (crosshairScript != null) {
                if (crosshairChange == true) {
                    crosshairChange = false;
                    crosshairScript.interactable = false;
                }
            }
        }

        if (ON == true) {
            for (int i = 0; i < lights.Length; i++) {
                if (lights[i].enabled == false) {
                    lights[i].enabled = true;
                    if (materialON != null) {
                        lights[i].GetComponentInParent<MeshRenderer>().material = materialON;
                    }
                }
            }
            if (Vector3.Angle(openRotation, switchTransform.localRotation.eulerAngles) > 0.1F) {
                switchTransform.localRotation = Quaternion.Slerp(switchTransform.localRotation, Quaternion.Euler(openRotation), r);
            } else {
                switchTransform.localRotation = Quaternion.Euler(openRotation);
                r = 0;
            }
            for (int i = 0; i < flameRenderer.Length; i++) {
                if (flameRenderer[i] != null) {
                    if (flameRenderer[i].enabled == false) {
                        flameRenderer[i].enabled = true;
                    }
                }
            }
        } else {
            for (int i = 0; i < lights.Length; i++) {
                if (lights[i].enabled == true) {
                    lights[i].enabled = false;
                    if (materialOFF != null) {
                        lights[i].GetComponentInParent<MeshRenderer>().material = materialOFF;
                    }
                }
            }
            if (Vector3.Angle(originRotation, switchTransform.localRotation.eulerAngles) > 0.1F) {
                switchTransform.localRotation = Quaternion.Slerp(switchTransform.localRotation, Quaternion.Euler(originRotation), r);
            } else {
                switchTransform.localRotation = Quaternion.Euler(originRotation);
                r = 0;
            }
            for (int i = 0; i < flameRenderer.Length; i++) {
                if (flameRenderer[i] != null) {
                    if (flameRenderer[i].enabled == true) {
                        flameRenderer[i].enabled = false;
                    }
                }
            }
        }
    }

    IEnumerator respondingRoutine()
    {
        responding = false;
        float t = 0;
        while (t < 0.333F) {
            t += Time.deltaTime;
            yield return null;
        }
        responding = true;
    }
}
