using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookPlayer : MonoBehaviour {

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
        Vector3 rot = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }
}
