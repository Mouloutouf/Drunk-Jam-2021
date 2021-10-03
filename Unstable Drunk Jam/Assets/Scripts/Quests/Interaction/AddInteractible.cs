using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInteractible : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    public GameObject interactionAreaPrefab;

    public Transform player;
    public GameObject interactDisplay;

    private GameObject interactionAreaObject;
    [HideInInspector]
    public InteractionArea interactionArea;

    public void AddToTarget()
    {
        Debug.Log(target);
        interactionAreaObject = Instantiate(interactionAreaPrefab, target);
        interactionArea = interactionAreaObject.GetComponent<InteractionArea>();
        interactionArea.player = player;
        interactionArea.interactDisplay = interactDisplay;
    }
    public void RemoveFromTarget()
    {
        Destroy(interactionAreaObject);
    }
}
