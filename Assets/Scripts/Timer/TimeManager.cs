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

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Minute = PlayerPrefs.GetInt("Date_Minutes");
        Hour = PlayerPrefs.GetInt("Date_Hours");
        Dias = PlayerPrefs.GetInt("Date_Days");
        timer = minuteToRealTime;
    }

    void Update()
    {
        timer -=Time.deltaTime *10;
        if (timer <=0)
        {
            Minute++;
            PlayerPrefs.SetInt("Date_Minutes", Minute);
            OnMinuteChanged?.Invoke();
            if(Minute >=60)
            {
                Hour++;
                PlayerPrefs.SetInt("Date_Hours", Hour);
                Minute = 0;
                PlayerPrefs.SetInt("Date_Minutes", Minute);
                OnHourChanged?.Invoke();
                if (Hour>=24)
                {
                    Dias++;
                    PlayerPrefs.SetInt("Date_Days", Dias);
                    Hour = 0;
                    PlayerPrefs.SetInt("Date_Hours", Hour);
                    Minute = 0;
                    PlayerPrefs.SetInt("Date_Minutes", Minute);
                    OnDiasChanged?.Invoke();
                }
            }
            timer = minuteToRealTime; 
        }
    }
}
