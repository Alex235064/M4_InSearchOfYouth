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
                // Здесь должен быть ваш код для нанесения урона
            }
        }

       
        Destroy(gameObject);
    }
}

public class PlayerController : MonoBehaviour
{
    public GameObject bombPrefab; 

 
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropBomb();
        }
    }

    void DropBomb()
    {
        
        Instantiate(bombPrefab, transform.position, transform.rotation);
    }
}
