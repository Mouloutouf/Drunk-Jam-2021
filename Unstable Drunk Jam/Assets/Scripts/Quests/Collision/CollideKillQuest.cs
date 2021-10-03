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

        collisionKill.killCount = 0;
    }

    public override bool Completion()
    {
        return collisionKill.killCount >= killAmount;
    }
}
