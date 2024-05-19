using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeratack : MonoBehaviour
{
    public float attackRange = 1f;
    public float enemyAtack = 20;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public Animator animator;

    private Vector2 direction;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(attackPoint != null)
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
                    animator.SetFloat("atack", 1);
                    animator.SetFloat("atack", 0);
                }
               
            }
        }
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

