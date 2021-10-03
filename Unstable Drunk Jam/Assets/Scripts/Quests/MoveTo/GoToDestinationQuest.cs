using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoToDestinationQuest : Quest
{
    public List<Transform> destinations;
    private Transform destination;

    public Transform player;

    public float radius;

    public override void StartQuest()
    {
        base.StartQuest();

        int i = Random.Range(0, destinations.Count);
        destination = destinations[i];

        destination.gameObject.SetActive(true);
    }

    public override bool Completion()
    {
        return Vector3.Distance(new Vector3(destination.position.x, 0f, destination.position.z), new Vector3(player.position.x, 0f, player.position.z)) <= radius;
    }

    public override void EndQuest()
    {
        destination.gameObject.SetActive(false);

        base.EndQuest();
    }

    private void OnDrawGizmos()
    {
        if (destination == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(destination.position, radius);
    }
}
