using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float damageAmount = 10;
    public string playerTag = "Player";
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("123");
                
            playerhealth playerHealth = collision.gameObject.GetComponent<playerhealth>();
            if (playerHealth != null)
            {
                Debug.Log("take");
                playerHealth.TakeDamage(damageAmount * Time.deltaTime);
            }
        }
    }
}
