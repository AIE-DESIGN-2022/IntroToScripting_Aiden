using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Transform[] telephones;
    private NavMeshAgent agent;
    private Enemy enemyScript;
    public int nextLocation;
    public int currentDestination;
    public float distanceReachedThreshold;
    public bool suspicousOfPlayer;
    public GameObject theSpookySkeleton;
    public GameObject parentEnemy;
    private DistanceComparer distanceComparer;
    private EnemyManager enemyManager;
    private bool check;
    private int i;
    // Start is called before the first frame update
    void Awake()
    {
        check = false;
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player");
        enemyManager = FindObjectOfType<EnemyManager>();
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Patrol")
            {
                patrolPoints.Add(child.transform);
            }
        }
        suspicousOfPlayer = false;
        currentDestination = -1;
        nextLocation = 0;
        enemyScript = GetComponent<Enemy>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            //Checks if player is alive before setting navigation.
            if (enemyScript.alive == true)
            {
                //Makes enemy suspicious of player if the player is in their cone of vision and is currently interacting with something.
                if (theSpookySkeleton.GetComponent<SkeletonController>().interacting == true && this.enemyScript.playerInCone)
                {
                    suspicousOfPlayer = true;
                }
                else
                {
                    suspicousOfPlayer = false;
                }
                //Stops all movement if the AI is suspicious of the player
                if (suspicousOfPlayer == false || enemyScript.alerted == true)
                {
                    agent.isStopped = false;
                }
                if (suspicousOfPlayer == true && enemyScript.alerted == false)
                {
                    agent.isStopped = true;
                }
                //Sets destination to next point once the AI is within the distance to target threshold.
                float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[currentDestination].position);
                if (distanceToTarget <= distanceReachedThreshold)
                {
                    SetAgentDestination();
                }
            }
            //Stops all movement is AI is not alive.
            else if (enemyScript.alive == false)
            {
                agent.isStopped = true;

            }
            //Sets destination when AI becomes alerted. (Called from Enemy script)
            if (enemyScript.alerted == true)
            {
                SetAgentDestination();
            }
            //Sorts telephone array based on distance from AI.
            Array.Sort(telephones, distanceComparer);
        }
    }

    //Sets destination.
    public void SetAgentDestination()
    {
        if (enemyScript.alerted == false)
        {
            //Sets destination to next patrol point if not alerted.
            if (patrolPoints.Count > nextLocation)
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
        else if (enemyScript.alerted == true)
        {
            agent.speed = 3;
            agent.SetDestination(telephones[0].transform.position);
        }
    }
    //Compares distance of telephones
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
    public void FacePlayer()
    {
        Vector3 rot = Quaternion.LookRotation(theSpookySkeleton.transform.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
        agent.angularSpeed = 0;
    }
    public void DontFacePlayer()
    {
        agent.angularSpeed = 120;
    }
    public void DeclairPhones()
    {
        if (check == false)
        {
            telephones = enemyManager.telephonesList.ToArray();
            agent.enabled = true;
            check = true;
            distanceComparer = new DistanceComparer(transform);
        }
    }
}
