using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDiasChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Dias { get; private set; }

    private float minuteToRealTime = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 22;
        Dias = 0;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -=Time.deltaTime *10;
        if (timer <=0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if(Minute >=60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
                if (Hour>=24)
                {
                    Dias++;
                    Hour = 0;
                    Minute = 0;
                    OnDiasChanged?.Invoke();
                }
            }
            timer = minuteToRealTime; 
        }
    }
}
