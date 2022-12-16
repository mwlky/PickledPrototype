using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public Dictionary<string, IState> _states;
    private IState _currentState;

    public StateMachine()
    {
        _states = new();
    }

    public void ChangeState(string name)
    {
        IState newState = _states[name];

        _currentState?.Exit();

        _currentState = newState;
        _currentState?.Enter();
    }

    public void Update() => _currentState?.Update();

    public void PhysicsUpdate() => _currentState?.PhysicsUpdate();

    public void AddState(string name, IState state)
    {
        _states.Add(name, state);
    }

    public IState GetCurrentState()
    {
        return _currentState;
    }
}
