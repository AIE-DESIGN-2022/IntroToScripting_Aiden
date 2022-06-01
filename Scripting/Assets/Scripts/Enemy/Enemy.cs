using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float damage;
    private GameObject cone;
    private Transform target;
    public Slider suspicionMeter;
    public float maxSuspicion;
    public float currentSuspicion;
    public bool playerInCone;
    public GameObject exclamationMark;
    public bool alerted;
    private GameObject theSpookySkeleton;
    public bool alive;
    public GameObject disguiseInteract;
    // Start is called before the first frame update
    void Start()
    {
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player").gameObject;
        disguiseInteract = gameObject.transform.GetChild(4).gameObject;
        cone = gameObject.transform.GetChild(2).gameObject;
        target = theSpookySkeleton.transform;
        currentSuspicion = 0;
        suspicionMeter.maxValue = maxSuspicion;
        alerted = false;
        alive = true;
        UpdateSuspicionMeter();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            //Constantly lowers suspicion meter if player is not in the AI's cone of vision.
            if (currentSuspicion > 0 && playerInCone == false && currentSuspicion < maxSuspicion)
            {
                currentSuspicion -= Time.deltaTime;
                UpdateSuspicionMeter();
            }
            //Stops suspicion meter from going above max value or below 0.
            if (currentSuspicion < 0)
            {
                currentSuspicion = 0;
            }
            if (currentSuspicion > maxSuspicion)
            {
                currentSuspicion = maxSuspicion;
            }
            //Activates or deactivates visable suspicion meter if the value is above 0 and below max value.
            if (currentSuspicion > 0)
            {
                suspicionMeter.gameObject.SetActive(true);
            }
            if (currentSuspicion <= 0 || currentSuspicion >= maxSuspicion)
            {
                suspicionMeter.gameObject.SetActive(false);
            }
            //Makes enemy alerted if the suspicion meter reaches max value. Change has effect on navigation script.
            if (currentSuspicion >= maxSuspicion)
            {
                if (alerted == false)
                {
                    theSpookySkeleton.GetComponent<SkeletonController>().disguised = false;
                }
                suspicionMeter.gameObject.SetActive(false);
                exclamationMark.gameObject.SetActive(true);
                alerted = true;
            }
        }
        //Stops movement and turns enemy to an interactable object once dead.
        else if (alive == false)
        {
            exclamationMark.gameObject.SetActive(false);
            suspicionMeter.gameObject.SetActive(false);
            cone.gameObject.SetActive(false);
            transform.Rotate(-90, 0, 0);
            transform.position = new Vector3(transform.position.x, 1.0F, transform.position.z);
            disguiseInteract.SetActive(true);
        }
    }
    //Takes damage when colliding with players damaging hitbox. Calls HealthManager script.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HurtBox")
        {
            gameObject.GetComponent<healthManager>().TakeDamage(damage);
        }
    }
    //Changes AI behavior based on if the player is in the AI's cone of vision.
    public void CollisionDetected(Detection childscript)
    {
        if (alive == true)
        {
            if (alerted == false)
            {
                //Faces player if they are wearing a disguise while in the AI's cone of vision.
                if (theSpookySkeleton.GetComponent<SkeletonController>().disguised == true)
                {
                    Vector3 rot = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
                    rot.x = rot.z = 0;
                    transform.rotation = Quaternion.Euler(rot);
                    if (currentSuspicion < maxSuspicion)
                    {
                        currentSuspicion += Time.deltaTime;
                    }
                    playerInCone = true;
                    UpdateSuspicionMeter();
                }
                //Immediatly sets to alerted if the player is not wearing a disguise while in the AI's cone of vision.
                else if (theSpookySkeleton.GetComponent<SkeletonController>().disguised == false)
                {
                    if (currentSuspicion < maxSuspicion)
                    {
                        currentSuspicion = maxSuspicion;
                    }
                    playerInCone = true;
                    UpdateSuspicionMeter();
                }
            }
        }
    }
    public void CollisionEnded(Detection childscript)
    {
        playerInCone = false;
    }
    //Updates visable suspicion meter.
    private void UpdateSuspicionMeter()
    {
        suspicionMeter.value = currentSuspicion;
    }
}