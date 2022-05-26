using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookPlayer : MonoBehaviour {

    public Transform target;


    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Vector3 rot = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }
}
