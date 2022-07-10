using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diner : MonoBehaviour
{
    public int diner;
    
    public TextMeshPro dinerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dinerText.SetText(diner.ToString(""));
    }
    public void AddDiner(int add)
    {
        diner += add;
    }
    public void RestDinner(int rest)
    {
        diner -= rest;
        
    }
}
