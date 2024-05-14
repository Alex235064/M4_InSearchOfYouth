using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void playeratack(float enemyAtack)
    {
        currentHealth -= enemyAtack;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика для смерти игрока
        Debug.Log("enemy died");
        Destroy(gameObject);
    }
}
