using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            transform.parent.GetComponent<Interactable>().playerCollided = true;
    }
    //Checks when players exits triggerbox to communicate with parent object.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            transform.parent.GetComponent<Interactable>().playerCollided = false;
    }
}
