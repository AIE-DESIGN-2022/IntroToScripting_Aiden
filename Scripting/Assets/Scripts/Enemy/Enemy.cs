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
    // Start is called before the first frame update
    void Start()
    {
        cone = gameObject.transform.GetChild(2).gameObject;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentSuspicion = 0;
        suspicionMeter.maxValue = maxSuspicion;
        alerted = false;
        UpdateSuspicionMeter();
    }

    // Update is called once per frame
    void Update()
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HurtBox")
        {
            gameObject.GetComponent<healthManager>().TakeDamage(damage);
        }
    }
    public void CollisionDetected(Detection childscript)
    {
        if (alerted == false)
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
    }
    public void CollisionEnded(Detection childscript)
    {
        Debug.Log("child no longer collided");
        playerInCone = false;
    }
    private void UpdateSuspicionMeter()
    {
        suspicionMeter.value = currentSuspicion;
    }
}
