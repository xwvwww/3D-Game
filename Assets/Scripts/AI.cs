using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private NavMeshAgent _agent;



    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _agent.SetDestination(_target.position);
    }

}
