using UnityEngine;

public class GoToDestinationQuest : Quest
{
    public Transform destination;

    public Transform player;

    public float radius;

    public override bool Completion()
    {
        return Vector3.Distance(new Vector3(destination.position.x, 0f, destination.position.z), new Vector3(player.position.x, 0f, player.position.z)) <= radius;
    }
    private void OnDrawGizmos()
    {
        if (destination == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(destination.position, radius);
    }
}
