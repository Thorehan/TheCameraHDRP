using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Tooltip("The related light.")]
    public Light flashlight;
    [Tooltip("The key you have to press in order to toggle the flashlight (use the 'Naming convention' of Unity).")]
    public string keyToPress = "f";
    private AudioSource sound;

    void Start()
    {
        flashlight.enabled = false;
        sound = flashlight.transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            flashlight.enabled = !flashlight.enabled;
            if (sound.clip != null) {
                sound.Play();
            }
        }
    }
}
