using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private StateType _currentStateType;

    protected Dictionary<StateType, State> _states;
    protected State _currentState;

    protected virtual void Awake()
    {
        _states = new Dictionary<StateType, State>();
    }

    protected virtual void Update()
    {
        StateType newStateType = _currentState.UpdateState();

        if (newStateType != _currentStateType)
        {
            State newState = null;

            if (_states.ContainsKey(newStateType))
            {
                newState = _states[newStateType];
            }

        }
    }



}

public enum StateType
{
    Idle,
    Patrol,
    Pursuit,
    Attack,
    Dead
}
