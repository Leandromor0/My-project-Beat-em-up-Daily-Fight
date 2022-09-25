using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Enemys_Life_Bar_Control))]
public class Enemys_Control : MonoBehaviour
{

    //o SerializeField e para a op��o aparecer no menu de modifica��o
    [SerializeField] Transform Protagonist_Lau;
    [SerializeField] GameObject enemyBarrier;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Speed;
    [SerializeField] float attackDelay = 3f;

    //Cria��o de Vari�veis
    //o Vetor 2 � uma vari�vel que consegue ter dois valores

    Vector2 movement;

    [SerializeField] float Vision_reach;
    [SerializeField] float Attack_range;
    [SerializeField] float Attack_Force;

    //variaveis para o ataque e o tempo 
    [SerializeField] float Attack_Speed;

    private Animator bossAnimator;

    bool canAttack = true;

    bool isBoss = false;

    Enemys_Life_Bar_Control lifeBarController;

    private void Start()
    {
        if (gameObject.CompareTag("Boss"))
        {
            isBoss = true;
            bossAnimator = GetComponent<Animator>();
        }
        lifeBarController = GetComponent<Enemys_Life_Bar_Control>();
    }

    private void Update()
    {
        if (lifeBarController.Dead)
        {
            if (isBoss)
            {
                SceneManager.LoadScene(3);
            }
            if(enemyBarrier != null && Enemys_Life_Bar_Control.totalCurrentLife == 0)
            {
                enemyBarrier.SetActive(false);
            }

            Destroy(gameObject);
        }

        if (Protagonist_Lau.GetComponent<Protagonist_Lau_Life_Bar_Control>().Dead)
        {
            //quando morre vai ficar parado, se voltar a ficar vivo ele faz a IA abaixo 
            movement = Vector2.zero;
            return;
        }

        if (isBoss)
        {
            CalculateBossDirection();
        }

        Enemys_IA();

    }

    private void FixedUpdate()
    {
        //usando RB que criamos la em cima podemos ter movimento 
        rb.velocity = movement * Speed;
    }

    void Chase_Protagonist_Lau()
    {
        //criar uma variavel privada so para ser usada aqui ajuda a otimizar o jogo 
        Vector2 Direction = Protagonist_Lau.position - transform.position;

        Direction = Direction.normalized;

        movement = Direction;

    }

    void CalculateBossDirection()
    {
        bossAnimator.SetFloat("Velocity", rb.velocity.sqrMagnitude);
        if (movement.x > 0)
        {
            bossAnimator.SetBool("IsRight", true);
        }
        else if (movement.x < 0)
        {
            bossAnimator.SetBool("IsRight", false);
        }
    }

    void Enemys_IA()
    {

        float _Protagonist_Lau_Distance = Vector2.Distance(transform.position, Protagonist_Lau.position);

        //O IF serve para alterar o fluxo de execu��o, se  verdadeiro faz se for  falso n�o faz

        //se o player estive na vis�o ent�o
        if (_Protagonist_Lau_Distance <= Vision_reach)
        {

            Debug.Log("Enemys podem ver o lau ");
            //ent�o eles podem atacar 
            if (_Protagonist_Lau_Distance <= Attack_range && canAttack)
            {
                Debug.Log("Enemys podem atacar o lau ");
                StartCoroutine(AttackCoroutine());
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

    IEnumerator AttackCoroutine()
    {
        canAttack = false;
        Protagonist_Lau.gameObject.GetComponent<Protagonist_Lau_Life_Bar_Control>().TakeDamage(Attack_Force);
        if (isBoss)
        {
            bossAnimator.SetTrigger("Soco");
        }
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;

    }

}
