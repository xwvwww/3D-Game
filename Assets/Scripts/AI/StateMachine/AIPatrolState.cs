using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIState
{
    
    public override StateType GetStateType()
    {
        return StateType.Patrol;
    }

    public override void EnterState()
    {
        if (aiStateMachine == null)
            return;

        Debug.Log("Enter - Patrol");
        aiStateMachine.IsWalking = true;
    }

    public override StateType UpdateState()
    {
        if (aiStateMachine == null)
            return StateType.None;

        return StateType.Patrol;
    }

    public override void ExitState()
    {
        Debug.Log("Exit - Patrol");
        aiStateMachine.IsWalking = false;
    }
}
