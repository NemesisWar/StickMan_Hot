using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerControl : MonoBehaviour
{
    protected PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        AfterAwake();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        AfterEnable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        AfterDisable();
    }

    protected virtual void AfterAwake() { }
    protected virtual void AfterEnable() { }
    protected virtual void AfterDisable() { }

    protected abstract void Start();
}
