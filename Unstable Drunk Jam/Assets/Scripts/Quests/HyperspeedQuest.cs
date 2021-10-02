using UnityEngine;

public class HyperspeedQuest : Quest
{
    public Transform destination;

    public ThirdPersonMovement player;

    public float radius;

    public float boostedSpeed;

    public override void StartQuest()
    {
        base.StartQuest();

        player.speed = boostedSpeed;
    }

    public override bool Completion()
    {
        return Vector3.Distance(new Vector3(destination.position.x, 0f, destination.position.z), new Vector3(player.transform.position.x, 0f, player.transform.position.z)) <= radius;
    }

    

    private void OnDrawGizmos()
    {
        if (destination == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(destination.position, radius);
    }
}