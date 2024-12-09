using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DepthOfFieldChange : MonoBehaviour
{
    public Volume postProcessing;

    private DepthOfField DOF;
    public float DOFnearStart;
    public float DOFnearEnd;
    public float DOFfarStart;
    public float DOFfarEnd;

    private Bloom Bloom;
    public float BloomIntensity;

    void Start()
    {
        postProcessing.profile.TryGet<DepthOfField>(out DOF);
        DOFnearStart = DOF.nearFocusStart.value;
        DOFnearEnd = DOF.nearFocusEnd.value;
        DOFfarStart = DOF.farFocusStart.value;
        DOFfarEnd = DOF.farFocusEnd.value;
        postProcessing.profile.TryGet<Bloom>(out Bloom);
        BloomIntensity = Bloom.dirtIntensity.value;
    }

    // Update is called once per frame
    void Update()
    {

            DOF.nearFocusStart.value =DOFnearStart;
            DOF.nearFocusEnd.value = DOFnearEnd;
            DOF.farFocusStart.value = DOFfarStart;
            DOF.farFocusEnd.value =  DOFfarEnd;

            Bloom.dirtIntensity.value = BloomIntensity;
    }
}
