using System.Collections;
using System;
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
    public Transform[] telephones;
    private DistanceComparer distanceComparer;
    // Start is called before the first frame update
    void Start()
    {
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player");
        suspicousOfPlayer = false;
        currentDestination = -1;
        nextLocation = 0;
        agent = GetComponent<NavMeshAgent>();
        distanceComparer = new DistanceComparer(transform);
        SetAgentDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().alive == true)
        {
            if (theSpookySkeleton.GetComponent<Skeleton>().interacting == true && this.gameObject.GetComponent<Enemy>().playerInCone)
            {
                suspicousOfPlayer = true;
            }
            else
            {
                suspicousOfPlayer = false;
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
        else if (gameObject.GetComponent<Enemy>().alive == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            
        }
        if (gameObject.GetComponent<Enemy>().alerted == true)
        {
            SetAgentDestination();
        }
        Array.Sort(telephones, distanceComparer);
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
            agent.SetDestination(telephones[0].transform.position);
        }
    }
    public class DistanceComparer : IComparer<Transform>
    {
        private Transform target;

        public DistanceComparer(Transform distanceToTarget)
        {
            target = distanceToTarget;
        }

        public int Compare(Transform a, Transform b)
        {
            var targetPosition = target.position;
            return Vector3.Distance(a.position, targetPosition).CompareTo(Vector3.Distance(b.position, targetPosition));
        }
    }
}
