using shootandRun1.Abstracts.States;
using shootandRun1.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    List<StateTransformer> _stateTransformers = new List<StateTransformer>();
    List<StateTransformer> _anystateTransformer = new List<StateTransformer>();

    IState _currentState;

    public void SetState(IState state)
    {
        if (_currentState == state) return;

        //if (_currentState != null) **** _currentState?'in soru ****
        //{                          ****  isaretsiz halidir     ****
        //    _currentState.OnExit();**** yani "null exception   ****
        //}

        _currentState?.OnExit();

        _currentState = state;

        _currentState.OnStart();
    }

    public void Tick()
    {
        StateTransformer stateTransformer = CheckForTransformer();

        if (stateTransformer != null)
        {
            SetState(stateTransformer.To);
        }

        _currentState.Tick();
    }

    public void TickFixed()
    {
        _currentState.TickFixed();
    }

    public void TickLate()
    {
        _currentState.TickLate();
    }

    private StateTransformer CheckForTransformer()
    {
        foreach (StateTransformer stateTransformer in _anystateTransformer)
        {
            if (stateTransformer.Condition.Invoke()) return stateTransformer;
        }

        foreach (StateTransformer stateTransformer in _stateTransformers)
        {
            if (stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
        }

        return null;
    }
    public void AddState(IState from, IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(from, to, condition);
        _stateTransformers.Add(stateTransformer);
    }

    public void AddAnyState(IState to,System.Func<bool>condition)
    {
        StateTransformer stateTransformers = new StateTransformer(null, to, condition);
        _anystateTransformer.Add(stateTransformers);
    }
}