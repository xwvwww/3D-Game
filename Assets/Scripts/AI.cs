using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _target;


    private NavMeshAgent _agent;
    private Transform _currentPoint;



    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();


    }

    private void Start()
    {
        int index = Random.Range(0, _points.Length);
        _currentPoint = _points[index];
    }

    void Update()
    {
        _agent.SetDestination(_currentPoint.position);


    }

}
