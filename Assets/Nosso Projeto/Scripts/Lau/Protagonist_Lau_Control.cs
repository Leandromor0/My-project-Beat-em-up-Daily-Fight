using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Protagonist_Lau_Life_Bar_Control))]
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

        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            Lau_Anim.SetBool("IsRight", true);
        }
        else if (x < 0)
        {
            Lau_Anim.SetBool("IsRight", false);
        }

    }

    //o FixedUpdate serve para movimentar ter fisica 
    private void FixedUpdate()
    {

        //criar um vetor de movimento 
        Vector2 _Direction = new Vector2(x, y);
        //o Vetor 2 é uma variável que consegue ter dois valores
        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = _Direction * Speed;
        Lau_Anim.SetFloat("Velocity", rb.velocity.sqrMagnitude);
    }
}

