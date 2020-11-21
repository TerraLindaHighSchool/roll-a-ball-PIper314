using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    float timer;
    float seconds;
    float minutes;

    bool start;

    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimerIncrement();
    }

    void TimerIncrement()
    {
        if (start)
        {
            timer += Time.deltaTime;
            seconds = timer % 60;
            minutes = timer / 60;

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void startTimer()
    {
        start = true;
    }

    public void stopTimer()
    {
        start = false;
    }

    public void resetTimer()
    {
        start = false;
        timer = 0;
        timerText.text = "00:00"; 
    }
}
