using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;
    public float boss = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void playeratack(float damage)
    {
        currentHealth -= damage;

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
        spavner spavner = GetComponent<spavner>();
        if (spavner != null)
        {
            spavner.SpawnObjectOnDeath(boss);
        }

    }
}
