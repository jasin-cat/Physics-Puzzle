using System;
using R3;
using UnityEngine;

public class RotationState : BaseState
{
    RotateConcentrically _rotateConcentrically;
    InputHandler _input;
    IDisposable _changeDisposable;
    public RotationState(PlayerCameraStateMachine machine, 
                        RotateConcentrically rotateConcentrically,
                        InputHandler input) : base(machine)
    {
        _rotateConcentrically = rotateConcentrically;
        _input = input;

    }

    public override void Enter()
    {
        _rotateConcentrically?.gameObject.SetActive(true);

        _changeDisposable = 
            _input.ChangeObservable
                .Subscribe(_ =>
                {
                    _machine.ChangeState(CameraMoveState.lookDown);
                });
    }

    public override void Exit()
    {
        _changeDisposable?.Dispose();
        _rotateConcentrically?.gameObject.SetActive(false);
        base.Exit();
    }

}