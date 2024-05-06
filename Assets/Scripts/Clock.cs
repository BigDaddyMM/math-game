using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    private DateTime startTime;

    void Start()
    {
        // Store the initial time when the script starts
        startTime = DateTime.Now;
        UpdateTimer();
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        // Calculate the elapsed time since the script started
        TimeSpan elapsedTime = DateTime.Now - startTime;

        // Calculate rotations based on elapsed time
        float secondsRotation = -(float)elapsedTime.TotalSeconds * 6f;
        float minutesRotation = -(float)elapsedTime.TotalMinutes * 6f;
        float hoursRotation = -(float)elapsedTime.TotalHours * 30f;

        // Update rotations of clock hands
        secondHand.transform.localRotation = Quaternion.Euler(secondsRotation, 0, 0);
        minuteHand.transform.localRotation = Quaternion.Euler(minutesRotation, 0, 0);
        hourHand.transform.localRotation = Quaternion.Euler(hoursRotation, 0, 0);
    }
}