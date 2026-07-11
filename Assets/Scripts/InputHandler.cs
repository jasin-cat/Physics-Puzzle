using System.Threading;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputAction _right;
    [SerializeField] InputAction _left;
    private bool _isRightClick = false;
    public bool IsRightClick => _isRightClick;
    private bool _isLeftClick = false;
    public bool IsLeftClick => _isLeftClick;

    void Start()
    {
        _right.performed += OnRight;
        _right.canceled += OnRightReverse;

        _left.performed += OnLeft;
        _left.canceled += OnLeftReverse;

        _right?.Enable();
        _left?.Enable();
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        _isRightClick = true;
    }

    private void OnRightReverse(InputAction.CallbackContext context)
    {
        _isRightClick = false;
    }

    private void OnLeft(InputAction.CallbackContext context)
    {
        _isLeftClick = true;
    }

    private void OnLeftReverse(InputAction.CallbackContext context)
    {
        _isLeftClick = false;
    }

    void OnDisable()
    {
        _right?.Disable();
        _left?.Disable();
    }
}