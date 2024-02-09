using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer
{
    public string ID { get; private set; }
    public float Ratio { get { return TimeElapsed / Duration; } }
    public float Duration { get; private set; }
    public bool Repeating { get { return resetTimerOnComplete; } }

    public float TimeElapsed { get; private set; }
    private bool resetTimerOnComplete;
    private Action onCompleteCallback;



    public Timer(float duration, Action onCompleteCallback, bool resetTimerOnComplete = true)
    {
        if(duration <= 0)
        {
            Debug.LogError("A timer was given a duration of 0 or less. This timer will not work.");
        }

        Duration = duration;
        this.resetTimerOnComplete = resetTimerOnComplete;
        this.onCompleteCallback = onCompleteCallback;
    }

    public void UpdateClock()
    {
        if(TimeElapsed < Duration)
        {
            TimeElapsed += Time.deltaTime;

            if(TimeElapsed >= Duration)
            {
                if (onCompleteCallback != null)
                    onCompleteCallback();

                if(resetTimerOnComplete == true)
                {
                    ResetTimer();
                }
            }
        }
    }

    public void ResetTimer()
    {
        TimeElapsed = 0f;
    }

    public void ModifyDuration(float mod)
    {
        Duration += mod;

        if (Duration <= 0f)
        {
            Duration = 0f;
        }

        if (TimeElapsed > Duration)
        {
            TimeElapsed = 0f;
        }
    }

    public void SetDuration(float duration) {
        Duration = duration;

        if (Duration <= 0f) {
            Duration = 0f;
        }

        if (TimeElapsed > Duration) {
            TimeElapsed = 0f;
        }
    }


}
