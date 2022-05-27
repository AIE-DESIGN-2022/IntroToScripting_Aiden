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
    // Start is called before the first frame update
    void Start()
    {
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player").gameObject;
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
            if (currentSuspicion > 0 && playerInCone == false && currentSuspicion < maxSuspicion)
            {
                currentSuspicion -= Time.deltaTime;
                UpdateSuspicionMeter();
            }
            if (currentSuspicion < 0)
            {
                currentSuspicion = 0;
            }
            if (currentSuspicion > maxSuspicion)
            {
                currentSuspicion = maxSuspicion;
            }
            if (currentSuspicion > 0)
            {
                suspicionMeter.gameObject.SetActive(true);
            }
            if (currentSuspicion <= 0 || currentSuspicion >= maxSuspicion)
            {
                suspicionMeter.gameObject.SetActive(false);
            }
            if (currentSuspicion >= maxSuspicion)
            {
                suspicionMeter.gameObject.SetActive(false);
                exclamationMark.gameObject.SetActive(true);
                alerted = true;
            }
        }
        else if (alive == false)
        {
            exclamationMark.gameObject.SetActive(false);
            suspicionMeter.gameObject.SetActive(false);
            cone.gameObject.SetActive(false);
            transform.Rotate(-90, 0, 0);
            transform.position = new Vector3(transform.position.x, 1.0F, transform.position.z);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HurtBox")
        {
            gameObject.GetComponent<healthManager>().TakeDamage(damage);
        }
    }
    public void CollisionDetected(Detection childscript)
    {
        if (alive == true)
        {
            if (alerted == false)
            {
                if (theSpookySkeleton.GetComponent<Skeleton>().disguised == true)
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
                else if (theSpookySkeleton.GetComponent<Skeleton>().disguised == false)
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
    private void UpdateSuspicionMeter()
    {
        suspicionMeter.value = currentSuspicion;
    }
}
