using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_Life_Bar_Control : MonoBehaviour
{
    //colocar a vida maxima e diminuir vida 
    [SerializeField] float Max_Life;
    private float Current_Life;


    

    //colocar o morte como falso pois o presonagem vive
    public bool Dead = false;


    //quando inicia o jogo ele atualizara a barra de vida 
    private void Awake()

    {
        Current_Life = Max_Life;
       
    }








    public void TakeDamage(float _damage)
    {


        if (Dead) return;

        Current_Life = Mathf.Max(Current_Life - _damage, 0f);

       

        if (Current_Life == 0f)
        {
            Death();

        }

        Debug.Log(Current_Life);


    }





    void Death()
    {
        Debug.Log("Enemy  Morreu");


        Dead = true;


    }














}
