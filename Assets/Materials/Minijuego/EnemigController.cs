using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedEnemig;
     public Rigidbody rbEnemig;
    public float timer;
    public float maxTimer;
    
    void Start()
    {
        maxTimer = Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rbEnemig.AddForce(Vector3.right * speedEnemig * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer>= maxTimer)
        {
            speedEnemig += Random.Range(20, 30);
            maxTimer = Random.Range(2, 6);
            timer = 0;

        }


    }
}
