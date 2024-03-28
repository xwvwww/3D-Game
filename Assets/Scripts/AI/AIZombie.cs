using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    private AIWaypointNetwork _wayPoints;
    private NavMeshAgent _agent;
    private Transform _targetPlayer;
    private Transform _currentPoint;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _wayPoints = FindObjectOfType<AIWaypointNetwork>();
    }

    private void Start()
    {
        _currentPoint = _wayPoints.GetPoint();
    }

    private void Update()
    {
        if (_targetPlayer == null)
        {
            if (Vector3.Distance(transform.position, _currentPoint.position) < 5f)
            {
                _currentPoint = _wayPoints.GetPoint();
            }

            _agent.SetDestination(_currentPoint.position);

        }
        else
        {
            _agent.SetDestination(_targetPlayer.position);
        }

    }
}
