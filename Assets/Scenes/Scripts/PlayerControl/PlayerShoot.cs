using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerControl
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private TimeShift _timeShift;
    [SerializeField] private Transform _bulStart;

    protected override void Start()
    {
        _playerInput.Player.Shoot.performed += ctx => OnShoot();
    }

    private void OnShoot()
    {
        Bullet bullet = Instantiate(_bullet, _bulStart.position, _bulStart.rotation);
        bullet.Init(_timeShift);
    }
}
