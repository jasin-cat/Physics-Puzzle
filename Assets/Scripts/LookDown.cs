using UnityEngine;

public class LookDown : MonoBehaviour
{
    [SerializeField] private Transform _main;
    [SerializeField] private Vector3 _lookDownRotate;
    [SerializeField] private Vector3 _lookDownPos;

    private Vector3 _keepPos;
    private Vector3 _keepRotate;

    void OnEnable()
    {
        _keepPos = _main.position;
        _keepRotate = _main.rotation.eulerAngles;

        _main.position = _lookDownPos;
        _main.Rotate(_lookDownRotate);
    }

    void OnDisable()
    {
        _main.position = _keepPos;
        _main.Rotate(_keepRotate);
    }
}
