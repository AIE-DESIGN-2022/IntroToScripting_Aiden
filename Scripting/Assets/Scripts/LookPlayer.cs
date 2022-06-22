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
        //Sets target to the currently active camera
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //Rotates Object on the Y Axis to face the target camaera, used for HUD elements in world
        Vector3 rot = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
        rot.y = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }
}
