using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Rendering.HighDefinition;

namespace UnityStandardAssets.Effects
{
    public class FireLight : MonoBehaviour
    {
        private float m_Rnd;
        private bool m_Burning = true;
        private HDAdditionalLightData m_Light;
        public float intensitySpeed = 0.5F;
        public float intensityLight = 1;
        private Vector3 startPosition;
        private float startIntensity;

        private void Start()
        {
            m_Rnd = Random.value* 100;
            m_Light = GetComponent<HDAdditionalLightData>();
            startPosition = transform.localPosition;
            startIntensity = m_Light.intensity;   
        }


        private void Update()
        {
            if (m_Burning)
            {
                m_Light.intensity = 500 * Mathf.PerlinNoise(m_Rnd + Time.time + 0.5F, m_Rnd + 1.5F + Time.time* intensityLight) + startIntensity;
                float x = Mathf.PerlinNoise(m_Rnd + 0 + Time.time*2, m_Rnd + 1 + Time.time*2) - 0.5f;
                float y = Mathf.PerlinNoise(m_Rnd + 2 + Time.time*2, m_Rnd + 3 + Time.time*2) - 0.5f;
                float z = Mathf.PerlinNoise(m_Rnd + 4 + Time.time*2, m_Rnd + 5 + Time.time*2) - 0.5f;
                transform.localPosition = startPosition + new Vector3(x, y, z)* (intensitySpeed / 10);
            }
        }


        public void Extinguish()
        {
            m_Burning = false;
            m_Light.enabled = false;
        }
    }
}
