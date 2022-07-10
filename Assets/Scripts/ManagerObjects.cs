using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManagerObjects : MonoBehaviour
{
    public int[] Ruedas;
    public int[] Carroseria;
    public int[] Motor;
    public int[] ruedasSiembra;
    public int[] chasisSiembra;
    public GameObject Inventario;
    public TextMeshPro[] Text;
    public TextMeshPro[] TextSiembra;
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
            TextSiembra[0].SetText(ruedasSiembra[0].ToString("X000"));
            TextSiembra[1].SetText(chasisSiembra[0].ToString("X000"));

            Text[0].SetText(Ruedas[0].ToString("X000"));
            Text[1].SetText(Carroseria[0].ToString("X000"));

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
