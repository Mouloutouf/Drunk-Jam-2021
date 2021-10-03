using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [HideInInspector]
    public bool colliding;
    [HideInInspector]
    public int collisionCount;

    [HideInInspector]
    public LayerMask layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            Debug.Log("collision");
            colliding = true;
            collisionCount++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
