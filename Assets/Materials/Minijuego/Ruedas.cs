00using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruedas : MonoBehaviour
{
    
    public float speed;
    public bool player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(speed * Time.deltaTime, 0, 0);
                speed++;
                if (speed >=200)
                {
                    speed = 200;
                }
            }
        }
        else
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
            speed++;
            if (speed >= 200)
            {
                speed = 200;
            }

        }
        
       
    }
}
