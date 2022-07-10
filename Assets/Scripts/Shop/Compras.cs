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
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ruedas && diner.diner >=900)
            {
                animsObject.SetBool("Ruedas", true);
                diner.RestDinner(900);
                inventario.ruedasSiembra[0] = 4;
            }
            if (capo && diner.diner >= 1000)
            {
                animsObject.SetBool("Chasis", true);
                diner.RestDinner(1000);
                inventario.chasisSiembra[0] = 1;
            }
        }
       
        
    }
    private void OnTriggerExit(Collider other)
    {
        animsObject.SetBool("Chasis", false);
        animsObject.SetBool("Ruedas", false);
    }

}
