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
        if (obj.position != lastPos)
        {
            GetComponent<Animator>().SetBool("Walk", true);
            lastPos = obj.position;
        }
        else if (obj.position == lastPos)
        {
            GetComponent<Animator>().SetBool("Walk", false);
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
