using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab; 
    public float delay = 2.0f;
    public float blastRadius = 5.0f; 
    public int damage = 10; 

    
    void Start()
    {
        Invoke("Explode", delay); 
    }

    void Explode()
    {
        
        Instantiate(explosionPrefab, transform.position, transform.rotation);

       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);
        foreach (Collider2D hit in colliders)
        {
            
            if (hit.CompareTag("Player") || hit.CompareTag("Enemy"))
            {
                playerhealth playerHealth = hit.GetComponent<playerhealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage * Time.deltaTime);
                }
                Enemyhealth enemyhealth = hit.GetComponent<Enemyhealth>();
                if (enemyhealth != null)
                {
                    Debug.Log("tdsfsd");
                    enemyhealth.playeratack(damage);
                }
            }
        }

       
        Destroy(gameObject);
    }
}

