using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    //public Text text;
    public TMP_Text text;
    public GameController gm;

    public int startTimeSec;
    public int startTimeMin;

    private int minTime;
    private int secTime;
    private float timer;
    private int secTimePass;

    public bool stopTimer;

    private void Start()
    {
        stopTimer = false;
        timer = 0;
        secTimePass = 0;
        minTime = 0;
        secTime = 0;//-1*(startTimeSec % 60);
        if (startTimeSec % 60 != 0)
        {
            startTimeMin += startTimeSec / 60;
            startTimeSec %= 60;
        }
        //formatting timer text
        if (startTimeSec < 10)
            text.text = startTimeMin + ":0" + startTimeSec;
        else
            text.text = startTimeMin + ":" + startTimeSec;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTimer)
        {
            timer += Time.deltaTime;
            if (Mathf.FloorToInt(timer) > secTimePass)
            {
                secTimePass++;
                UpdateTimerUI();

                gm.FireCanons(secTimePass - 1);
            }
        }
    }

    private void UpdateTimerUI()
    {
        secTime++;
        if (startTimeMin - minTime == 0 && startTimeSec - secTime == 0)//Check if Count down is at 0:00
        {
            Debug.Log("GameWon");
            stopTimer = true;
        }
        else
        {
            if (startTimeSec - secTime <= 0)
            {
                secTime = startTimeSec - 59;
                minTime++;
            }
        }
        //formatting timer text
        if (startTimeSec - secTime < 10)
        {
            text.text = (startTimeMin - minTime) + ":0" + (startTimeSec - secTime);
        }
        else
        {
            text.text = (startTimeMin - minTime) + ":" + (startTimeSec - secTime);
        }
    }


}
