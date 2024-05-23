﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public RectTransform valueRectTransform;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        valueRectTransform.anchorMax = new Vector2(currentHealth / maxHealth, 1);
    }

    void Die()
    {
        // Логика для смерти игрока
        Debug.Log("Player died");
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healAmount);
    }
}
