using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachine _stateMachine;

    public void SetStateMachine(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void EntryState();
    public abstract StateType UpdateState();
    public abstract void ExitState();
    public abstract StateType GetStateType();
}
