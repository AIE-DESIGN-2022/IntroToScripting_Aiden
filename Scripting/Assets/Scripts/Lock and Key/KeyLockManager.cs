using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockManager : MonoBehaviour
{
    public GameObject[] keys;
    public GameObject[] locks;
    // Start is called before the first frame update
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        locks = GameObject.FindGameObjectsWithTag("Lock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
