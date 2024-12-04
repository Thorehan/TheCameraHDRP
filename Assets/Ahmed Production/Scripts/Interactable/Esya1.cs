using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esya1 : Interactable
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        Debug.Log("interacted with" + gameObject.name);
    }
}
