using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void playeratack(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика для смерти игрока
        Debug.Log("enemy died");
    }
}
