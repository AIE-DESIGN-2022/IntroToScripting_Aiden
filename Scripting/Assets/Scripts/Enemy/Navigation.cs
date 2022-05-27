using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    public int nextLocation;
    public int currentDestination;
    public float distanceReachedThreshold;
    public bool suspicousOfPlayer;
    public GameObject theSpookySkeleton;
    public GameObject parentEnemy;
    public Transform telephone;
    // Start is called before the first frame update
    void Start()
    {
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player");
        suspicousOfPlayer = false;
        currentDestination = -1;
        nextLocation = 0;
        agent = GetComponent<NavMeshAgent>();
        SetAgentDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Enemy>().playerInCone == true && theSpookySkeleton.GetComponent<Skeleton>().interacting == true)
        {
            suspicousOfPlayer=true;
        }
        else
        {
            suspicousOfPlayer=false;
        }
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[currentDestination].position);
            if (distanceToTarget <= distanceReachedThreshold)
            {
                SetAgentDestination();
            }
        if (suspicousOfPlayer == false || gameObject.GetComponent<Enemy>().alerted == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
        if (suspicousOfPlayer == true && gameObject.GetComponent<Enemy>().alerted == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void SetAgentDestination()
    {
        if (gameObject.GetComponent<Enemy>().alerted == false)
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
        else if (gameObject.GetComponent<Enemy>().alerted == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            agent.SetDestination(telephone.position);
        }
    }
}
