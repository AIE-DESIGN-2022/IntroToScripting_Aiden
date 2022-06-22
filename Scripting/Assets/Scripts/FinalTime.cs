using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTime : MonoBehaviour
{
    public float time;
    public Timer timer;
    public float secondsCount;
    public int minuteCount;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeclairTime()
    {
        timer = FindObjectOfType<Timer>();
        secondsCount = timer.secondsCount;
        minuteCount = timer.minuteCount;   
    }
}
