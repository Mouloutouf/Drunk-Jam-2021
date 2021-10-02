using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Victime : MonoBehaviour
{
    public int movementRange = 100;

    private int health;
    private Material mat;
    private Vector3 destination;

    public NavMeshAgent agent;
    private float pathPrecision;
    public float stopMaxTime;

    public Vector2 minMaxSpeed;
    public bool speedChangeOnDestination = false;
    public bool speedVariation = false;

    private bool moving = false;

    // GETTERS & SETTERS
    public void SetupVictim(float pathP, int maxRange, float stopT, Vector2 mmSpeed, bool speedChange, bool speedV)
    {
        pathPrecision = pathP;
        movementRange = maxRange;
        stopMaxTime = stopT;

        minMaxSpeed = mmSpeed;
        speedChangeOnDestination = speedChange;
        speedVariation = speedV;
    }

    // Start is called before the first frame update
    void Start()
    {
        //minMaxSpeed = new Vector2(2, 6);
        agent = GetComponent<NavMeshAgent>();

        if (speedVariation) agent.speed = Random.Range(minMaxSpeed.x, minMaxSpeed.y);

        SelectNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(destination, transform.position) < 5.0f && moving == true)
        {
            StartCoroutine(Wait(stopMaxTime));
        }
    }

    void SelectNewDestination()
    {
        moving = true;
        destination = GetRandomPosition.NavMeshRandomPosition((float)movementRange, 10);
        agent.SetDestination(destination);

        if (speedChangeOnDestination)
        {
            agent.speed = Random.Range(minMaxSpeed.x, minMaxSpeed.y);
        }
    }

    IEnumerator Wait(float stopMT)
    {
        float rngTime = Random.Range(0, stopMT);
        moving = false;
        yield return new WaitForSeconds(rngTime);
        SelectNewDestination();
    }
}
