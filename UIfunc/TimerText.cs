using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerText : MonoBehaviour
{

    private Text timerText;
    private float second;
    private int minute;
    private int hour;

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        second += Time.deltaTime;

        if (minute > 60)
        {
            hour++;
            minute = 0;
        }
        if (second > 60f)
        {
            minute += 1;
            second = 0;
        }

        timerText.text = hour.ToString() + ":" + minute.ToString("00") + ":" + second.ToString("f2");
        //Debug.Log(timerText.text);
    }
}