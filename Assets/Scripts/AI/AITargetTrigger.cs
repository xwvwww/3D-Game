using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AIZombie zombie = other.GetComponent<AIZombie>();

        if (zombie != null)
        {
            zombie.ChangePoint();
        }
    }
}
