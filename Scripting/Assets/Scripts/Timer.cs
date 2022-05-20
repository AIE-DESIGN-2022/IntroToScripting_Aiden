using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeScale;
    public float timerAmount;
    private float timerText;
    private float minutes;
    private float seconds;
    private Text timerHud;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        timerHud = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            timeScale = timerAmount - Time.timeSinceLevelLoad;
            minutes = Mathf.FloorToInt(timeScale / 60);
            seconds = Mathf.FloorToInt(timeScale % 60);
            timerHud.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}