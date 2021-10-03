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

    [Header("FX")]
    public GameObject collision_FX;

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            CollisionFX(collision.transform.position);
            Debug.Log("collision");
            colliding = true;
            collisionCount++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    void CollisionFX(Vector3 position)
    {
        Instantiate(collision_FX, position, Quaternion.identity);
    }
}
