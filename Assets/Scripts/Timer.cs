using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public float secondsDisplay = 0;
    public TextMeshProUGUI timerText; //using TMP because it autoscales text and its just better

    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            //send a Lose message if win state has not yet been achieved
            timeRemaining = 0;
            timerIsRunning = false; 
        }
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeRemaining)
    {
        string timeDisplay = Mathf.FloorToInt(timeRemaining).ToString();

        if (timeDisplay == "3")
        {
            timerText.color = new Color(Color.red.r - .25f, Color.red.g, Color.red.b);
        }
        else if (timeDisplay == "2")
        {
            timerText.color = new Color(Color.red.r - .125f, Color.red.g, Color.red.b);
        }
        else if (timeDisplay == "1")
        {
            timerText.color = Color.red;     
        }

        timerText.SetText(timeDisplay);
    }
}
