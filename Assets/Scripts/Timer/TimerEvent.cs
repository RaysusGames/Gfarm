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
    public GameObject[] estado;
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
            estado[0].SetActive(true);
            estado[1].SetActive(false);
            estado[2].SetActive(false);


        }
        //MedioDia
        if (TimeManager.Hour == 18 && TimeManager.Minute >= 00)
        {
            Debug.Log("s");
            RenderSettings.skybox = medioDia;
            estado[0].SetActive(false);
            estado[1].SetActive(true);
            estado[2].SetActive(false);
        }
        //Noche
        if (TimeManager.Hour == 21 && TimeManager.Minute >= 00)
        {
            Debug.Log("s");
            RenderSettings.skybox = noche;
            estado[0].SetActive(false);
            estado[1].SetActive(false);
            estado[2].SetActive(true);
        }
    }
}
