using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject lasers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lasers.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            lasers.SetActive(false);
        }
    }
}