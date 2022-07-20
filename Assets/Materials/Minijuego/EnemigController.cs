 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemigController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedEnemig;
     public Rigidbody rbEnemig;
    public float timer;
    public float maxTimer;
    public bool start = false;
    public float tiempoTrancurrido;
    public TextMeshPro tm;
    
    
    void Start()
    {
        maxTimer = Random.Range(3, 10);
        StartCoroutine(On());
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            tiempoTrancurrido += Time.deltaTime *1;
        
            rbEnemig.AddForce(Vector3.right * speedEnemig * Time.deltaTime);
            tm.SetText(tiempoTrancurrido.ToString("00"));   
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                speedEnemig += Random.Range(20, 30);
                maxTimer = Random.Range(2, 6);
                timer = 0;
                
            }
        }
       
      


    }

    IEnumerator On()
    {
        yield return new WaitForSeconds(6f);
        start = true;
    }
}
