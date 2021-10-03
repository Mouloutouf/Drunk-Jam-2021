using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToInteractionArea : MonoBehaviour
{
    public SwitchCamera switchCamera;

    public AddInteractible addInteractible;

    public void SetTarget()
    {
        addInteractible.target = switchCamera.victim.transform;
    }
}
