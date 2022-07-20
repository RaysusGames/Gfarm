using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RingMenu : MonoBehaviour
{
    public RingAnimation[] ringAnimations;
    public RingPiece ringPiecePrefab;
    public Animator playerAnimator;

    private RingPiece[] ringPieces;
    private float degreesPerPiece;
    private float gapDegrees = 2f;
    public PlayerController playerController;
   
    // Herramientas
    public GameObject H1,H2,H3,H4,H5,H6;
    public Animator ChangeArma;
    public bool cambio;
    private void Start()
    {
        
        degreesPerPiece = 360f / ringAnimations.Length;

        float distanceToIcon = Vector3.Distance(ringPiecePrefab.icon.transform.position, ringPiecePrefab.background.transform.position);

        ringPieces = new RingPiece[ringAnimations.Length];

        for (int i = 0; i < ringAnimations.Length; i++) 
        {
            ringPieces[i] = Instantiate(ringPiecePrefab, transform);

            ringPieces[i].background.fillAmount = (1f / ringAnimations.Length) - (gapDegrees / 360f);
            ringPieces[i].background.transform.localRotation = Quaternion.Euler(0, 0, degreesPerPiece / 2f + gapDegrees / 2f + i * degreesPerPiece);

            ringPieces[i].icon.sprite = ringAnimations[i].icon;

            Vector3 directionVector = Quaternion.AngleAxis(i * degreesPerPiece, Vector3.forward) * Vector3.up;
            Vector3 movementVector = directionVector * distanceToIcon;
            ringPieces[i].icon.transform.localPosition = ringPieces[i].background.transform.localPosition + movementVector;
        }
        
    }

    private void Update()
    {
        int activeElement = GetActiveElement();
        HighlightActiveElement(activeElement);
        RespondToMouseInput(activeElement);
    }

    private int GetActiveElement() 
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
        Vector3 cursorVector = Input.mousePosition - screenCenter;

        float mouseAngle = Vector3.SignedAngle(Vector3.up, cursorVector, Vector3.forward) + degreesPerPiece / 2f;
        float normalizedMouseAngle = NormalizeAngle(mouseAngle);

        return (int)(normalizedMouseAngle / degreesPerPiece);
    }

    private void HighlightActiveElement(int activeElement)
    {
        for (int i = 0; i < ringPieces.Length; i++) 
        { 
            if(i == activeElement)
            {
                ringPieces[i].background.color = new Color(1f, 1f, 1f, 0.75f);
            } 
            else
            {
                ringPieces[i].background.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }

    private void RespondToMouseInput(int activeElement)
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (activeElement ==0)
            {
                ChangeArma.SetInteger("Changeh", 1);
                playerController.semilla = false;
                playerController.bugia = true;
                playerController.cosecha = false;
                playerController.bidon = false;

                //Herramientas
                H1.SetActive(true);
               H2.SetActive(false);
                H3.SetActive(false);
                H4.SetActive(false);
                H5.SetActive(false);
                H6.SetActive(false);


            }

            if (activeElement == 1)
            {
                ChangeArma.SetInteger("Changeh", 6);
                playerController.cosecha = false;
                playerController.bugia = false;
                playerController.semilla = false;
                playerController.bidon = true;


                H1.SetActive(false);
                H2.SetActive(false);
                H3.SetActive(false);
                H4.SetActive(false);
                H5.SetActive(false);
                H6.SetActive(true);
                //Agua
            }
            if (activeElement == 2)
            {
                ChangeArma.SetInteger("Changeh", 2);
                //Cosecha
                playerController.cosecha = true;
                playerController.bugia = false;
                playerController.semilla = false;
                playerController.bidon = false;
                //Herramientas
                H1.SetActive(false);
                H2.SetActive(true);
                H3.SetActive(false);
                H4.SetActive(false);
                H5.SetActive(false);
                H6.SetActive(false);


            }
            if (activeElement == 3)
            {
                //motor
                playerController.tipo = 3;
                ChangeArma.SetInteger("Changeh", 5);
                playerController.bugia = false;
                playerController.cosecha = false;
                playerController.semilla = true;
                playerController.bidon = false;
                
                //Herramientas
                H1.SetActive(false);
                H2.SetActive(false);
                H3.SetActive(false);
                H4.SetActive(false);
                H5.SetActive(true);
                H6.SetActive(false);
            }
            if (activeElement == 4)
            {
                //Chasis
                ChangeArma.SetInteger("Changeh", 4);

                playerController.bugia = false;
                playerController.cosecha = false;
                playerController.semilla = true;
                playerController.bidon = false;
                playerController.tipo = 2;
                //Herramientas
                H1.SetActive(false);
                H2.SetActive(false);
                H3.SetActive(false);
                H4.SetActive(true);
                H5.SetActive(false);
                H6.SetActive(false);
            }
            if (activeElement == 5)
            {
                ChangeArma.SetInteger("Changeh", 3);
                playerController.bugia = false;
                playerController.cosecha = false;
                playerController.semilla = true;
                playerController.bidon = false;
                playerController.tipo = 1;
                //Herramientas
                H1.SetActive(false);
                H2.SetActive(false);
                H3.SetActive(true);
                H4.SetActive(false);
                H5.SetActive(false);
                H6.SetActive(false);
               
            }
            // playerAnimator.SetTrigger(ringAnimations[activeElement].name);
            gameObject.SetActive(false);
        }
      
    }

    // Función para normalizar el ángulo
    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
