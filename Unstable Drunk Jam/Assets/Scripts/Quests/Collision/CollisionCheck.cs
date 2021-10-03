using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    [HideInInspector]
    public bool colliding;
    [HideInInspector]
    public int collisionCount;

    [HideInInspector]
    public LayerMask layerMask;

    public UnityEvent onCollisionEnter;
    public UnityEvent onCollisionExit;

    [Header("FX")]
    public GameObject collision_FX;

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            var c = collision.GetContact(0);
            CollisionFX(c.point);

            Debug.Log("collision");
            colliding = true;
            collisionCount++;

            onCollisionEnter.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;

        onCollisionExit.Invoke();
    }

    void CollisionFX(Vector3 position)
    {
        if (collision_FX != null) Instantiate(collision_FX, position, Quaternion.identity);
    }
}
