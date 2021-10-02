using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdManager : MonoBehaviour
{
    public int victimeNumber = 10;
    public float respawnSpeed = 2.0f;
    public float maxSpawnRadius = 10.0f;
    public List<Victime> victimeList = new List<Victime>();
    public GameObject victimePrefab;

    void Start()
    {
        SpawnVictime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnVictime()
    {
        for (int i = 0; i < victimeNumber; i++)
        {
            Vector3 rngPosition = NavMeshRandomPosition(maxSpawnRadius);
            Instantiate(victimePrefab, rngPosition, Quaternion.identity);
        }
    }

    Vector3 NavMeshRandomPosition(float range)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return Vector3.zero;
    }
}
