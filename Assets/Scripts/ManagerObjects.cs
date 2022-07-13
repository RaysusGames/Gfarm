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
    public int[] motorSiembra;

    public GameObject Inventario;
    public TextMeshPro[] Text;
    public TextMeshPro[] TextSiembra;
    public GameObject cruceta;

    private void Start()
    {
        Motor[0] = PlayerPrefs.GetInt("Engines");
        Ruedas[0] = PlayerPrefs.GetInt("Wheels");
        Carroseria[0] = PlayerPrefs.GetInt("Chassis");

        motorSiembra[0] = PlayerPrefs.GetInt("Engines_Seeds");
        ruedasSiembra[0] = PlayerPrefs.GetInt("Wheels_Seeds");
        chasisSiembra[0] = PlayerPrefs.GetInt("Chassis_Seeds");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TextSiembra[0].SetText(ruedasSiembra[0].ToString("X000"));
            TextSiembra[1].SetText(chasisSiembra[0].ToString("X000"));
            TextSiembra[2].SetText(motorSiembra[0].ToString("X000"));

            Text[0].SetText(Ruedas[0].ToString("X000"));
            Text[1].SetText(Carroseria[0].ToString("X000"));
            Text[2].SetText(Motor[0].ToString("X000"));
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
