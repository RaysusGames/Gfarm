using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject cam1, cam2,cam3;
    public void Star()
    {
        SceneManager.LoadScene("TextoIntro");
    }
    public void Carrera()
    {
        SceneManager.LoadScene("CarreraInicial");
    }
    public void Game()
    {
        SceneManager.LoadScene("Granja");
    }

    public void Continue()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OnCamera()
    {
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam1.SetActive(true);
        
    }
}
