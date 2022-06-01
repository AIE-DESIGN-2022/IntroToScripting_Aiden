using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    private Vector3 lastPos;
    private Transform obj;
    private GameObject skele;
    public float baseSpeed = 5;
    private float speed = 5;
    private float rotation;
    public float sprintMultiplier = 1.5F;
    private float backWalk = 0.5F;
    private float lastFire;
    public float fireDelay;
    public bool interacting;
    public bool disguised;
    public GameObject disguise;

    void Start()
    {
        obj = gameObject.transform;
        lastPos = obj.position;
        skele = obj.transform.GetChild(0).gameObject;
        speed = baseSpeed;
        rotation = speed * 30;
    }

    void Update()
    {

        //Movement
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, z);
        Vector3 rotation = new Vector3(0, x, 0);
        transform.Translate(movement * speed * Time.deltaTime);
        transform.Rotate(rotation * this.rotation * Time.deltaTime);

        //Stops player from sprinting while walking backwards
        if (Input.GetAxis("Vertical") < 0)
        {
            speed = baseSpeed * backWalk;
        }
        if (Input.GetAxis("Vertical") >= 0)
        {
            speed = baseSpeed;
        }


        //Sprint
        if (Input.GetAxis("Vertical") < 0)
        {
            
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = baseSpeed * sprintMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }

        // Animation

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > lastFire + fireDelay)
                {
                    skele.GetComponent<Animator>().SetTrigger("Attack");
                    lastFire = Time.time;
                    //disguised = false;
                }
           }
        else
        if (obj.position != lastPos)
        {
            lastPos = obj.position;
        }
        {

            if (Input.GetAxis("Vertical") > 0)
            {
                skele.GetComponent<Animator>().SetBool("Walk", true);
            }
            else if (Input.GetAxis("Vertical") <= 0)
            {
                skele.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                skele.GetComponent<Animator>().SetBool("Back", true);
            }
            else if (Input.GetAxis("Vertical") >= 0)
            {
                skele.GetComponent<Animator>().SetBool("Back", false);
            }
        }
        if (disguised == true)
        {
            disguise.gameObject.SetActive(true);
        }
        else if (disguised == false)
        {
            disguise.gameObject.SetActive(false);
        }
    }
}