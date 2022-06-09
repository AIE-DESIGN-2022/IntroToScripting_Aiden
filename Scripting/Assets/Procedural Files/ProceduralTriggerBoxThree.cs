using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTriggerBoxThree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Checks when players enters triggerbox to communicate with parent object.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Trigger")
            transform.parent.GetComponent<Procedural>().triggerThreeCollided = true;
    }
    //Checks when players exits triggerbox to communicate with parent object.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Trigger")
            transform.parent.GetComponent<Procedural>().triggerThreeCollided = false;
    }
}
