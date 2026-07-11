using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

public class RotateConcentrically : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 1f;
    private float _limitSpeed = 100f;
    [SerializeField] private float _radius;
    private float _angle = 0;
    [Header("Scripts")]
    [SerializeField] private InputHandler _inputHandler;
    void Start()
    {
        if(_transform is null) _transform = this.transform;
    }


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
