using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public CinemachineVirtualCameraBase cam;
    public float speedH;
    public float speedV;
   public float ejeV, ejeH;
    [SerializeField] float range;
    public float rotmax;
    public float rotMin;
    bool mouseVisible = false;
    
    //Para Controlar La al Player
    CharacterController cc;
    

    public float speedMov;
    public float jump;
    public float gravity;
    Vector3 mov = Vector3.zero;
    //herramienta 1
    public bool bugia = false;
   
    public Material bugiaMaterial;

    //herramienta 2
    public bool semilla = false;
    public GameObject semillaPref;
    Transform instanPosition;
    public Vector3 offset;
    public Material plantado;


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
               


            }




        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * range);
    }



}
