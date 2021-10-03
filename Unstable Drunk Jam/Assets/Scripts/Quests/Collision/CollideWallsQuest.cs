using UnityEngine;

public class CollideWallsQuest : Quest
{
    public int collisionAmount;
    public LayerMask layerMask;

    public CollisionCheck collisionCheck;

    public override void StartQuest()
    {
        base.StartQuest();

        collisionCheck.collisionCount = 0;
        collisionCheck.layerMask = layerMask;
    }

    public override bool Completion()
    {
        return collisionCheck.collisionCount >= collisionAmount;
    }
}