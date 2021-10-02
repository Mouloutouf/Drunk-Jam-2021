using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdManager : MonoBehaviour
{
    public int victimeNumber = 10;
    public float respawnSpeed = 2.0f;
    public float maxSpawnRadius = 10.0f;
    public List<GameObject> victimeList = new List<GameObject>();
    public GameObject victimePrefab;

    [Header("Victime Behavior")]
    public float victimPathPrecision = 5.0f;
    public int victimPathMaxRange = 50;

    public Vector2 minMaxSpeed;
    public bool speedChangeOnDestination = true;
    public bool speedVariation = true;

    public float stopMaxTime = 5.0f;

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
            Vector3 rngPosition = GetRandomPosition.NavMeshRandomPosition(maxSpawnRadius,30);
            victimeList.Add(Instantiate(victimePrefab, rngPosition, Quaternion.identity));
            victimePrefab.GetComponent<Victime>().SetupVictim(
                victimPathPrecision,
                victimPathMaxRange,
                stopMaxTime,
                minMaxSpeed,
                speedChangeOnDestination,
                speedVariation);
        }
    }
}
