using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    [SerializeField] private Vector2 _idleTime;

    private float _currentIdleTime;


    public override StateType GetStateType()
    {
        return StateType.Idle;
    }

    public override void EnterState()
    {
        if (aiStateMachine == null)
            return;

        Debug.Log("Enter - Idle");
        aiStateMachine.IsRunning = false;
        aiStateMachine.IsWalking = false;
        _currentIdleTime = Random.Range(_idleTime.x, _idleTime.y);
    }

    public override StateType UpdateState()
    {
        if (aiStateMachine == null)
            return StateType.None;


        if (_currentIdleTime > 0f)
        {
            _currentIdleTime -= Time.deltaTime;
            return StateType.Idle;
        }
            
        return StateType.Patrol;

    }

    public override void ExitState()
    {
        Debug.Log("Exit - Idle");
    }
}
