using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MetaCarrera1 : MonoBehaviour
{
    public GameObject cam1,cam2;
    public EnemigController enemigController;
    public TextMeshPro tm;
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
            StartCoroutine(Time());
            enemigController.start = false;
        }
    }

    IEnumerator Time()
    {


        yield return new WaitForSeconds(0.3f);
        cam1.SetActive(false);
        cam2.SetActive(true);
        tm.SetText(enemigController.tiempoTrancurrido.ToString("0"));
    }
}
