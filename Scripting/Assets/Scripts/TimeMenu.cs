using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMenu : MonoBehaviour
{
    public FinalTime finalTime;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        finalTime = FindObjectOfType<FinalTime>();
        text.text = "You Waisted: " + string.Format("{00:00}:{01:00}", finalTime.minuteCount, finalTime.secondsCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
