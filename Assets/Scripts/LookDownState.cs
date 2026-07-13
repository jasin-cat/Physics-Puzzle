using System;
using R3;
using UnityEngine;

public class LookDownState : BaseState
{
    InputHandler _input;
    IDisposable _changeDisposable;
    LookDown _lookDown;
    public LookDownState(
        PlayerCameraStateMachine machine, 
        InputHandler input,
        LookDown lookDown) : base(machine)
    {
        _input = input;
        _lookDown = lookDown;
    }

    public override void Enter()
    {
        _lookDown.gameObject.SetActive(true);
        _changeDisposable = 
            _input.ChangeObservable
                .Subscribe(_ =>
                {
                    _machine.ChangeState(CameraMoveState.rotation);
                });
    }

    public override void Exit()
    {
        _lookDown.gameObject.SetActive(false);
        _changeDisposable?.Dispose();
        base.Exit();
    }
}