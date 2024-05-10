using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeratack : MonoBehaviour
{
    public float attackRange = 1f;
    public float enemyAtack = 20;
    public LayerMask enemyLayer;
    public Transform attackPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("sdas");
                Enemyhealth enemyhealth = enemy.GetComponent<Enemyhealth>();
                if (enemyhealth != null)
                {
                    Debug.Log("tdsfsd");
                    enemyhealth.playeratack(enemyAtack);
                }
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

