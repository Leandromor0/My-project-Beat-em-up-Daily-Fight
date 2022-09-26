using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Protagonist_Lau_Attack : MonoBehaviour
{

    Animator Anim_Ataque;
    public BoxCollider2D attackArea;
    private bool canAttack = true;


    [SerializeField] AudioSource Sons_soco_Lau;

    [SerializeField]
    private float attackDelay = 1f;
    [SerializeField]
    private float attackDamage = 2f;

    Enemys_Life_Bar_Control enemyTarget = null;

    void Start()
    {


        Anim_Ataque = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Anim_Ataque.GetBool("IsRight"))
        {
            attackArea.offset = new Vector2(Math.Abs(attackArea.offset.x), attackArea.offset.y);
        }
        else
        {
            attackArea.offset = new Vector2(Math.Abs(attackArea.offset.x) * -1, attackArea.offset.y);
        }

        if (Input.GetKeyDown(KeyCode.X) && canAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {


        Sons_soco_Lau.Play();
        canAttack = false;
        Anim_Ataque.SetTrigger("Soco");
        if(enemyTarget != null)
        {
            enemyTarget.TakeDamage(attackDamage);
        }
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        Sons_soco_Lau.Stop();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            enemyTarget = collision.gameObject.GetComponent<Enemys_Life_Bar_Control>();
        }
        else
        {
            enemyTarget = null;
        }
    }


}
