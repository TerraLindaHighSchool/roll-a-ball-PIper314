using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance; 

    public GameObject hudContainer, gameOverPanel;
    public Text timeCounter;
    public bool gamePlaying { get; private set; }

    //private int
    private float startTime, elapsedTime;
    TimeSpan timePlaying;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;
        gameOverPanel.SetActive(false);

        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time; 
    }

    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }

    public void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
    }
}
