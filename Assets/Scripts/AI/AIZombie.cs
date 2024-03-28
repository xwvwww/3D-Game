using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    [SerializeField] [Range(1f, 180f)]private float _fov;

    private AIWaypointNetwork _wayPoints;
    private NavMeshAgent _agent;
    private Transform _targetPlayer;
    private Transform _currentPoint;

    public Transform TargetPlayer
    {
        get { return _targetPlayer; }
        set { _targetPlayer = value; }
    }

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
            Vector3 direction = TargetPlayer.position - transform.position;

            if (Vector3.Angle(direction, transform.forward) < _fov)
            {
                _agent.SetDestination(_targetPlayer.position);
            }
        }

    }
}
