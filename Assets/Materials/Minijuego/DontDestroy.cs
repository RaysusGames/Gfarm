using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public EnemigController controller;
    public float timeLogrado;
    // Start is called before the first frame update
    void Start()
    {
        timeLogrado = controller.tiempoTrancurrido;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
