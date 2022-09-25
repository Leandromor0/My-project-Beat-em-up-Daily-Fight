using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemys_Life_Bar_Control : MonoBehaviour
{
    public static float totalLife;
    public static float totalCurrentLife;
    //colocar a vida maxima e diminuir vida 
    public float Max_Life = 10;
    private float Current_Life;
    private Image Life_Bar;

    //colocar o morte como falso pois o presonagem vive
    public bool Dead = false;

    //quando inicia o jogo ele atualizara a barra de vida 
    private void Awake()
    {
        Current_Life = Max_Life;
    }

    public void TakeDamage(float damage)
    {

        if (Dead) return;

        totalCurrentLife = Mathf.Max(totalCurrentLife - Mathf.Min(Current_Life, damage), 0f);
        Current_Life = Mathf.Max(Current_Life - damage, 0f);

        UpdateLife_Bar();

        if (Current_Life == 0f)
        {
            if(totalCurrentLife == 0f)
            {
                GameObject.Find("LifeBarCanvas").SetActive(false);
            }
            Death();
        }
        Debug.Log("Total Current Life: " + totalCurrentLife);
        Debug.Log("Current Life: " + Current_Life);
    }

    void UpdateLife_Bar()
    {
        if(Life_Bar == null)
        {
            Life_Bar = GameObject.Find("EnemyLifeBar").GetComponent<Image>();
        }
        Life_Bar.fillAmount = totalCurrentLife / totalLife;
    }

    void Death()
    {
        Debug.Log("Enemy  Morreu");

        Dead = true;
    }

}
