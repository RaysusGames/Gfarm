using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarController : MonoBehaviour
{
    public int gear;
    public float speedMarcha = 1;
    public float speed ;
    public  TextMeshPro  textMarcador,textGear;
    public Transform marcador;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        textMarcador.SetText(speed.ToString("000"));
        textGear.SetText(gear.ToString("0"));

        // Marchas
        if (gear == 1)
        {
            if (speed >=20)
            {
                speed = 20;
            }
            
        }
        else if(gear == 2)
        {
            if (speed >= 40)
            {
                speed = 40;
            }

        }
        else if (gear == 3)
        {
            if (speed >= 80)
            {
                speed = 80;
            }
        }
        else if (gear == 4)
        {
            if (speed >= 120)
            {
                speed = 120;
            }
        }
        else if (gear == 5)
        {
            if (speed >= 150)
            {
                speed = 150;
            }
        }


        if (Input.GetKey(KeyCode.W))
        {
            speed += 12f * Time.deltaTime;



            speedMarcha += 80f *Time.deltaTime;
            
            if (speedMarcha >=180)
            {
                speedMarcha = 180;
            }

        }
        else
        {
            speedMarcha -= 1f ;
            if (speedMarcha <= 0)
            {
                speedMarcha = 0;
            }
            speed -= 12f * Time.deltaTime;
            if (speed<=0)
            {
                speed = 0;
            }

        }
       

        
        
           
            
        

        marcador.eulerAngles = new Vector3 (0, 180, speedMarcha);
    }

    public void AddGear()
    {
        gear ++;
        speedMarcha = 0;
      
        if (gear == 6)
        {
            gear = 6;
        }
    }
    public void RestGear()
    {
        speedMarcha = 0;
        
        gear--;
        if (gear == 1)
        {
            gear = 1;
        }
    }
    public void Exit()
    {
        player.onGameCar = false;
    }
}
