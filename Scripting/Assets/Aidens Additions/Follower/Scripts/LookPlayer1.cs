using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookPlayer1 : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent; 

    // Use this for initialization
	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.LookAt(target);
    }
}
