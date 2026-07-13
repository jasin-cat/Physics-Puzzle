using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

public class RotateConcentrically : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 3f;
    private float _limitSpeed = 100f;
    [SerializeField] private float _radius = 18f;
    private float _angle = 0;
    [Header("Scripts")]
    [SerializeField] private InputHandler _inputHandler;

    void Update()
    {
        if(_inputHandler.IsRightClick) _angle += Time.deltaTime * -_speed / _limitSpeed;
        if(_inputHandler.IsLeftClick) _angle += Time.deltaTime * _speed / _limitSpeed;
        float radian = _angle * Mathf.Rad2Deg;

        _transform.position = new Vector3
            (
                Mathf.Sin(radian) * _radius,
                _transform.position.y,
                Mathf.Cos(radian) * _radius
            );

        _transform.LookAt(_targetTransform);
    }
}
