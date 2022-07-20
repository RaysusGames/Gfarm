using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Letras : MonoBehaviour
{
    public string frase = "asdadqweda";
    public TextMeshPro texto;
    public float textSped;

    public bool text;
    public float espera;
    public GameObject sound;
    public GameObject starButtom;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
        if (text)
        {
            StartCoroutine(Time());
        }
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(textSped);
        }
    }

    IEnumerator Time()
    {
        
        
        yield return new WaitForSeconds(espera);
        sound.SetActive(false);
        starButtom.SetActive(true);
    }
}
