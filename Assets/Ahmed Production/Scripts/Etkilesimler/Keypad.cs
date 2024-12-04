using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : EtkilesimScript
{
    private GameObject denemeEtkilesim;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void Etkilesim()
    {
        Debug.Log("Etkilesti" + gameObject.name);
        Destroy(gameObject);
    }
}
