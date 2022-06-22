using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEvent : MonoBehaviour
{
    public float hour;
    public float minute;
    public int dias;
  
    public Material dia;
    public Material medioDia;
    public Material noche;

    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
        TimeManager.OnHourChanged += TimeCheck;
        TimeManager.OnDiasChanged += TimeCheck;

    }
    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
        TimeManager.OnHourChanged -= TimeCheck;
        TimeManager.OnDiasChanged -= TimeCheck;
    }
    private void Update()
    {
        dias = TimeManager.Dias;
    }
    private void TimeCheck()
    {
        if (TimeManager.Hour == hour && TimeManager.Minute == minute)
        {
           
        }
      

        //Dia
        if (TimeManager.Hour == 6 && TimeManager.Minute >= 00)
        {
            
            RenderSettings.skybox = dia;
        }
        //MedioDia
        if (TimeManager.Hour == 18 && TimeManager.Minute >= 00)
        {
            Debug.Log("s");
            RenderSettings.skybox = medioDia;
        }
        //Noche
        if (TimeManager.Hour == 21 && TimeManager.Minute >= 00)
        {
            Debug.Log("s");
            RenderSettings.skybox = noche;
        }
    }
}
