using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearButton : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] objRemove;
    public KeyCode theKey = KeyCode.None;
    public bool triggered;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (Input.GetKeyDown(theKey))
            {
                if (triggered == false)
                {
                    obj[i].SetActive(true);
                    objRemove[i].SetActive(false);
                    triggered = true;
                }
                else if (triggered == true)
                {
                    obj[i].SetActive(false);
                    objRemove[i].SetActive(true);
                    triggered = false;
                }
            }
        }
    }
}
