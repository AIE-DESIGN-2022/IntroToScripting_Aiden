using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitText : MonoBehaviour
{
    public float rando;
    public Text wait;
    // Start is called before the first frame update
    void Start()
    {
        rando = Random.Range(0, 7);
        if (rando == 0)
        {
            wait.text = "Please Wait";
        }
        if (rando == 1)
        {
            wait.text = "Wait.";
        }
        if (rando == 2)
        {
            wait.text = "Begin Waiting";
        }
        if (rando == 3)
        {
            wait.text = "Wait Now";
        }
        if (rando == 4)
        { 
            wait.text = "Hold your horses buddy";
        }
        if (rando == 5)
        {
            wait.text = "Wait?";
        }
        if (rando == 6)
        {
            wait.text = "Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait Wait ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
