using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    [SerializeField] private AIWaypointNetwork _waypoints;
    [SerializeField] private Transform _targetTrigger;

    private Animator _animator;
    private NavMeshAgent _agent;

    private Transform _currentPoint;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentPoint = _waypoints.GetPoint();
        _targetTrigger.localPosition = _currentPoint.localPosition;

    }

    

    private void Update()
    {
        if (Vector3.Distance(_currentPoint.position, transform.position) < 5f)
        {
            _currentPoint = _waypoints.GetPoint();
        }
        _agent.SetDestination(_currentPoint.position);

        
    }






}
