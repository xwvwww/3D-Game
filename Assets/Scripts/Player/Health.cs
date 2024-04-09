using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int _maxHealth;

    private int _currentHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if ( _currentHealth <= 0 )
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PlayerTrigger");

        if (other.CompareTag("Player"))
        {
            Health playerHealth = GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }
        }
    }
}
