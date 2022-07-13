using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diner : MonoBehaviour
{
    public int diner;
    public TextMeshPro dinerText;

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsNew") == 0)
        {
            diner = 3000;
            PlayerPrefs.SetInt("Money", diner);
            PlayerPrefs.SetInt("IsNew", 1);
        }
        else
        {
            diner = PlayerPrefs.GetInt("Money");
        }
    }

    void Update()
    {
        dinerText.SetText(diner.ToString(""));
    }

    public void AddDiner(int add)
    {
        diner += add;
        PlayerPrefs.SetInt("Money", diner);
    }

    public void RestDinner(int rest)
    {
        diner -= rest;
        PlayerPrefs.SetInt("Money", diner);
    }
}
