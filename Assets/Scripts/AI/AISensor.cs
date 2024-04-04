using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    private AIZombie _zombie;

    private void Awake()
    {
        _zombie = GetComponentInParent<AIZombie>();

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null )
        {
            Vector3 direction = player.transform.position - _zombie.transform.position;
            if(Vector3.Angle(_zombie.transform.position, direction) < 120)
            {
                _zombie.TargetPlayer = player.transform;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Vector3 direction = player.transform.position - _zombie.transform.position;
            if (Vector3.Angle(_zombie.transform.position, direction) < 120)
            {
                _zombie.TargetPlayer = player.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            _zombie.TargetPlayer = null;
        }
    }
}
