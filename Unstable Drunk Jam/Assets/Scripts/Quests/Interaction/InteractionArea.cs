using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public bool active { get => interaction.active; }

    public Interaction interaction;

    public Transform player;
    public Transform interactible;

    private Vector3 interactiblePos { get => new Vector3(interactible.position.x, 0f, interactible.position.z); }
    private Vector3 playerPos { get => new Vector3(player.position.x, 0f, player.position.z); }

    public float range;

    public GameObject interactDisplay;
    private bool displayIsActive;
    [HideInInspector]
    public bool canInteract;

    private void Update()
    {
        if (!active)
        {
            if (displayIsActive) interactDisplay.SetActive(false);
            return;
        }

        if (Vector3.Distance(interactiblePos, playerPos) <= range)
        {
            canInteract = true;
            interactDisplay.SetActive(true);
            displayIsActive = true;
        }
        else if (displayIsActive)
        {
            canInteract = false;
            interactDisplay.SetActive(false);
        }

        if (canInteract)
        {
            Debug.Log("u");
            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction.Interact();
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (interactible == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactible.position, range);
    }
}
