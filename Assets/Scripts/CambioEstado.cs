using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CambioEstado : MonoBehaviour
{
    public int dias;
    public GameObject estado1,estado2, estado3;
    public int diasEstadoMedio;
    public int diasEstadoComplete;
    public int tipoRuedas;
    // TIMER
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDiasChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Dias { get; private set; }

    private float minuteToRealTime = 0.5f;
    private float timer;
    //Recolectar

    public bool cosechable = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //TIMER
        Minute = 0;
        Hour = 22;
        Dias = 0;
        timer = minuteToRealTime;

        estado1 = this.transform.GetChild(0).gameObject;
        estado2 = this.transform.GetChild(1).gameObject; 
        estado3 = this.transform.GetChild(2).gameObject;


        dias = TimeManager.Dias;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Dias);
        //TIMER
        timer -= Time.deltaTime * 100;
        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
                if (Hour >= 24)
                {
                    Dias++;
                    Hour = 0;
                    Minute = 0;
                    OnDiasChanged?.Invoke();
                }
            }
            timer = minuteToRealTime;
        }

        if (Dias == diasEstadoMedio)
        {
            estado1.SetActive(false);
            estado2.SetActive(true);
        }
        if (Dias == diasEstadoComplete)
        {
            estado1.SetActive(false);
            estado2.SetActive(false);
            estado3.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (cosechable)
        {
            GameObject add;
           
           add = other.gameObject.transform.GetChild(1).gameObject;
            add.GetComponent<ManagerObjects>().Ruedas[tipoRuedas] ++;
            
            
        }
    }
}
