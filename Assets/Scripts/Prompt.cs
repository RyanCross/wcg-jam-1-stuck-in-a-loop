using System.Collections;
using static System.Single;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompt : MonoBehaviour
{
    public TMP_Text text;

    public float timeToFade;
    public bool shouldDisplayPrompt { get; set; }
    public GameObject timerObject;
    private bool promptShown = false;
    private float timeTillFade;
    private Color fadeColor = new Color(1f, 1f, 1f, 0f);
    private int textAlpha;

    private void Awake()
    {
        shouldDisplayPrompt = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.clear;
        timeTillFade = timeToFade;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldDisplayPrompt == true)
        {
            if (promptShown == false)
            {
                text.color = Color.white;
                promptShown = true;
            }
            fadePrompt();
        }
    }

    void fadePrompt()
    {
        timeTillFade = timeTillFade - Time.deltaTime;
        if (timeTillFade <= 0)
        {
            text.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(text.color.a, 0f, .005f));
        }

        textAlpha = (int) text.color.a;
        
        if (textAlpha.Equals(0))
        {
            startTimer();
        }
    }

    void startTimer()
    {
        timerObject.SetActive(true);
    }
}
