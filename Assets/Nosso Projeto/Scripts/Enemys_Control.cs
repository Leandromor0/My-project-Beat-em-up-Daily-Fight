using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_Control : MonoBehaviour
{


    //o SerializeField e para a op��o aparecer no menu de modifica��o
    [SerializeField] Transform Protagonist_Lau;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Speed;

    //Cria��o de Vari�veis
    //o Vetor 2 � uma vari�vel que consegue ter dois valores

    Vector2 movement;


    [SerializeField] float Vision_reach;
    [SerializeField] float Attack_range;


    //variaveis para o ataque e o tempo 
    [SerializeField] float Attack_Speed;
    private float Nex_Attack = 0f;






    private void Update()
    {

        float _Protagonist_Lau_Distance = Vector2.Distance(transform.position, Protagonist_Lau.position);

        //O IF serve para alterar o fluxo de execu��o, se  verdadeiro faz se for  falso n�o faz

        //se o player estive na vis�o ent�o
        if (_Protagonist_Lau_Distance <= Vision_reach)
        {

            Debug.Log("Enemys podem ver o lau ");
            //ent�o eles podem atacar 
            if (_Protagonist_Lau_Distance <= Attack_range)
            {
                Debug.Log("Enemys podem atacar o lau ");
                Attack_Protagonist_Lau();

            }
            //ent�o eles n�o podem atacar e v�o perseguir 
            else
            {

                Debug.Log("Enemys vai Perseguir o lau ");

                Chase_Protagonist_Lau();

            }

        }
        //se o player N�o estive na vis�o ent�o
        else
        {

            Debug.Log("Enemys n�o podem ver o lau ");

            movement = Vector2.zero;


        }


    }








    private void FixedUpdate()
    {

        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = movement * Speed;




    }



    //criar o ataque 

    void Attack_Protagonist_Lau()
    {

        movement = Vector2.zero;

        if (Time.time >= Nex_Attack)
        {
            // colocar tempo para o proximo ataque 
            Nex_Attack = Time.time + (1f / Attack_Speed);
            Debug.Log("ataque ativado");


        }

        else
        {

        }


    }



    //presequir o jogador 

    void Chase_Protagonist_Lau()
    {
        //criar uma variavel privada so para ser usada aqui ajuda a otimizar o jogo 
        Vector2 Direction = Protagonist_Lau.position - transform.position;

        Direction = Direction.normalized;

        movement = Direction;


    }


}