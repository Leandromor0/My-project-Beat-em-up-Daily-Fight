using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist_Lau_Control : MonoBehaviour
{
    //o SerializeField e para a op��o aparecer no menu de modifica��o
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D rb;
    //Cria��o de Vari�veis
    private float x, y;

    //o Update Verifica��o se qualquer tecla foi pressionada
    private void Update()
    {
        //atribuir valores a X e Y
        x = Input.GetAxisRaw ("Horizontal");
        y = Input.GetAxisRaw ("Vertical");


    }

    //o FixedUpdate serve para movimentar ter fisica 
    private void FixedUpdate()
    {

        //criar um vetor de movimento 
        Vector2 _Direction = new Vector2 (x, y);
        //o Vetor 2 � uma vari�vel que consegue ter dois valores
        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = _Direction * Speed;

    }







    //come�ar com os c�digos de andar












}
