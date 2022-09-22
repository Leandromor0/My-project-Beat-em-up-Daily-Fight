using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist_Lau_Control : MonoBehaviour
{
    //o SerializeField e para a opção aparecer no menu de modificação
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D rb;
    //Criação de Variáveis
    private float x, y;


    public Animator Lau_Anim;

    //o Update Verificação se qualquer tecla foi pressionada
    private void Update()
    {
        
        //atribuir valores a X e Y
        x = Input.GetAxisRaw ("Horizontal");
        y = Input.GetAxisRaw ("Vertical");

    }
    // comando para acinar a animacao 
    private void LateUpdate()
    {
        //quando acionado o bool vai para verdadeiro e aciona a animacao 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Lau_Anim.SetBool("Corre para frente", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Lau_Anim.SetBool("Corre para tras", true);
        }

        //quando para de apreta o botao o bool fica fauso e a animacao para
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Lau_Anim.SetBool("Corre para frente", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Lau_Anim.SetBool("Corre para tras", false);
        }




    }



    //o FixedUpdate serve para movimentar ter fisica 
    private void FixedUpdate()
    {

        //criar um vetor de movimento 
        Vector2 _Direction = new Vector2 (x, y);
        //o Vetor 2 é uma variável que consegue ter dois valores
        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = _Direction * Speed;

    }







    //começar com os códigos de andar












}
