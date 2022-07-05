using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCarRacer : MonoBehaviour
{
    public PlayerController player;
    public ManagerObjects objet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& objet.Ruedas[0] >=4)
        {
            player.onGameCar = true;
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log("Faltan");
        }
    }
}
