using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : State
{
    protected AIStateMachine aiStateMachine;

    public override void SetStateMachine(StateMachine stateMachine)
    {
        if (stateMachine.GetType() == typeof(AIStateMachine))
            aiStateMachine = (AIStateMachine)stateMachine;
    }


}
