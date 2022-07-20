using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public Animator ChangeArma;


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
    public Animator animH1;
   
    public Material bugiaMaterial;
    [Header("Herramienta 2")]

    //herramienta 2
    public bool semilla = false;
    public GameObject[] semillaPref;
    Transform instanPosition;
    public Vector3 offset;
    public Material plantado;
    public int tipo;
    public GameObject text;
    public GameObject textPref;
    public Animator animH3;
    public Animator animH4;
    public Animator animH5;


    [Header("Herramienta 3")]
    //Herramienta 3

    public bool cosecha = false;
    public Material tierra;
    public Animator animH2;
    [Header("GameCar")]

    // Si entra en game
    public bool onGameCar;
    public GameObject camCar,camNormal;

    [Header("Tutorial")]
    public GameObject dirigete;
    public GameObject pressTab;

    public Transform insTutorial;

    [Header("Herramienta 4")]
    public bool bidon = false;
    public Animator animh6;
    private void Awake()
    {
        Cursor.visible = false;
    }
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        Instantiate(dirigete, insTutorial);

    }


    void Update()
    {
        //tuto
        

        animEject();
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
    void animEject()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

           
            if (bugia)
            {
               
                animH1.SetBool("Ara", true);
            }

        }
        else
        {

            animH1.SetBool("Ara", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cosecha)
            {

                animH2.SetBool("Cosecha", true);
            }

        }
        else
        {
            animH2.SetBool("Cosecha", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (semilla && tipo == 1)
            {

                animH3.SetBool("PlantaRueda", true);
            }
          

        }
        else
        {
            animH3.SetBool("PlantaRueda", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (semilla && tipo == 2)
            {

                animH4.SetBool("Chasis", true);
            }


        }
        else
        {
            animH4.SetBool("Chasis", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (semilla && tipo == 3)
            {

                animH5.SetBool("Motor", true);
            }


        }
        else
        {
            animH5.SetBool("Motor", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (bidon )
            {

                animh6.SetBool("Galon", true);
            }


        }
        else
        {
            animh6.SetBool("Galon", false);
        }
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
                        if (tipo == 1 && managerItems.ruedasSiembra[0]>=1)
                        {
                            //rueda
                            instanPosition = hit.collider.gameObject.transform;

                            Instantiate(semillaPref[0], instanPosition.position + offset, Quaternion.identity);
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = plantado;
                            managerItems.ruedasSiembra[0] -= 1;
                            PlayerPrefs.SetInt("Wheels_Seeds", managerItems.ruedasSiembra[0]);
                        }
                        else if (tipo==1 && managerItems.ruedasSiembra[0] <= 0)
                        {
                            Instantiate(textPref, text.transform);
                        }
                         
                        
                        if (tipo == 2&& managerItems.chasisSiembra[0] >= 1)
                        {
                            //chasis
                            instanPosition = hit.collider.gameObject.transform;

                            Instantiate(semillaPref[1], instanPosition.position + offset, Quaternion.identity);
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = plantado;
                            managerItems.chasisSiembra[0] -= 1;
                            PlayerPrefs.SetInt("Chassis_Seeds", managerItems.chasisSiembra[0]);
                        }
                        else if (tipo == 2)
                        {
                            Instantiate(textPref, text.transform);
                        }
                        if (tipo == 3 && managerItems.motorSiembra[0]>=1)
                        {
                            //motor
                            instanPosition = hit.collider.gameObject.transform;

                            Instantiate(semillaPref[2], instanPosition.position + offset, Quaternion.identity);
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = plantado;
                            managerItems.motorSiembra[0] -= 1;
                            PlayerPrefs.SetInt("Engines_Seeds", managerItems.motorSiembra[0]);
                        }
                        else if (tipo == 2)
                        {
                            Instantiate(textPref, text.transform);
                        }


                    }
                }
                //Cosechar
                if (cosecha)
                {
                    ChangeArma.SetBool("Change", true);

                    if (hit.collider.CompareTag("CosechableRueda1"))
                    {
                        managerItems.Ruedas[0]++;
                        PlayerPrefs.SetInt("Wheels", managerItems.Ruedas[0]);
                        Destroy(hit.collider.gameObject,0.6f);
                    }
                    if (hit.collider.CompareTag("CarroceriaLista1"))
                    {
                        managerItems.Carroseria[0]++;
                        PlayerPrefs.SetInt("Chassis", managerItems.Carroseria[0]);
                        Destroy(hit.collider.gameObject, 0.6f);
                    }
                    if (hit.collider.CompareTag("MotorLista1"))
                    {
                        managerItems.Motor[0]++;
                        PlayerPrefs.SetInt("Engines", managerItems.Motor[0]);
                        Destroy(hit.collider.gameObject, 0.6f);
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
