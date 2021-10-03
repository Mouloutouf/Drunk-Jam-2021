using UnityEngine;

public class DialogueInteraction : Interaction
{
    public GameObject dialogueBox;

    public override void Interact()
    {
        //dialogueBox.SetActive(true);

        base.Interact();
    }
}