using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private Vector3 lastPos;
    private Quaternion lastRotation;
    private Transform obj;
    private GameObject skele;
    private NavMeshAgent agent;
    public float baseSpeed = 5;
    private float speed = 5;
    private float rotation;
    public float sprintMultiplier = 1.5F;
    private float lastFire;
    public float fireDelay;


    void Start()
    {
        obj = gameObject.transform;
        lastPos = obj.position;
        agent = GetComponent<NavMeshAgent>();
        skele = obj.transform.GetChild(0).gameObject;
        speed = baseSpeed;
        rotation = speed * 50;
    }

    void Update()
    {
        //Movement
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);

        //Rotation
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotation * Time.deltaTime);
        }

        //Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = baseSpeed * sprintMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }

        // Animation

        if (obj.position == lastPos)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > lastFire + fireDelay)
                {
                    skele.GetComponent<Animator>().SetTrigger("Attack");
                    lastFire = Time.time;
                }
            }
        }
        else
        if (obj.position != lastPos)
        {
            lastPos = obj.position;
        }
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                skele.GetComponent<Animator>().SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                skele.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                skele.GetComponent<Animator>().SetBool("Back", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                skele.GetComponent<Animator>().SetBool("Back", false);
            }
        }
    }
}

