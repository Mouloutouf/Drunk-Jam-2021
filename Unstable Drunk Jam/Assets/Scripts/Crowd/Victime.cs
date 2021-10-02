using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Victime : MonoBehaviour
{
    private int health;
    private int speed;
    private Material mat;
    private Vector3 destination;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SearchNewPosition()
    {
        if (Vector3.Distance(destination, transform.position) < 0.5f)
        {
            destination = transform.position;
            agent.destination = destination;
        }
    }
}
