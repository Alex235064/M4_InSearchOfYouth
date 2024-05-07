using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public string playerTag = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerhealth playerHealth = collision.gameObject.GetComponent<playerhealth>();
            if (playerHealth != null)
            {
                Debug.Log("take");
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
