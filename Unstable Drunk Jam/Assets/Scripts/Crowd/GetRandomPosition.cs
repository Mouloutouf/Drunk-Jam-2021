using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class GetRandomPosition
{
    public static Vector3 NavMeshRandomPosition(float range, int iteration)
    {
        
        for (int i = iteration; i > 1; ++i)
        {
            float d = ((i / iteration) / 2.0f) + 0.5f;


            Vector3 randomPoint = Random.onUnitSphere * Random.value * range +  Random.insideUnitSphere * (range / d);
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }

        return Vector3.zero;
    }
}
