using System;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;


public class StateMachine : IDisposable
{
    private Dictionary<CameraMoveState, IState> _states;
    private IState _currentState;
    private CameraMoveState _currentStateType;
    public CameraMoveState CurrentStateType => _currentStateType;
    private Subject<Unit> _onCompletedExit;
    public Observable<Unit> OnCompletedExit => _onCompletedExit;
    private IDisposable _onCompletedExitDisposable;

    private void Start()
    {
        _states = new()
        {
            
        };

        _onCompletedExit = new();

        // Exitが終わったらEnterを呼ぶ
        _onCompletedExitDisposable = _onCompletedExit
            .Subscribe(_ =>
            {
                _currentState.Enter();
            });

        // draw stateにする
        if(_states.TryGetValue(CameraMoveState.rotation, out IState value))
        {
            value.Enter();
            _currentState = value;
            _currentStateType = CameraMoveState.rotation;
        }

        Debug.Log($"Type: {_currentStateType}");
    }

/// <summary>
/// Stateを変える
/// </summary>
/// <param name="state"></param>
    public void ChangeState(CameraMoveState state)
    {
        if(_states.TryGetValue(state, out IState currentState))
        {
            IState oldState = _currentState;
            _currentState = currentState;
            _currentStateType = state;

            oldState.Exit();
        }
    }

/// <summary>
/// IState.Exit()が終わるときに呼ぶ
/// </summary>
    public void OnCompletedExitChangeValue()
    {
        _onCompletedExit.OnNext(Unit.Default);
    }

/// <summary>
/// このclassをDisposableするときに呼ぶ
/// </summary>
    public void Dispose()
    {
        _onCompletedExitDisposable.Dispose();
    }
}

public enum State
{
    register,
    player1,
    player2,
    result,
}

