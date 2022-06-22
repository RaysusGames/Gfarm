using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEstado : MonoBehaviour
{
    public int dias;
    public GameObject estado1,estado2, estado3;
    // Start is called before the first frame update
    void Start()
    {
        estado1 = this.transform.GetChild(0).gameObject;
        estado2 = this.transform.GetChild(1).gameObject; 
        estado3 = this.transform.GetChild(2).gameObject;


        dias = TimeManager.Dias;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            dias += 1;
        }
       
        if (dias == 2)
        {
            estado1.SetActive(false);
            estado2.SetActive(true);
        }
        if (dias == 3)
        {
            estado1.SetActive(false);
            estado2.SetActive(false);
            estado3.SetActive(true);
        }
    }
}
