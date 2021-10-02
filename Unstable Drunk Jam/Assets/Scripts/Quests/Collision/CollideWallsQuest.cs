public class CollideWallsQuest : Quest
{
    public int collisionAmount;

    public CollisionCheck collisionCheck;

    public override void StartQuest()
    {
        base.StartQuest();

        collisionCheck.collisionCount = 0;
    }

    public override bool Completion()
    {
        return collisionCheck.collisionCount >= collisionAmount;
    }
}