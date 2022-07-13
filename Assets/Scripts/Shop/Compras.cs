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
       
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ruedas && diner.diner >=900)
            {
                animsObject.SetBool("Ruedas", true);
                diner.RestDinner(900);
                inventario.ruedasSiembra[0] = 4;
                PlayerPrefs.SetInt("Wheels_Seeds", inventario.ruedasSiembra[0]);
            }
            if (capo && diner.diner >= 1000)
            {
                animsObject.SetBool("Chasis", true);
                diner.RestDinner(1000);
                inventario.chasisSiembra[0] = 1;
                PlayerPrefs.SetInt("Chassis_Seeds", inventario.chasisSiembra[0]);
            }
            if (motor && diner.diner >= 1100)
            {
                animsObject.SetBool("Motor", true);
                diner.RestDinner(1000);
                inventario.motorSiembra[0] = 1;
                PlayerPrefs.SetInt("Engines_Seeds", inventario.motorSiembra[0]);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animsObject.SetBool("Chasis", false);
        animsObject.SetBool("Ruedas", false);
        animsObject.SetBool("Motor", false);
    }

}
