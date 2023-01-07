using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : PlayerControl
{
    [SerializeField] private float _speedRotation;
    private Vector2 _rotateDirection;
    private Vector2 _rotation;

    protected override void Start()
    {
    }

    private Vector2 OnRotate()
    {
        _rotateDirection = _playerInput.Player.Rotate.ReadValue<Vector2>();
        return _rotateDirection;
    }

    private void Rotate(Vector2 rotateDirection)
    {
        if (_rotateDirection.sqrMagnitude < 0.1)
            return;

        _rotation.y += rotateDirection.x * _speedRotation * Time.deltaTime;
        _rotation.x = Mathf.Clamp(_rotation.x - rotateDirection.y * _speedRotation * Time.deltaTime, -85, 85);
        transform.localEulerAngles = _rotation;
    }

    private void Update()
    {
        _playerInput.Player.Rotate.performed += ctx => OnRotate();
        Rotate(OnRotate());
    }
}
