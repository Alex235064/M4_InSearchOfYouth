using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploye : MonoBehaviour
{
    public float delit = 3;
    public float blastRadius = 5.0f;
    public float damage = 10;

    private void Start()
    {
        Invoke("delite", delit);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);
        foreach (Collider2D hit in colliders)
        {

            if (hit.CompareTag("Player") || hit.CompareTag("Enemy"))
            {
                playerhealth playerHealth = hit.GetComponent<playerhealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage  - 25);
                }
                Enemyhealth enemyhealth = hit.GetComponent<Enemyhealth>();
                if (enemyhealth != null)
                {
                    Debug.Log("tdsfsd");
                    enemyhealth.playeratack(damage);
                }
            }
        }
    }

    public void delite()
    {
        Destroy(gameObject);
    }
}
