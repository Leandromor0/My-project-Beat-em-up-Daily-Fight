using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Acao para chamar o sistema de menus
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{

    //acao chamando o proximo cenario 
    public void Play_Game()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }


    public void Quit_Game()
    {

        Debug.Log("Quit");
        Application.Quit();

        


    }









}
