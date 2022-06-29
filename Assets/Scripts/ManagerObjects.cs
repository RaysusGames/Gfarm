using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManagerObjects : MonoBehaviour
{
    public int[] Ruedas;
    public int[] Capos;
    public int[] Motor;
    public GameObject Inventario;
    public TextMeshPro[] ruedasText;
    public GameObject cruceta;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ruedasText[0].SetText(Ruedas[0].ToString("X000"));
            
            Inventario.SetActive(true);
            cruceta.SetActive(false);

        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            Inventario.SetActive(false);
            cruceta.SetActive(true);   

        }
    }
}
