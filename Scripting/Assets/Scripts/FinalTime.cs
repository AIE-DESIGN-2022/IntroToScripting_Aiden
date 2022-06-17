using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour
{
    public Text text;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeclairTime()
    {
        text.text = "I just waisted:" + string.Format("{00:00}:{01:00}", timer.minuteCount, timer.secondsCount);
    }
}
