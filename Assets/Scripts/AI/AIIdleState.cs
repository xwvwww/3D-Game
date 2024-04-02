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
        _currentIdleTime = Random.Range(_idleTime.x, _idleTime.y);
    }

    public override StateType UpdateState()
    {
        if (aiStateMachine == null)
            return StateType.None;

        print("Update - Idle");
        return StateType.Idle;

    }

    public override void ExitState()
    {
        Debug.Log("Exit - Idle");
    }
}
