using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideKillQuest : Quest
{
    public int killAmount;

    public CollisionKill collisionKill;

    public override void StartQuest()
    {
        base.StartQuest();

        collisionKill.killActive = true;
        collisionKill.killCount = 0;
    }

    public override bool Completion()
    {
        return collisionKill.killCount >= killAmount;
    }

    public override void EndQuest()
    {
        collisionKill.killActive = false;

        base.EndQuest();
    }
}
