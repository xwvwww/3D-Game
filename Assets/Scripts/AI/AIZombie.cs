using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    [SerializeField] private AIWaypointNetwork _waypoints;
    [SerializeField] private Transform _targetTrigger;
    [SerializeField] private Vector2 _idleTime;

    private Animator _animator;
    private NavMeshAgent _agent;

    private Transform _targetPlayer;
    private Transform _currentPoint;
    private float _currentIdleTime;

    public Transform TargetPlayer
    {
        get { return _targetPlayer; }
        set { _targetPlayer = value; }
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentPoint = _waypoints.GetPoint();
        _targetTrigger.position = _currentPoint.position;
        _currentIdleTime = Random.Range(_idleTime.x, _idleTime.y);

    }

    

    private void Update()
    {
        
        if (_targetPlayer == null)
        {
            if (_currentIdleTime > 0f)
            {
                _currentIdleTime -= Time.deltaTime;
                return;
            }

            _agent.SetDestination(_currentPoint.position);
            _animator.SetBool("IsWalking", true);
            _agent.speed = 0.8f;
        }
        else
        {
            _agent.SetDestination(_targetPlayer.position);
            _animator.SetBool("IsRunning", true);
        }

        
    }

    public void ChangePoint()
    {
        _currentPoint = _waypoints.GetPoint();
        _targetTrigger.position = _currentPoint.position;
        _currentIdleTime = Random.Range(_idleTime.x, _idleTime.y);
        _animator.SetBool("IsWalking", false);
        _agent.speed = 0.001f;
    }






}
