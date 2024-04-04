using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] protected StateType _currentStateType;

    protected Dictionary<StateType, State> _states;
    protected State _currentState;

    protected virtual void Awake()
    {
        _states = new Dictionary<StateType, State>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (_currentState == null)
            return;

        StateType newStateType = _currentState.UpdateState();

        if (newStateType != _currentStateType)
        {
            State newState = null;

            if (_states.ContainsKey(newStateType))
            {
                newState = _states[newStateType];
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState();
                _currentStateType = newStateType;
            }

        }
    }



}

public enum StateType
{
    None,
    Idle,
    Patrol,
    Pursuit,
    Attack,
    Dead
}
