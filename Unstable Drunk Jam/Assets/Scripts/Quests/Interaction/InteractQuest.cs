using UnityEngine;
using TMPro;

public class InteractQuest : Quest
{
    public int interactionAmount;

    public Interaction interaction;

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
    }
}
