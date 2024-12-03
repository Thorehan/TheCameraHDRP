using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;

public class QualityTextures : MonoBehaviour
{
    public Text textQuality;
    public Text textReflection;
    public PlanarReflectionProbe[] reflections;

    public int Quality = 1;
    public bool Reflection = false;

    void Start()
    {
        if (Reflection == true) {
            for (int i = 0; i < reflections.Length; i++) {
                reflections[i].enabled = true;
            }
        } else {
            for (int i = 0; i < reflections.Length; i++) {
                reflections[i].enabled = false;
            }
        }
        QualitySettings.globalTextureMipmapLimit = Quality;
    }

    void Update()
    {
        if (Input.GetKeyDown("1")) {
            Quality = 2;
            QualitySettings.globalTextureMipmapLimit = Quality;
        } else if (Input.GetKeyDown("2")) {
            Quality = 1;
            QualitySettings.globalTextureMipmapLimit = Quality;
        } else if (Input.GetKeyDown("3")) {
            Quality = 0;
            QualitySettings.globalTextureMipmapLimit = Quality;
        }
        if (Input.GetKeyDown("r")) {
            if (Reflection == true) {
                Reflection = false;
                for (int i = 0; i < reflections.Length; i++) {
                    reflections[i].enabled = false;
                }
            } else {
                Reflection =true;
                for (int i = 0; i < reflections.Length; i++) {
                    reflections[i].enabled = true;
                }
            }
        }

        if (Quality == 0) {
            textQuality.text = "TEXTURE QUALITY: HIGH";
        } else if (Quality == 1) {
            textQuality.text = "TEXTURE QUALITY: MEDIUM";
        } else if (Quality == 2) {
            textQuality.text = "TEXTURE QUALITY: LOW";
        }

        if (Reflection == true) {
            textReflection.text = "MIRRORS: ENABLED";
        } else {
            textReflection.text = "MIRRORS: DISABLED";
        }
    }
}
