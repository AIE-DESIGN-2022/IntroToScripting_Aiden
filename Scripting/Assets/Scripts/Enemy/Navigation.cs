using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int nextLocation;
    private int currentDestination;
    public float distanceReachedThreshold;
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = -1;
        nextLocation = 0;
        agent = GetComponent<NavMeshAgent>();
        SetAgentDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[currentDestination].position);
        if(distanceToTarget <= distanceReachedThreshold)
        {
            SetAgentDestination();
        }
    }

    void SetAgentDestination()
    {
        if (patrolPoints.Length > nextLocation)
        {
            agent.SetDestination(patrolPoints[nextLocation].position);
            currentDestination = nextLocation;
            nextLocation++;
        }
        else
        {
            currentDestination = -1;
            nextLocation = 0;
            SetAgentDestination();
        }
    }
}
