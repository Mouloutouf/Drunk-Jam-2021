using UnityEngine;
using TMPro;

public class ChineseInteractQuest : Quest
{
    public int interactionAmount;

    public DialogueInteraction interaction;

    [TextArea]
    public string dialogueString;
    public TextMeshProUGUI dialogueText;

    private void Start()
    {
        dialogueText.text = dialogueString;
    }

    public override void StartQuest()
    {
        base.StartQuest();

        interaction.active = true;
        interaction.interactionCount = 0;
    }

    public override bool Completion()
    {
        return interaction.interactionCount >= interactionAmount;
    }

    public override void EndQuest()
    {
        base.EndQuest();

        interaction.active = false;
        interaction.dialogueBox.SetActive(false);
    }
}
