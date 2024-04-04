using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
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
        SetTargetPoint();

    }

    

    private void Update()
    {
        
        if (_targetPlayer == null)
        {
            if (_currentIdleTime > 0f)
            {
                _currentIdleTime -= Time.deltaTime;
                _agent.speed = 0.001f;
                return;
            }

            _agent.SetDestination(_currentPoint.position);
            _agent.speed = _walkSpeed;
        }
        else
        {
            _agent.SetDestination(_targetPlayer.position);
            _agent.speed = _runSpeed;
        }

        Animate();
    }

    public void ChangePoint()
    {
        SetTargetPoint();
        _agent.speed = 0.0001f;
    }

    private void Animate()
    {
        if (_animator == null)
            return;

        if (TargetPlayer != null && _agent.velocity.magnitude > 1f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else if (TargetPlayer == null && _agent.velocity.magnitude > 0.3f)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsWalking", false);
        }

        
    }

    private void SetTargetPoint()
    {
        _currentPoint = _waypoints.GetPoint();
        _targetTrigger.position = _currentPoint.position;
        _currentIdleTime = Random.Range(_idleTime.x, _idleTime.y);
    }






}
