using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This script is required to check if the player has entered the trigger box of a child object of the enemy.
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        transform.parent.GetComponent<Enemy>().CollisionDetected(this);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            transform.parent.GetComponent<Enemy>().CollisionEnded(this);
    }
}
