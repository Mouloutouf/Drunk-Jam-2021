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

    public void AddToTarget()
    {
        Debug.Log(target);
        interactionAreaObject = Instantiate(interactionAreaPrefab, target);
        var ina = interactionAreaObject.GetComponent<InteractionArea>();
        ina.player = player;
        ina.interactDisplay = interactDisplay;
    }
    public void RemoveFromTarget()
    {
        Destroy(interactionAreaObject);
    }
}
