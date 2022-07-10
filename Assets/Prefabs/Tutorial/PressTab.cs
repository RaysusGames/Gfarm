using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTab : MonoBehaviour
{
    public GameObject presstab;
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
        if (other.CompareTag("Player"))
        {
            presstab.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        Destroy(gameObject);
    }
}
