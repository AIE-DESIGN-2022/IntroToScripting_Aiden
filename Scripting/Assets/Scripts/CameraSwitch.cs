using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject disabledObject;
    public GameObject enabledObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        // Disables one object and enables another when the player enters this triggerbox, used to switch cameras between rooms
        if (other.gameObject.tag == "Player")
        {
            disabledObject.SetActive(false);
            enabledObject.SetActive(true);
        }
    }
}
