using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Mouse")] 
    public CinemachineVirtualCameraBase cam;
    public float speedH;
    public float speedV;
   public float ejeV, ejeH;
    [SerializeField] float range;
    public float rotmax;
    public float rotMin;
    bool mouseVisible = false;
    //inventario
    [Header("Inventario")]

    public ManagerObjects managerItems;

    //Para Controlar La al Player
    [Header("Player Controller")]

    CharacterController cc;
    

    public float speedMov;
    public float jump;
    public float gravity;
    Vector3 mov = Vector3.zero;
    [Header("Herramienta 1")]

    //herramienta 1
    public bool bugia = false;
   
    public Material bugiaMaterial;
    [Header("Herramienta 2")]

    //herramienta 2
    public bool semilla = false;
    public GameObject semillaPref;
    Transform instanPosition;
    public Vector3 offset;
    public Material plantado;
    [Header("Herramienta 3")]

    //Herramienta 3
    public bool cosecha = false;
    public Material tierra;

    [Header("GameCar")]

    // Si entra en game
    public bool onGameCar;
    public GameObject camCar,camNormal;

    private void Awake()
    {
        Cursor.visible = false;
    }
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (onGameCar)
        {
            speedMov = 0;
            speedH = 0;
            speedV = 0;
            Cursor.visible = true;
            camCar.SetActive(true);
            camNormal.SetActive(false);


        }
        else if (!onGameCar)
        {
            speedMov = 6;
            speedH = 3;
            speedV = 3;
            camCar.SetActive(false);
            camNormal.SetActive(true);
        }

        Raycast();

     /*  if (!mouseVisible)
        {
            Cursor.visible = false;
        }*/
       
        
        //Para Controlar La Camara
        ejeH = speedH * Input.GetAxis("Mouse X");
        ejeV += speedV * Input.GetAxis("Mouse Y");

        cam.transform.localEulerAngles = new Vector3(-ejeV, 0, 0);
        transform.Rotate(0, ejeH, 0);
        ejeV = Mathf.Clamp(ejeV, rotMin, rotmax);



        //Para Controlar el Movimiento
        if (cc.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            mov = transform.TransformDirection(mov) * speedMov;

            if (Input.GetKey(KeyCode.Space))
            {
                mov.y = jump;
            }
        }

        mov.y -= gravity * Time.deltaTime;
        cc.Move(mov * Time.deltaTime);


    }

    void Raycast()
    {

       RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Bugia
                if (bugia)
                {
                    if (hit.collider.CompareTag("Tierra"))
                    {
                        GameObject change = hit.collider.gameObject;
                        change.tag = "Plantable";
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = bugiaMaterial;
                      

                    }
                }
                //Plantar
                if (semilla)
                {
                    if (hit.collider.CompareTag("Plantable"))
                    {
                      
                        instanPosition = hit.collider.gameObject.transform;
                   
                        Instantiate(semillaPref, instanPosition.position + offset, Quaternion.identity);
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = plantado;
                       
                    }
                }
                //Cosechar
                if (cosecha)
                {
                    if (hit.collider.CompareTag("CosechableRueda1"))
                    {
                        managerItems.Ruedas[0]++;
                        Destroy(hit.collider.gameObject);
                    }
                    if (hit.collider.CompareTag("Plantable"))
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = tierra;
                        hit.collider.tag = "Tierra";
                    }
                }
               

            }




        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * range);
    }



}
