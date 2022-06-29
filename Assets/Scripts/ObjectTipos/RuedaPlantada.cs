using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RuedaPlantada : MonoBehaviour
{
    public GameObject estado1, estado2, estado3;
    public int diasEstadoMedio;
    public int diasEstadoComplete;
    public int tipoRuedas;
  


    public  int Minute ; 
   public  int Hour ; 
    public  int Dias; 

    private float minuteToRealTime = 0.5f;
    [SerializeField]private float timer;

    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        //TIMER
        Minute = 0;
        Hour = 0;
        Dias = 0;
        timer = minuteToRealTime;

        estado1 = this.transform.GetChild(0).gameObject;
        estado2 = this.transform.GetChild(1).gameObject;
        estado3 = this.transform.GetChild(2).gameObject;


        on = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Debug.Log(Dias);
            //TIMER
            Debug.Log(timer);
            timer -= Time.deltaTime * 100;
            if (timer <= 0)
            {
                Minute++;
                
                if (Minute >= 60)
                {
                    Hour++;
                    Minute = 0;
                    
                    if (Hour >= 24)
                    {
                        Dias++;
                        Hour = 0;
                        Minute = 0;
                      
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
                on = false;
                this.gameObject.tag = "CosechableRueda1";
                
            }

        }


    }
  
}
