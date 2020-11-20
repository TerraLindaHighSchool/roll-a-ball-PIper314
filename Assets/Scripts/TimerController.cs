using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;
    public bool gamePlaying { get; private set; }

    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if(gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        } 
    }
}
