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

    [Header("FX")]
    public GameObject death_FX;
    public GameObject damage_FX;
    public GameObject spawn_FX;

    [Header("ANIMATION")]
    public Animator animator;
    Vector3 currentLocation;
    Vector3 baseLocation;
    float velocity;

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
        Spawn();
        //minMaxSpeed = new Vector2(2, 6);
        agent = GetComponent<NavMeshAgent>();

        if (speedVariation) agent.speed = Random.Range(minMaxSpeed.x, minMaxSpeed.y);

        SelectNewDestination();

        baseLocation = currentLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        GetVelocity();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(destination, transform.position) < 5.0f && moving == true)
        {
            StartCoroutine(Wait(stopMaxTime));
        }
    }

    void GetVelocity()
    {
        currentLocation = transform.position;
        velocity = Vector3.Distance(baseLocation, currentLocation);
        baseLocation = currentLocation;

        if (animator != null)
        {
            animator.SetFloat("RunSpeed", velocity * 10);
        }

        Debug.LogWarning("velocity = " + velocity);
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

    void Spawn()
    {
        SpawnFX();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamageFX();

        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        DeathFX();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    ///// FX
    ///

    public void SpawnFX()
    {
        if (spawn_FX != null)
        {
            Instantiate(spawn_FX, transform.position, Quaternion.identity);
        }
    }
    public void DamageFX()
    {
        if (damage_FX != null)
        {
            Instantiate(damage_FX, transform.position, Quaternion.identity);
        }
    }
    public void DeathFX()
    {
        if (death_FX != null)
        {
            Instantiate(death_FX, transform.position, Quaternion.identity);
        }
    }
}
