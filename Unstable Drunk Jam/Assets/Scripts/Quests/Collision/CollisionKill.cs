using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKill : MonoBehaviour
{
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

            Instantiate(killFeedbackPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            // Respawn a new victim
        }
    }
}
