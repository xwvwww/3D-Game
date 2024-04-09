using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            Debug.Log("PlayerTrigger");
            Health playerHealth = GetComponentInParent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }
        }
    }
}
