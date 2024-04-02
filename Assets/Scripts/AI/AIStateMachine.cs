using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : StateMachine
{
    protected Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();

        State[] st = GetComponents<State>();
        
        foreach (State state in st)
        {
            StateType type = state.GetStateType();
            state.SetStateMachine(this);
            _states[type] = state;
        }
    }

    protected override void Start()
    {
        _currentStateType = StateType.Idle;

        if (_states.ContainsKey(_currentStateType))
        {
            _currentState = _states[_currentStateType];
            _currentState.EnterState();
        }
        else
        {
            _currentStateType = StateType.None;
            _currentState = null;
        }
    }

    protected override void Update()
    {
        base.Update();

    }




}
