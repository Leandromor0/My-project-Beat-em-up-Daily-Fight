using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona a biblioteca para usar a interfase no jogo (UI)
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Protagonist_Lau_Life_Bar_Control : MonoBehaviour
{
    //colocar a vida maxima e diminuir vida 
    [SerializeField] float Max_Life;
    private float Current_Life;

    //colocar a barra de vida na interfase do jogo 

    [SerializeField] Image Life_Bar;

    //colocar o morte como falso pois o presonagem vive
    public bool Dead = false;


    //quando inicia o jogo ele atualizara a barra de vida 
    private void Awake()

    {
        Dead = false;
        Current_Life = Max_Life;
        UpdateLife_Bar();
    }

    public void TakeDamage(float _damage)
    {


        if (Dead) return;

        Current_Life = Mathf.Max(Current_Life - _damage, 0f);

        UpdateLife_Bar();

        if (Current_Life == 0f)
        {
            Death();

        }

        Debug.Log(Current_Life);

    }

    void UpdateLife_Bar()
    {
        Life_Bar.fillAmount = Current_Life / Max_Life;
    }

    void Death()
    {
        Debug.Log("Lau Morreu");
        Dead = true;
        SceneManager.LoadScene(4);

    }

}
