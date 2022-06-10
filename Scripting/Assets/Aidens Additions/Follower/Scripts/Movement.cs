using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 lastPos;
    public Transform obj; // drag the object to monitor here
    public float threshold = 0.0f; // minimum displacement to recognize a 


    void Start()
    {
        lastPos = obj.position;
    }

    void Update()
    {
        Vector3 offset = obj.position - lastPos;
        if (offset.x > threshold)
        {
            lastPos = obj.position; // update lastPos
                                    // code to execute when X is getting bigger
            obj.GetComponent<Animator>().SetTrigger("Walk");

        }
        else
        if (offset.x < -threshold)
        {
            lastPos = obj.position; // update lastPos
                                    // code to execute when X is getting smaller 
            obj.GetComponent<Animator>().SetTrigger("Walk");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<Animator>().SetTrigger("Die");

        }
    }
}
