using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compras : MonoBehaviour
{
    public Diner diner;

    [Header("TipoDeObjeto")]
    public bool ruedas;
    public bool motor;
    public bool capo;
    public ManagerObjects inventario;
    public Animator animsObject;
    public GameObject Comprar;
    public bool entroRueda;
    public bool entroChasis;
    public bool entroMotor;
    private void Update()
    {
        if (entroRueda && Input.GetKey(KeyCode.Alpha1))
        {
            animsObject.SetBool("Ruedas", true);
            diner.RestDinner(900);
            inventario.ruedasSiembra[0] = 4;
            PlayerPrefs.SetInt("Wheels_Seeds", inventario.ruedasSiembra[0]);
            Comprar.SetActive(false);
            entroRueda = false;
        }
        if (entroChasis && Input.GetKey(KeyCode.Alpha1))
        {
            animsObject.SetBool("Chasis", true);
            diner.RestDinner(1000);
            inventario.chasisSiembra[0] = 1;
            PlayerPrefs.SetInt("Chassis_Seeds", inventario.chasisSiembra[0]);
            entroChasis = false;
        }

        if (entroMotor && Input.GetKey(KeyCode.Alpha1))
        {

            animsObject.SetBool("Motor", true);
            diner.RestDinner(1000);
            inventario.motorSiembra[0] = 1;
            PlayerPrefs.SetInt("Engines_Seeds", inventario.motorSiembra[0]);
            entroMotor = false; 
        }
     

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Comprar.SetActive(true);
            if (ruedas && diner.diner >= 900 )
            {
                Debug.Log("ssss");

                entroRueda = true;
               


            }
            if (capo && diner.diner >= 1000 )
            {
                entroChasis = true; 
               


            }
            if (motor && diner.diner >= 1100)
            {
                entroMotor = true;  
            }
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        animsObject.SetBool("Chasis", false);
        animsObject.SetBool("Ruedas", false);
        animsObject.SetBool("Motor", false);
        entroRueda = false;
        entroMotor = false;
        entroChasis = false;

        Comprar.SetActive(false);
    }

}
