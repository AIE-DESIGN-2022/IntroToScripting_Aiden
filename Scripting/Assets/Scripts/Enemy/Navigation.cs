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
        //Checks if player is alive before setting navigation.
        if (gameObject.GetComponent<Enemy>().alive == true)
        {
            //Makes enemy suspicious of player if the player is in their cone of vision and is currently interacting with something.
            if (theSpookySkeleton.GetComponent<SkeletonController>().interacting == true && this.gameObject.GetComponent<Enemy>().playerInCone)
            {
                suspicousOfPlayer = true;
            }
            else
            {
                suspicousOfPlayer = false;
            }
            //Stops all movement if the AI is suspicious of the player
            if (suspicousOfPlayer == false || gameObject.GetComponent<Enemy>().alerted == true)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            }
            if (suspicousOfPlayer == true && gameObject.GetComponent<Enemy>().alerted == false)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }
            //Sets destination to next point once the AI is within the distance to target threshold.
            float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[currentDestination].position);
            if (distanceToTarget <= distanceReachedThreshold)
            {
                SetAgentDestination();
            }
        }
        //Stops all movement is AI is not alive.
        else if (gameObject.GetComponent<Enemy>().alive == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            
        }
        //Sets destination when AI becomes alerted. (Called from Enemy script)
        if (gameObject.GetComponent<Enemy>().alerted == true)
        {
            SetAgentDestination();
        }
        //Sorts telephone array based on distance from AI.
        Array.Sort(telephones, distanceComparer);
    }

    //Sets destination.
    void SetAgentDestination()
    {
        if (gameObject.GetComponent<Enemy>().alerted == false)
        {
            //Sets destination to next patrol point if not alerted.
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
        //Sets destination to nearest telephone if alerted.
        else if (gameObject.GetComponent<Enemy>().alerted == true)
        {
            agent.SetDestination(telephones[0].transform.position);
        }
    }
    //Compares distance of telephones (not sure how it works exactly got it from google)
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
