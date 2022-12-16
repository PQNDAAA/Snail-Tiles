using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image loading;

    public float seconds = 0;
    public float minutes = 0;

    public float timerRemaining = 0;
    float totalTimer = 0;

    float fillamount;

    public bool isStart = false;

    Text timerTxt;

    void Start()
    {
        isStart = true;

        timerTxt = GetComponent<Text>();

       CalculationTimeRemaining();
    }

    void Update()
    {
        if (isStart)
        {
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
                FillLoading();
            }
                if(seconds <= 0)
                {
                    if(minutes > 0)
                    {
                        minutes--;
                        seconds = 59;
                    } 
                    else 
                    {
                    isStart=false;
                    }
                }
        }
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }

    public void FillLoading()
    {
        timerRemaining -= Time.deltaTime;
        float fill = timerRemaining / totalTimer;
        loading.fillAmount = fill;
    }
    public void CalculationTimeRemaining()
    {
        if (minutes > 0)
        {
            timerRemaining += minutes * 60;
        }
        if (seconds > 0)
        {
            timerRemaining += seconds;
        }

        totalTimer = timerRemaining;
    }
}
