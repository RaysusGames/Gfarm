using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject animationRing;
    public PlayerController playerController;
 





    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            animationRing.SetActive(true);
            playerController.speedH = 0;
            playerController.speedV = 0;
            Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
           
        }

        if(Input.GetKeyUp(KeyCode.Tab))
        {
            animationRing.SetActive(false);
            playerController.speedH = 3;
            playerController.speedV = 3;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
           
        }

    }
}
