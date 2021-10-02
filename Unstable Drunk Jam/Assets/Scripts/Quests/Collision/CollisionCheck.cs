using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [HideInInspector]
    public bool colliding;
    [HideInInspector]
    public int collisionCount;

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
        collisionCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
