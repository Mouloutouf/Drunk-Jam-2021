using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToInteractionArea : MonoBehaviour
{
    public InteractQuest interactQuest;

    public SwitchCamera switchCamera;

    public AddInteractible addInteractible;

    public void SetTarget()
    {
        addInteractible.target = switchCamera.victim.transform;
        interactQuest.interaction = addInteractible.interactionArea.interaction;
    }
}
