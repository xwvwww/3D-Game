using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    private AIZombie _ai;


    private void Awake()
    {
        _ai = GetComponentInParent<AIZombie>();
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            _ai.TargetPlayer = player.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            _ai.TargetPlayer = null;
        }
    }



}
