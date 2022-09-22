using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Antagonist_Neg_Lau_Control : MonoBehaviour
{

    //o SerializeField e para a opção aparecer no menu de modificação
    [SerializeField] Transform Protagonist_Lau;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Speed;

    //Criação de Variáveis
    //o Vetor 2 é uma variável que consegue ter dois valores
    
    Vector2 movement;


    [SerializeField] float Vision_reach;
    [SerializeField] float Attack_range;
    [SerializeField] float Attack_Force;


    //variaveis para o ataque e o tempo 
    [SerializeField] float Attack_Speed;
    private float Nex_Attack = 0f ;



    private void Update()
    {

        if (Protagonist_Lau.GetComponent<Protagonist_Lau_Life_Bar_Control>().Dead)
        {
            //quando morre vai ficar parado, se voltar a ficar vivo ele faz a IA abaixo 
            movement = Vector2.zero;
            return;
        }

        Antogonist_IA();


    }


    private void FixedUpdate()
    {

        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = movement * Speed;

        
        

    }




    //criar o ataque 

    void Attack_Protagonist_Lau() 
    {

        movement= Vector2.zero;

        if (Time.time >= Nex_Attack)
        {
            // colocar tempo para o proximo ataque 
            Nex_Attack = Time.time + (1f / Attack_Speed);
            Debug.Log("ataque ativado");


            Protagonist_Lau.GetComponent<Protagonist_Lau_Life_Bar_Control> ().TakeDamage(Attack_Force) ;


        }

        else 
        {
        
        }


    }



    //presequir o jogador 

    void Chase_Protagonist_Lau()
    {
        //criar uma variavel privada so para ser usada aqui ajuda a otimizar o jogo 
        Vector2 Direction =  Protagonist_Lau.position - transform.position;

        Direction = Direction.normalized;

        movement = Direction;


    }






    void Antogonist_IA()
    {


        float _Protagonist_Lau_Distance = Vector2.Distance(transform.position, Protagonist_Lau.position);

        //O IF serve para alterar o fluxo de execução, se  verdadeiro faz se for  falso não faz

        //se o player estive na visão então
        if (_Protagonist_Lau_Distance <= Vision_reach)
        {

            Debug.Log("Neg Lau pode ver o lau ");
            //então ele pode atacar 
            if (_Protagonist_Lau_Distance <= Attack_range)
            {
                Debug.Log("Neg Lau pode atacar o lau ");
                Attack_Protagonist_Lau();

            }
            //então ele não pode atacar e vai perseguir 
            else
            {

                Debug.Log("Neg Lau vai Perseguir o lau ");

                Chase_Protagonist_Lau();

            }

        }
        //se o player Não estive na visão então
        else
        {

            Debug.Log("Neg Lau não pode ver o lau ");

            movement = Vector2.zero;


        }


    }


}
