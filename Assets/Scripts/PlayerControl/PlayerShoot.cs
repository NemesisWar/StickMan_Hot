using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : PlayerControl
{
    public event UnityAction TryShoot;
    protected override void Start()
    {
        _playerInput.Player.Shoot.performed += ctx => OnShoot();
    }

    private void OnShoot()
    {
        TryShoot?.Invoke();
    }
}
