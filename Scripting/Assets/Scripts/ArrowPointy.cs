using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class ArrowPointy : MonoBehaviour {

    public List<GameObject> target;

    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        //Rotates Object on the Y Axis to face the target camaera, used for HUD elements in world
        if (target.Count > 0)
        {
            Vector3 rot = Quaternion.LookRotation(target[0].transform.position - transform.position).eulerAngles;
            rot.x = rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
            target = target.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
        }
    }
}
