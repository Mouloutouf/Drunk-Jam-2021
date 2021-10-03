using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKill : MonoBehaviour
{
    public CrowdManager crowdManager;

    [HideInInspector]
    public bool killActive;
    [HideInInspector]
    public int killCount;

    public LayerMask layerMask;

    public GameObject killFeedbackPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (!killActive) return;

        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            killCount++;

            if (killFeedbackPrefab != null) Instantiate(killFeedbackPrefab, collision.transform.position, Quaternion.identity);
            crowdManager.victimeList.Remove(collision.gameObject);
            Destroy(collision.gameObject);

            // Respawn a new victim
        }
    }
}
