using UnityEngine;

public class DialogueInteraction : Interaction
{
    public GameObject dialogueBox;

    public override void Interact()
    {
        Debug.Log("You're talking to me ?");
        //dialogueBox.SetActive(true);

        base.Interact();
    }
}