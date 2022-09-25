using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUiController : MonoBehaviour
{
    [SerializeField]
    private Canvas enemyHealthCanvas;
    [SerializeField]
    private Image enemyHealthBar;
    [SerializeField]
    private Enemys_Life_Bar_Control[] enemiesList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Enemys_Life_Bar_Control.totalLife = 0;
            foreach (var enemy in enemiesList)
            {
                Enemys_Life_Bar_Control.totalLife += enemy.Max_Life;
            }
            Debug.Log("Total Life: " + Enemys_Life_Bar_Control.totalLife);
            Debug.Log("Total Current life: " + Enemys_Life_Bar_Control.totalLife);
            Enemys_Life_Bar_Control.totalCurrentLife = Enemys_Life_Bar_Control.totalLife;
            enemyHealthBar.fillAmount = 1;
            enemyHealthCanvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
