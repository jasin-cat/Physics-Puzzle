using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _doLookObj;

    void Start()
    {
        if(_target is null || _doLookObj is null) return;

        if(_target.TryGetComponent(out Renderer r))
        {
            r.enabled = false;
        }
    }

    void Update()
    {
        _doLookObj?.transform.LookAt(_target.transform);
    }
}
