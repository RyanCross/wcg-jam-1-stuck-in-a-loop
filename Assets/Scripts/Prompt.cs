using System.Collections;
using static System.Single;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompt : MonoBehaviour
{
    public bool shouldDisplayPrompt { get; set; }
    public float timeTillFadeStart;
    public float promptDisplayLength;

    private bool promptShown = false;
    private int curTextAlpha;

    public TMP_Text text;
    public GameObject timerObject;

    private void Awake()
    {
        shouldDisplayPrompt = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldDisplayPrompt == true)
        {
            if (promptShown == false)
            {
                text.color = Color.white; // display the prompt
                promptShown = true;
            }
            fadePrompt();
        }
    }

    void showPrompt()
    {
        text.color = Color.white;
    }

    void fadePrompt()
    {
        timeTillFadeStart -= Time.deltaTime;
        if (timeTillFadeStart <= 0)
        {
            text.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(text.color.a, 0f, .005f));
        }

        curTextAlpha = (int) text.color.a; 
        if (curTextAlpha.Equals(0))
        {
            startTimer();
        }
    }

    void startTimer()
    {
        timerObject.SetActive(true); // timer prefab must start disabled
    }
}
